using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace kaede3rd
{
    public partial class KansaForm : Form
    {
        private int curItem_id = 0;

        private int nowOperator = 0;

        private Timer timer1;

        public KansaForm()
        {
            InitializeComponent();
            this.Text = "監査  (" + Globals.Config.bumonnname + ")";

            this.timer1 = new Timer();
            timer1.Interval = 5 * 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;

            this.RefreshRemain();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshRemain();
        }

        private void RefreshRemain()
        {
            System.Threading.Thread t = new System.Threading.Thread(delegate()
            {
                try
                {
                    var context = new DBClassDataContext(Globals.ConnectionString);
                    var it = (from n in context.item
                              select n).ToList();
                    int cnt;

                    cnt = (from n in it
                           where n.item_kansa_end == null && n.item_sellprice != null && n.item_kansa_flag1 == null
                           select n).Count();

                    ControlUtil.SafelyOperated(this.textBox_remain, (MethodInvoker)delegate()
                    {
                        this.textBox_remain.Text = cnt.ToString();
                    });

                    int allcnt;
                    allcnt = (from n in it
                              where n.item_kansa_end == null && n.item_sellprice != null
                              select n).Count();

                    ControlUtil.SafelyOperated(this.textBox_allkansa, (MethodInvoker)delegate()
                    {
                        this.textBox_allkansa.Text = allcnt.ToString();
                    });

                    int sum;
                    sum = (from n in it
                           where n.item_kansa_end == null && n.item_sellprice != null
                           select n.item_sellprice.Value).Sum();
                    ControlUtil.SafelyOperated(this.textBox_sum, (MethodInvoker)delegate()
                    {
                        this.textBox_sum.Text = sum.ToString("#,##0");
                    });
                }
                catch { }
            });

            t.IsBackground = true;
            t.Start();
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

                var context = new DBClassDataContext(Globals.ConnectionString);
                bool success = false;
                while (!success)
                {
                    try
                    {
                        if (shinaBan < 90000)
                        {
                            List<item> its = (from n in context.item
                                              where n.item_id == shinaBan
                                              select n).ToList();

                            if (its.Count == 0)
                            {
                                this.textBox_ban_err("品番に該当する商品がありません");
                                return;
                            }

                            this.DoKansaItem(its[0].item_id);
                            break;
                        }
                        else
                        {
                            List<box> its = (from n in context.box
                                             where n.box_id == shinaBan - 90000
                                             select n).ToList();

                            if (its.Count == 0)
                            {
                                this.textBox_ban_err("品番に該当する商品がありません");
                                return;
                            }

                            this.DoKansaItem(shinaBan);
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

        private void DoKansaItem(int it_id)
        {
            this.curItem_id = it_id;
            var context = new DBClassDataContext(Globals.ConnectionString);
            if (it_id < 90000)
            {
                item it = context.item.Single(n => n.item_id == it_id);
                context.Connection.Close();
                this.textBox_ban.Text = it.item_id.ToString();

                this.textBox_name.BackColor = SystemColors.Control;
                this.textBox_name.Text = it.item_name;
                this.textBox_teika.Text = it.item_tagprice.ToString("#,##0");
                this.textBox_nebiki.Text = it.item_return /*FIXME*/ ? "×" : "○";

                if (it.item_sellprice.HasValue)
                {
                    if (it.item_sellprice.Value == it.item_tagprice)
                    {
                        this.textBox_baika.Text = "-- " + it.item_sellprice.Value.ToString();
                    }
                    else
                    {
                        this.textBox_baika.Text = it.item_sellprice.Value.ToString();
                    }

                    if (it.item_sell_operator != null)
                    {
                        this.textBox_sellop.Text = context.@operator.Single(n => n.operator_id == it.item_sell_operator).operator_name;
                    }
                    else
                    {
                        this.textBox_sellop.Text = "不明";
                    }

                    this.textBox_selltime.Text = Globals.getTimeString(it.item_selltime);

                    this.button_mibai.Enabled = true;
                    this.button_teisei.Enabled = true;
                    this.textBox_baika.BackColor = SystemColors.Control;


                    if (it.item_kansa_end.HasValue)
                    {
                        //監査済み
                        this.label_error.Text = "監査対象ではありません。本日の販売ではない可能性が。";
                        this.label_error.Visible = true;
                    }
                    else
                    {
                        if (this.GetKansaFlag(it).HasValue)
                        {
                            List<@operator> lop = (from n in context.@operator
                                                   where n.operator_id == GetKansaFlag(it).Value
                                                   select n).ToList();

                            if (lop.Count() == 0)
                            {
                                this.label_error.Text = "だれかが既に監査したようです";
                            }
                            else
                            {
                                this.label_error.Text = lop[0].operator_name + " が既に監査しています";
                            }

                            this.label_error.Visible = true;
                        }
                        else
                        {
                            /*
                            System.Threading.Thread t = new System.Threading.Thread(
                                delegate(object item)
                                {
                                    item itemmm = (item)item;
                                    this.SetKansaFlag(itemmm, this.nowOperator);
                                    context.SubmitChanges();
                                }
                            );

                            t.IsBackground = true;
                            t.Start(it);
                            */
                            this.SetKansaFlag(it, this.nowOperator);
                            context.SubmitChanges();
                            this.label_error.Text = "監査しました。次の品番を入力してね";

                            this.RefreshRemain();
                        }
                    }

                }

                else
                {
                    this.button_teisei.Enabled = true;
                    this.button_mibai.Enabled = false;
                    this.textBox_baika.Text = "未売却";
                    this.textBox_baika.BackColor = Color.LightPink;
                    this.textBox_sellop.Text = null;
                    this.textBox_selltime.Text = null;

                    this.label_error.Text = "未売却の商品は監査できません";
                    this.label_error.Visible = true;
                }
            }
            else
            {
                box bx = context.box.Single(n => n.box_id == (it_id - 90000));
                List<item> it = (from n in context.item
                                 where n.item_box_id == bx.box_id
                                 select n).ToList();
                context.Connection.Close();
                this.textBox_ban.Text = bx.box_id.ToString();
                this.textBox_name.BackColor = SystemColors.Control;
                this.textBox_name.Text = bx.box_comment;
                int sellpprice = (from n in it
                                  select n.item_sellprice.HasValue ? n.item_sellprice.Value : 0).Sum();
                this.textBox_teika.Text = sellpprice.ToString("#,##0");
                this.textBox_nebiki.Text = "×";

                if (sellpprice > 0)
                {
                    this.textBox_baika.Text = sellpprice.ToString();
                    if (it[0].item_sell_operator != null)
                    {
                        this.textBox_sellop.Text = context.@operator.Single(n => n.operator_id == it[0].item_sell_operator).operator_name;
                    }
                    else
                    {
                        this.textBox_sellop.Text = "不明";
                    }

                    this.textBox_selltime.Text = Globals.getTimeString(it[0].item_selltime);

                    this.button_mibai.Enabled = true;
                    this.button_teisei.Enabled = true;
                    this.textBox_baika.BackColor = SystemColors.Control;

                    bool kansaend = true;
                    foreach (var q in it)
                    {
                        if (!q.item_kansa_end.HasValue) { kansaend = false; }
                    }
                    if (kansaend)
                    {
                        //監査済み
                        this.label_error.Text = "監査対象ではありません。本日の販売ではない可能性が。";
                        this.label_error.Visible = true;
                    }
                    else
                    {
                        if (this.GetKansaFlag(it[0]).HasValue)
                        {
                            List<@operator> lop = (from n in context.@operator
                                                   where n.operator_id == GetKansaFlag(it[0]).Value
                                                   select n).ToList();

                            if (lop.Count() == 0)
                            {
                                this.label_error.Text = "だれかが既に監査したようです";
                            }
                            else
                            {
                                this.label_error.Text = lop[0].operator_name + " が既に監査しています";
                            }

                            this.label_error.Visible = true;
                        }
                        else
                        {
                            /*
                            System.Threading.Thread t = new System.Threading.Thread(
                                delegate(object item)
                                {
                                    item itemmm = (item)item;
                                    this.SetKansaFlag(itemmm, this.nowOperator);
                                    context.SubmitChanges();
                                }
                            );

                            t.IsBackground = true;
                            t.Start(it);
                            */
                            foreach (var q in it)
                            {
                                this.SetKansaFlag(q, this.nowOperator);
                            }

                            while (true)
                            {
                                try
                                {
                                    context.SubmitChanges();
                                    break;
                                }
                                catch
                                {
                                    if (Globals.ConnectionString.State == ConnectionState.Open)
                                    {
                                    }
                                    else
                                    {
                                        this.label_error.Text = "監査に失敗しました。";
                                        return;
                                    }
                                }
                            }
                            this.label_error.Text = "監査しました。次の品番を入力してね";

                            this.RefreshRemain();
                        }
                    }


                }
                else
                {
                    this.button_teisei.Enabled = true;
                    this.button_mibai.Enabled = false;
                    this.textBox_baika.Text = "未売却";
                    this.textBox_baika.BackColor = Color.LightPink;
                    this.textBox_sellop.Text = null;
                    this.textBox_selltime.Text = null;

                    this.label_error.Text = "未売却の商品は監査できません";
                    this.label_error.Visible = true;
                }
            }
            this.textBox_ban.Focus();
            this.textBox_ban.SelectAll();
        }

        private void textBox_ban_err(string err)
        {
            this.curItem_id = 0;

            this.textBox_name.BackColor = Color.LightYellow;
            this.textBox_name.Text = err;
            this.textBox_teika.Text = "";
            this.textBox_nebiki.Text = "";

            this.button_teisei.Enabled = false;
            this.button_mibai.Enabled = false;

            this.textBox_baika.BackColor = SystemColors.Control;
            this.textBox_baika.ReadOnly = true;

            this.textBox_ban.Focus();
            this.textBox_ban.SelectAll();
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

        private void button_mibai_Click(object sender, EventArgs e)
        {
            if (curItem_id == 0) { return; }
            if (curItem_id < 90000)
            {
                var context = new DBClassDataContext(Globals.ConnectionString);
                var curItem = context.item.Single(n => n.item_id == curItem_id);
                curItem.item_sellprice = null;
                curItem.item_selltime = null;
                context.SubmitChanges();
                this.DoKansaItem(curItem_id);
                this.label_error.Text = "商品を未売却にしました";
            }
            else
            {
                var context = new DBClassDataContext(Globals.ConnectionString);
                var curItem = (from n in context.item
                               where n.item_box_id == (curItem_id - 90000)
                               select n).ToList();
                foreach (var q in curItem)
                {
                    q.item_sellprice = null;
                    q.item_selltime = null;
                }
                context.SubmitChanges();
                this.DoKansaItem(curItem_id);
                this.label_error.Text = "商品を未売却にしました";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int op;
            try
            {
                if (SelectOperator.ShowSelectOperatorDialog(out op) == DialogResult.OK)
                {
                    this.nowOperator = op;
                }
                else
                {
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }
            var context = new DBClassDataContext(Globals.ConnectionString);
            this.textBox_operator.Text = context.@operator.Single(n => n.operator_id == this.nowOperator).operator_name;
            this.textBox_ban_err("品番を入力してください");
        }

        private int? GetKansaFlag(item it)
        {
            if (it == null) { throw new NullReferenceException(); }

            return it.item_kansa_flag1;
        }

        private void SetKansaFlag(item it, int? val)
        {
            if (it == null) { throw new NullReferenceException(); }

            it.item_kansa_flag1 = val;
        }

        private void button_teisei_Click(object sender, EventArgs e)
        {
            if (this.curItem_id == 0) { return; }
            string def;
            var context = new DBClassDataContext(Globals.ConnectionString);
            if (curItem_id < 90000)
            {
                var curItem = context.item.Single(n => n.item_id == curItem_id);
                if (curItem.item_sellprice.HasValue)
                {
                    def = curItem.item_sellprice.ToString();
                }
                else
                {
                    def = "未売却";
                }

                while (true)
                {
                    string res;
                    DialogResult dres = InputBox.ShowIntDialog("修正後の売価を入力してください\n商品名: " + curItem.item_name, "売価修正", def, out res);

                    if (dres == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        int baika;
                        if (!int.TryParse(res, out baika))
                        {
                            def = "不正な文字列です";
                            continue;
                        }

                        curItem.item_sellprice = baika;
                        curItem.item_selltime = DateTime.Now;
                        curItem.item_sell_operator = this.nowOperator;
                        while (true)
                        {
                            try
                            {
                                context.SubmitChanges();
                                break;
                            }
                            catch
                            {
                                if (Globals.ConnectionString.State == ConnectionState.Open)
                                {
                                }
                                else
                                {
                                    this.label_error.Text = "監査に失敗しました。";
                                    return;
                                }
                            }
                        }

                        this.DoKansaItem(curItem_id);
                        this.label_error.Text = "金額訂正が完了しました";

                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("福袋の値段修正はできません。個別に修正してください。");
            }
        }

        private ItemsShow listForm = null;
        private void button2_Click(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            if (this.listForm == null || this.listForm.IsDisposed)
            {
                this.listForm = new ItemsShow(
                    (ItemsShow.ItemReturnDelegate)delegate()
                    {
                        return (from n in context.item
                                where n.item_kansa_end == null && n.item_sellprice != null && n.item_kansa_flag1 == null
                                select n).ToList();

                    }, "未" + this.Text);
            }

            this.listForm.Show();
            this.listForm.Activate();
        }

        private ItemsShow allListForm = null;
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.allListForm == null || this.allListForm.IsDisposed)
            {
                var context = new DBClassDataContext(Globals.ConnectionString);
                this.allListForm = new ItemsShow(
                    (ItemsShow.ItemReturnDelegate)delegate()
                    {
                        return (from n in context.item
                                where n.item_kansa_end == null && n.item_sellprice != null
                                select n).ToList();
                    }, "監査対象");

            }

            this.allListForm.Show();
            this.allListForm.Activate();
        }

        private void KansaForm_Load(object sender, EventArgs e)
        {
            this.button1.PerformClick();
        }

        private void button_allend_Click(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            DialogResult res = MessageBox.Show("このコマンドは、当日の監査が終了したときに一度だけ実行してください。\n" +
                            "\"監査対象\" の品をクリアしますか？", "監査完了？", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes) { return; }

            List<item> lit = (from n in context.item
                              where n.item_kansa_end == null && n.item_sellprice != null
                              select n).ToList();

            DateTime dt = DateTime.Now;
            for (int i = 0; i < lit.Count; i++)
            {
                lit[i].item_kansa_end = dt;
            }
            while (true)
            {
                try
                {
                    context.SubmitChanges();
                    break;
                }
                catch
                {
                    if (Globals.ConnectionString.State == ConnectionState.Open)
                    {
                    }
                    else
                    {
                        this.label_error.Text = "監査に失敗しました。";
                        return;
                    }
                }
            }

            this.RefreshRemain();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            DialogResult res = MessageBox.Show("このコマンドでは、「監査対象」の商品を全て未監査に戻します。\n" +
                "よろしいですか？", "監査やりなおし？", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes) { return; }

            List<item> lit = (from n in context.item
                              where n.item_kansa_end == null && n.item_sellprice != null
                              select n).ToList();

            DateTime dt = DateTime.Now;
            for (int i = 0; i < lit.Count; i++)
            {
                lit[i].item_kansa_flag1 = null;
            }
            while (true)
            {
                try
                {
                    context.SubmitChanges();
                    break;
                }
                catch
                {
                    if (Globals.ConnectionString.State == ConnectionState.Open)
                    {
                    }
                    else
                    {
                        this.label_error.Text = "監査に失敗しました。";
                        return;
                    }
                }
            }

            this.RefreshRemain();
        }

        private void KansaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Enabled = false;
            this.timer1 = null;
        }

    }
}
