using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kaede3rd
{
    public partial class SellForm : Form
    {
        private int curItem_id = 0;
        private int privItem_id = 0;
        private int? privItemSellPrice = null;
        private DateTime? privItemSellTime = null;
        private int? privItemSellOperatorId = null;

        private int nowOperator = 0;

        public SellForm()
        {
            InitializeComponent();
            this.Text = "売却 (" + Globals.Config.bumonnname + ")";
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox tx = (TextBox)sender;
            tx.SelectAll();
        }

        private void textBox_ban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = this.textBox_ban.Text;
                if (s == null) { return; }

                int shinaBan;

                if (Globals.TryParseBarcode(s, out shinaBan))
                {
                }
                else
                {
                    if (!int.TryParse(this.textBox_ban.Text, out shinaBan))
                    {
                        this.textBox_ban_err("不明な文字列です");
                        return;
                    }
                }

                if (!(0 <= shinaBan && shinaBan <= 999999))
                {
                    this.textBox_ban_err("不正な品番です");
                }
                bool success = false;
                while (!success)
                {
                    try
                    {
                        if (shinaBan >= 90000)
                        {
                            var context = new DBClassDataContext(Globals.ConnectionString);
                            List<box> bxes = (from n in context.box
                                              where n.box_id == shinaBan - 90000
                                              select n).ToList();
                            if (bxes.Count == 0)
                            {
                                this.textBox_ban_err("品番に該当する商品がありません");
                                return;
                            }
                            this.setItem(bxes[0]);
                            break;
                        }
                        else
                        {
                            var context = new DBClassDataContext(Globals.ConnectionString);
                            List<item> its = (from n in context.item
                                              where n.item_id == shinaBan
                                              select n).ToList();
                            if (its.Count == 0)
                            {
                                this.textBox_ban_err("品番に該当する商品がありません");
                                return;
                            }

                            this.setItem(its[0]);
                            break;

                        }
                    }
                    catch (Exception ex)
                    {
                        if (Globals.ConnectionString.State == ConnectionState.Open) { }
                        else
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }
        }

        private void setItem(item it)
        {
            this.curItem_id = it.item_id;
            var context = new DBClassDataContext(Globals.ConnectionString);
            item it_data = it;
            this.textBox_ban.Text = it.item_id.ToString();

            this.textBox_name.BackColor = SystemColors.Control;
            this.textBox_name.Text = it_data.item_name;
            this.textBox_teika.Text = it_data.item_tagprice.ToString("#,##0");
            this.textBox_nebiki.Text = it_data.item_return /*FIXME*/ ? "×" : "○";
            if (it_data.item_sellprice.HasValue)
            {
                this.label_sellzumi.Visible = true;
                this.label_sellzumi.Text = "売却済 ¥" + it_data.item_sellprice.Value.ToString("#,##0");
                this.label_sellop.Visible = true;
                this.label_sellop.Text = "入力者: " +
                    (it_data.item_sell_operator != null ? context.@operator.Single(n => n.operator_id == it_data.item_sell_operator.Value).operator_name : "不明");
                this.label_sellop.Text += "  " + Globals.getTimeString(it_data.item_selltime);

                if (it_data.item_sellprice.Value == it_data.item_tagprice)
                {
                    this.textBox_baika.Text = "-";
                }
                else
                {
                    this.textBox_baika.Text = it_data.item_sellprice.Value.ToString();
                }
                this.button_mibai.Visible = true;
            }
            else if (it_data.item_sellprice_bag.HasValue)
            {
                this.label_sellzumi.Visible = true;
                this.label_sellzumi.Text = "福袋商品です。 箱番:" + it_data.item_box_id.Value.ToString();
            }
            else
            {
                this.label_sellzumi.Visible = false;
                this.label_sellop.Visible = false;
                this.button_mibai.Visible = false;
                this.textBox_baika.Text = "";
            }

            this.label_baikaEnter.Visible = true;
            this.textBox_baika.ReadOnly = false;
            this.textBox_baika.BackColor = SystemColors.Window;
            this.textBox_baika.Focus();
            this.textBox_baika.SelectAll();
        }

        private void setItem(box bx)
        {
            this.curItem_id = 90000 + bx.box_id;
            var context = new DBClassDataContext(Globals.ConnectionString);
            box box_data = bx;
            List<item> item_list = (from n in context.item
                                    where n.item_box_id == box_data.box_id
                                    select n).ToList();
            this.textBox_ban.Text = bx.box_id.ToString();

            this.textBox_name.BackColor = SystemColors.Control;
            this.textBox_name.Text = box_data.box_comment;
            this.textBox_teika.Text = item_list.Sum(n => n.item_sellprice_bag.Value).ToString("#,##0");
            this.textBox_nebiki.Text = "×";
            if (item_list[0].item_sellprice.HasValue)
            {
                this.label_sellzumi.Visible = true;
                this.label_sellzumi.Text = "売却済 ¥" + item_list.Sum(n => n.item_sellprice.Value).ToString("#,##0");
                this.label_sellop.Visible = true;
                this.label_sellop.Text = "入力者: " +
                    (item_list[0].item_sell_operator != null ? context.@operator.Single(n => n.operator_id == item_list[0].item_sell_operator.Value).operator_name : "不明");
                this.label_sellop.Text += "  " + Globals.getTimeString(item_list[0].item_selltime);

                if (item_list.Sum(n => n.item_sellprice.Value) == item_list.Sum(n => n.item_sellprice_bag.Value))
                {
                    this.textBox_baika.Text = "-";
                }
                else
                {
                    this.textBox_baika.Text = item_list.Sum(n => n.item_sellprice.Value).ToString();
                }
                this.button_mibai.Visible = true;
            }
            else
            {
                this.label_sellzumi.Visible = false;
                this.label_sellop.Visible = false;
                this.button_mibai.Visible = false;
                this.textBox_baika.Text = "";
            }

            this.label_baikaEnter.Visible = true;
            this.textBox_baika.ReadOnly = false;
            this.textBox_baika.BackColor = SystemColors.Window;
            this.textBox_baika.Focus();
            this.textBox_baika.SelectAll();
        }

        private void textBox_ban_err(string err)
        {
            this.curItem_id = 0;

            this.textBox_name.BackColor = Color.LightYellow;
            this.textBox_name.Text = err;
            this.textBox_teika.Text = "";
            this.textBox_nebiki.Text = "";

            this.label_sellzumi.Visible = false;
            this.label_sellop.Visible = false;
            this.button_mibai.Visible = false;

            this.textBox_baika.BackColor = SystemColors.Control;
            this.textBox_baika.ReadOnly = true;
            this.label_baikaEnter.Visible = false;

            this.textBox_ban.Focus();
            this.textBox_ban.SelectAll();
        }

        private void textBox_baika_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && curItem_id != 0)
            {
                if (this.curItem_id == 0) { return; }
                var context = new DBClassDataContext(Globals.ConnectionString);
                if (curItem_id < 90000)
                {
                    item curItem = context.item.Single(n => n.item_id == curItem_id);
                    string s = this.textBox_baika.Text;

                    int baika;
                    if (s == "-")
                    {
                        baika = curItem.item_tagprice;
                    }
                    else
                    {
                        if (!int.TryParse(s, out baika))
                        {
                            this.textBox_baika_err();
                            return;
                        }
                        if (baika > 999999)
                        {
                            this.textBox_baika_err();
                            return;
                        }
                    }

                    if (curItem.item_sellprice.HasValue && curItem.item_sellprice.Value == baika)
                    {
                    }
                    else
                    {
                        privItem_id = curItem_id;
                        privItemSellPrice = curItem.item_sellprice;
                        privItemSellTime = curItem.item_selltime;
                        privItemSellOperatorId = curItem.item_sell_operator;

                        curItem.item_sellprice = baika;
                        curItem.item_selltime = DateTime.Now;
                        curItem.item_sell_operator = this.nowOperator;

                    }
                }
                else
                {
                    box curbox = context.box.Single(n => n.box_id == (curItem_id - 90000));
                    List<item> curItems = (from n in context.item
                                           where n.item_box_id == curbox.box_id
                                           select n).ToList();
                    string s = this.textBox_baika.Text;
                    int baika;
                    if (s == "-")
                    {
                        baika = curItems.Sum(n => n.item_sellprice_bag.Value);



                        if (curItems[0].item_sellprice.HasValue && curItems.Sum(n => n.item_sellprice.Value) == baika)
                        {
                        }
                        else
                        {
                            privItem_id = 0;
                            privItemSellPrice = null;
                            privItemSellTime = null;
                            privItemSellOperatorId = null;
                            foreach (var q in curItems)
                            {
                                q.item_sellprice = q.item_sellprice_bag;
                                q.item_selltime = DateTime.Now;
                                q.item_sell_operator = this.nowOperator;
                            }
                        }
                    }
                }
                System.Threading.Thread t = new System.Threading.Thread(
                    delegate()
                    {
                        bool success = false;
                        while (!success)
                        {
                            try
                            {
                                context.SubmitChanges();
                                break;
                            }
                            catch (Exception ex)
                            {
                                if (Globals.ConnectionString.State == ConnectionState.Open) { }
                                else
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }
                        }
                    });

                t.Start();
                this.textBox_ban_err("次の品番を入力してね");
            }
        }

        private void textBox_baika_err()
        {
            this.textBox_baika.BackColor = Color.LightPink;
            this.textBox_baika.Focus();
            this.textBox_baika.SelectAll();
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            this.textBox_ban_err("品番を入力してください");

            this.button1.PerformClick();
        }

        private void SellForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                var context = new DBClassDataContext(Globals.ConnectionString);
                if (this.privItem_id == 0) { return; }
                item privItem = context.item.Single(n => n.item_id == privItem_id);
                int? priv_canceledsellprice = privItem.item_sellprice;
                privItem.item_sellprice = privItemSellPrice;
                privItem.item_selltime = privItemSellTime;
                privItem.item_sell_operator = privItemSellOperatorId;

                context.SubmitChanges();

                this.setItem(privItem);

                this.textBox_baika.Text = priv_canceledsellprice.ToString();
                this.textBox_baika.Focus();
                this.textBox_baika.SelectAll();

                this.privItem_id = 0;
            }
        }

        private void button_mibai_Click(object sender, EventArgs e)
        {
            if (curItem_id == 0) { return; }
            privItem_id = curItem_id;
            var context = new DBClassDataContext(Globals.ConnectionString);
            if (curItem_id < 90000)
            {
                item curItem = context.item.Single(n => n.item_id == curItem_id);
                privItemSellPrice = curItem.item_sellprice;
                privItemSellTime = curItem.item_selltime;
                privItemSellOperatorId = curItem.item_sell_operator;
                curItem.item_sellprice = null;
                curItem.item_selltime = null;
            }
            else
            {
                box curBox = context.box.Single(n => n.box_id == (curItem_id - 90000));
                var curItems = (from n in context.item
                                where n.item_box_id == curBox.box_id
                                select n).ToList();
                foreach (var q in curItems)
                {
                    q.item_sellprice = null;
                    q.item_selltime = null;
                }
            }

            context.SubmitChanges();

            this.textBox_ban_err("次の品番を入力してね");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int op;
            if (SelectOperator.ShowSelectOperatorDialog(out op) == DialogResult.OK)
            {
                this.nowOperator = op;
            }
            else
            {
                this.Close();
                return;
            }
            var context = new DBClassDataContext(Globals.ConnectionString);
            var nop = context.@operator.Single(n => n.operator_id == this.nowOperator);
            this.textBox_operator.Text = nop.operator_name;
            this.textBox_ban_err("品番を入力してください");
        }
    }
}
