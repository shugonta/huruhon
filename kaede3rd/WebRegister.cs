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
    public partial class WebRegister : Form
    {
        private string email;
        private bool supplement = false;
        private WebRegisterItemDataContext wrcontext;
        public WebRegister()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int receiptid;
                if (int.TryParse(textBox_No.Text, out receiptid))
                {
                    LoadReceipt(receiptid);
                    button_save.Enabled = true;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void LoadReceipt(int receiptid)
        {
            if (Globals.Config.connectionstring.Length == 0)
            {
                MessageBox.Show("接続文字列が未設定です");
                return;
            }
            wrcontext = new WebRegisterItemDataContext(Globals.Config.connectionstring);
            try
            {
                wrcontext.Connection.Open();
            }
            catch (Exception ex)
            {
                if (DialogResult.Yes == MessageBox.Show(ex.Message + "\n接続文字列を変更しますか?", "確認", MessageBoxButtons.YesNo))
                {
                    ConfigForm form = new ConfigForm();
                    form.ShowDialog();
                    LoadReceipt(receiptid);
                }
                return;
            }
            //出品者情報取得
            var receipts = from n in wrcontext.wrreceipt
                           where n.receipt_id == receiptid
                           select n;

            int i = 0;
            foreach (var q in receipts)
            {
                if (q.receipt_registerd)
                {
                    MessageBox.Show("登録済みです");
                    return;
                }
                email = q.receipt_email;
                textBox_Grade.Text = q.receipt_seller[0].ToString();
                textBox_Class.Text = q.receipt_seller[1].ToString();
                textBox_AttNum.Text = q.receipt_seller.Substring(2, 2);
                textBox_Name.Text = q.receipt_seller_exname;
                if (q.receipt_bumon == 0)
                {
                    label_bumon.Text = "ガラクタ部門";
                }
                else
                {
                    label_bumon.Text = "古本部門";
                }
                i++;
            }
            if (i == 0)
            {

                MessageBox.Show("登録情報がありません");
                return;
            }

            //商品一覧取得
            var rows = (from n in wrcontext.writem
                        where n.item_receipt_id == receiptid
                        select n).ToList();
            dataGridView1.Rows.Clear();
            foreach (var itemdata in rows)
            {
                this.dataGridView1.Rows.Add(
                    itemdata.item_id,
                    itemdata.item_name,
                    itemdata.item_number,
                    itemdata.item_tagprice,
                    itemdata.item_return,
                    null,
                    itemdata.item_comment);
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            if (dataGridView1.RowCount <= 0)
            {
                return;
            }
            button_save.Enabled = false;

            //receipt作成
            string num = textBox_Grade.Text + textBox_Class.Text + textBox_AttNum.Text;
            int receiptid = 0;
            var receipts = from n in context.receipt
                           where n.receipt_seller == num
                           select n;
            foreach (var m in receipts)
            {
                if (m.receipt_seller == Globals.seller_DONATE ||
                    m.receipt_seller == Globals.seller_EXT || m.receipt_seller == Globals.seller_LAGACY)
                {
                    if (m.receipt_seller_exname == textBox_Name.Text)
                    {
                        if (MessageBox.Show(m.receipt_seller + " " + m.receipt_seller_exname + " " +
                                "(" + m.receipt_id.ToString("'R'0000") + ")の票番はすでに存在しています。この票番を開きますか?", "登録確認",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            receiptid = m.receipt_id;
                            break;
                        }
                    }
                }
                else if (MessageBox.Show(m.receipt_seller + " " + m.receipt_seller_exname + " " +
                        "(" + m.receipt_id.ToString("'R'0000") + ")の票番はすでに存在しています。この票番を開きますか?", "登録確認",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    receiptid = m.receipt_id;
                    break;
                }
            }
            if (receiptid == 0)
            {
                var newreceipt = new receipt()
                {
                    receipt_seller = num,
                    receipt_seller_exname = textBox_Name.Text,
                    receipt_time = DateTime.Now,

                };
                if (num == Globals.seller_EXT)
                {
                    newreceipt.receipt_comment = "メールアドレス:" + email;
                }

                context.receipt.InsertOnSubmit(newreceipt);
                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                receiptid = newreceipt.receipt_id;
            }

            //グリッド読み込み
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ItemName"].Value != null)
                {
                    int price;
                    int number;
                    int volume;
                    int.TryParse(row.Cells["ItemNum"].Value.ToString(), out number);
                    int.TryParse(row.Cells["ItemPrice"].Value.ToString(), out price);
                    if (row.Cells["ItemVol"].ValueType == typeof(string))
                    {
                        int.TryParse(row.Cells["ItemVol"].Value.ToString(), out volume);
                    }
                    else
                    {
                        volume = 0;
                    }
                    context.item.InsertOnSubmit(new item()
                    {
                        item_receipt_id = receiptid,
                        item_receipt_time = DateTime.Now,
                        item_name = row.Cells["ItemName"].Value.ToString(),
                        item_number = number,
                        item_tagprice = price,
                        item_return = (bool)(row.Cells["ItemReturn"].Value ?? false),
                        item_volumes = volume,
                        item_comment = (row.Cells["ItemComment"].Value ?? "").ToString(),
                        item_supplement = supplement
                    });
                }
            }
            //最終処理
            try
            {
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                var wrreceipt = from n in wrcontext.wrreceipt
                                where n.receipt_id == int.Parse(textBox_No.Text)
                                select n;
                foreach (var q in wrreceipt)
                {
                    q.receipt_registerd = true;
                }
                wrcontext.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("登録しました(票番:R" + receiptid.ToString() + ")");
            supplement = false;
            label_supplement.Visible = supplement;
            textBox_No.Focus();
            textBox_No.SelectAll();

        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                DialogResult result =
                    MessageBox.Show((row.Index + 1) + "列目を削除してもよろしいですか?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No) return;
                else
                {

                }
                dataGridView1.Rows.Remove(row);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.Button == MouseButtons.Right)
            {
                if (dgv.Rows[e.RowIndex].Selected == false)
                {
                    dgv.ClearSelection();
                    dgv.Rows[e.RowIndex].Selected = true;
                }

                System.Drawing.Rectangle r = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                this.contextMenuStrip_rowHeader.Show(dgv, e.X + r.X, e.Y + r.Y);
            }
        }

        private void キャンセルToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip_rowHeader.Hide();
        }

        private void WebRegister_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.Modifiers & Keys.Control) == Keys.Control && e.KeyCode == Keys.S)
            {
                {
                    string name = dataGridView1.SelectedRows[0].Cells["ItemName"].Value.ToString();
                    if (name.Length > 0)
                    {
                        string result;
                        string result2;
                        TitleSplitForm.Show_Dialog(name, out result);
                        if (result != null && InputBox.Show_Dialog("「" + result + "」の巻数を入力してください", "セット商品支援", "", out result2, ImeMode.Off, HorizontalAlignment.Left)
                            == DialogResult.OK && result2.Length > 0)
                        {
                            name = result + " [" + result2 + "]";
                            dataGridView1.SelectedRows[0].Cells["ItemName"].Value = name;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if ((e.Modifiers & Keys.Control) == Keys.Control && e.KeyCode == Keys.R)
            {
                supplement = !supplement;
                this.label_supplement.Visible = supplement;
            }
        }
    }
}
