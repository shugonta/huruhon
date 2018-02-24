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
    public partial class BagEdit : Form
    {
        private int boxid = 0;
        private int genreid = 0;
        private List<int> eraselist;
        public BagEdit()
        {
            InitializeComponent();
            eraselist = new List<int>();
        }

        private void BagEdit_Load(object sender, EventArgs e)
        {
            RefreshData();
            ToolTip toolTipMsg = new ToolTip();

            //textBox1にツールチップを表示するように設定する
            toolTipMsg.SetToolTip(text_name, "福袋名[福袋番号(通算番号)]の形式で入力してください。タグには番号のみが印刷されます");

        }

        private void RefreshData()
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            comboBox_bag.Items.Clear();
            comboBox_genre.Items.Clear();
            var boxlist = (from n in context.box
                           where n.box_isbag == true
                           select n).ToList();
            if (boxlist.Count > 0)
            {
                foreach (var q in boxlist)
                {
                    comboBox_bag.Items.Add(q.box_id);
                }
                comboBox_bag.SelectedIndex = 0;
            }

            var genrelist = (from n in context.genre
                             select n).ToList();
            if (genrelist.Count > 0)
            {
                foreach (var q in genrelist)
                {
                    comboBox_genre.Items.Add(q.genre_name);
                }
                comboBox_genre.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            if (boxid > 0)
            {
                var list = (from n in context.item
                            where n.item_box_id == boxid
                            select n).ToList();
                foreach (var q in list)
                {
                    //グリッド追加
                    dataGridView1.Rows.Add(
                        q.item_id,
                        q.item_name,
                        q.item_tagprice,
                        q.item_sellprice_bag
                        );
                }
                int price = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int i = 0;
                    if (row.Cells["ItemSellPrice"].Value != null && int.TryParse(row.Cells["ItemSellPrice"].Value.ToString(), out i))
                    {
                        price += i;
                    }
                }
                label_Price.Text = "合計金額:" + price.ToString() + "円";
                button_item.Enabled = true;
                button_save.Enabled = true;
            }
        }

        private void comboBox_bag_SelectedValueChanged(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            boxid = (int)comboBox_bag.SelectedItem;
            if (boxid >= 0)
            {
                var box = context.box.Single(n => n.box_id == boxid);
                text_name.Text = box.box_comment;
                comboBox_genre.SelectedItem = context.genre.Single(n => n.genre_id == box.box_genre).genre_name;
            }
            button_item.Enabled = false;
            button_save.Enabled = false;
            dataGridView1.Rows.Clear();

        }

        private void comboBox_genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            genreid = context.genre.Single(n => n.genre_name == comboBox_genre.SelectedItem.ToString()).genre_id;
        }
        private void button_bagadd_Click(object sender, EventArgs e)
        {
            if (text_name.Text.Length > 0)
            {
                var context = new DBClassDataContext(Globals.ConnectionString);
                var newbox = new box
                {
                    box_isbag = true,
                    box_genre = genreid,
                    box_comment = text_name.Text
                };
                context.box.InsertOnSubmit(newbox);
                boxid = newbox.box_id;
                context.SubmitChanges();
                dataGridView1.Rows.Clear();
                RefreshData();
                comboBox_bag.SelectedIndex = comboBox_bag.Items.Count - 1;
                LoadData();
            }
        }

        private void comboBox_bag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Rows.Clear();
                LoadData();
            }
        }

        private void button_item_Click(object sender, EventArgs e)
        {
            int id;
            if (text_itemid.Text.Length > 0 && int.TryParse(text_itemid.Text, out id))
            {
                var context = new DBClassDataContext(Globals.ConnectionString);
                var list = (from n in context.item
                            where n.item_id == id
                            select n).ToList();
                if (list.Count == 0)
                {
                    MessageBox.Show("該当する商品が存在しません");
                }
                else
                {
                    foreach (var q in list)
                    {
                        if (q.item_genre.HasValue && q.item_genre.Value != genreid)
                        {
                            if (DialogResult.No == MessageBox.Show("指定したジャンルと異なりますが追加しますか?", "確認", MessageBoxButtons.YesNo)) { return; }
                        }
                        dataGridView1.Rows.Add(
                                q.item_id,
                                q.item_name,
                                q.item_tagprice
                                );
                    }
                }
                text_itemid.SelectAll();
            }

        }

        private void text_itemid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_item_Click(text_itemid, null);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            var box = context.box.Single(n => n.box_id == boxid);
            box.box_comment = text_name.Text;
            //削除
            foreach (int itemid in eraselist)
            {
                var q = context.item.Single(n => n.item_id == itemid);
                if (q.item_box_id == boxid)
                {
                    q.item_box_id = null;
                    q.item_sellprice_bag = null;
                }
            }
            //追加
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int sellprice;
                if (int.TryParse((row.Cells["ItemSellPrice"].Value ?? "").ToString(), out sellprice))
                {
                    var item = context.item.Single(n => n.item_id == (int)row.Cells["ItemId"].Value);
                    item.item_box_id = boxid;
                    item.item_sellprice_bag = sellprice;
                    row.ErrorText = null;
                }
                else
                {
                    MessageBox.Show("不正な文字列です");
                    row.ErrorText = "不正な文字列です";
                    return;
                }
            }
            context.SubmitChanges();
            MessageBox.Show("保存しました");
            button_item.Enabled = false;
            button_save.Enabled = false;
            label_Price.Text = "";
            dataGridView1.Rows.Clear();
            RefreshData();

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("この行を削除してもよろしいですか", "確認", MessageBoxButtons.YesNo))
            {
                e.Cancel = true;
                return;
            }
            if (e.Row.Cells["ItemId"].Value is int)
            {
                eraselist.Add((int)e.Row.Cells["ItemId"].Value);
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int price = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int i = 0;
                    if (row.Cells["ItemSellPrice"].Value != null && int.TryParse(row.Cells["ItemSellPrice"].Value.ToString(), out i))
                    {
                        price += i;
                    }
                }
                label_Price.Text = "合計金額:" + price.ToString() + "円";
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            //印刷
            try
            {
                var boxlist = (from n in context.box
                               where n.box_isbag == true
                               select n.box_id).ToList();
                BoxTagPrintDocument.PrintItems(boxlist);
            }
            catch { }
        }

    }
}
