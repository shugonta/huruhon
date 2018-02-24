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
    public partial class ReceiptForm : Form
    {
        int receipt_id = -1;
        public ReceiptForm()
        {
            InitializeComponent();
            this.itemsGridView1.Context = new DBClassDataContext(Globals.ConnectionString);

            textBox_num.Text = "新規";
            this.Text = "受付票: 新規（" + Globals.Config.bumonnname + "）";
        }

        public ReceiptForm(int receiptid)
        {
            InitializeComponent();
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            this.itemsGridView1.Context = new DBClassDataContext(Globals.ConnectionString);
            ReceiptOpen(receiptid, context);
        }

        public void ReceiptOpen(int receiptid, DBClassDataContext context)
        {
            var receipt_data = (from n in context.receipt
                                where n.receipt_id == receiptid
                                select n).First();
            this.text_external.Text = receipt_data.receipt_seller_exname;
            if (receipt_data.receipt_seller == Globals.seller_EXT) radio_external.Checked = true;
            else if (receipt_data.receipt_seller == Globals.seller_DONATE) radio_donate.Checked = true;
            else if (receipt_data.receipt_seller == Globals.seller_LAGACY) radio_legacy.Checked = true;
            else
            {
                this.text_zai_ban.Text = receipt_data.receipt_seller.Substring(2, 2);
                this.text_zai_kumi.Text = receipt_data.receipt_seller.Substring(1, 1);
                this.text_zai_nen.Text = receipt_data.receipt_seller.Substring(0, 1);
            }
            textBox_num.Text = receiptid.ToString("'R'0000");
            this.Text = "受付票: " + receiptid.ToString("'R'0000") + "（" + Globals.Config.bumonnname + "）";
            receipt_id = receiptid;
            Globals.ConnectionString.Close();
            itemsGridView1.Load(receiptid);
            itemsGridView1.Columns["Items_receipt_id"].Visible = false;
            itemsGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            itemsGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            string classname = "";
            receipt newreceipt;
            string name = text_external.Text;
            if (radio_zaigaku.Checked)
            {
                if ((text_zai_nen.Text == "1" || text_zai_nen.Text == "2" || text_zai_nen.Text == "3") &&
                    (text_zai_kumi.Text == "1" || text_zai_kumi.Text == "2" || text_zai_kumi.Text == "3" || text_zai_kumi.Text == "4"
                    || text_zai_kumi.Text == "A" || text_zai_kumi.Text == "B" || text_zai_kumi.Text == "C"))
                {
                    classname = text_zai_nen.Text + text_zai_kumi.Text + text_zai_ban.Text.PadLeft(2, '0');
                }
                else
                {
                    MessageBox.Show("入力文字が不正です");
                    return;
                }

            }
            else if (radio_external.Checked)
            {
                classname = Globals.seller_EXT;
                name = text_external.Text;
            }
            else if (radio_legacy.Checked)
            {
                classname = Globals.seller_LAGACY;
            }
            else if (radio_donate.Checked)
            {
                classname = Globals.seller_DONATE;
            }

            if (receipt_id == -1)
            {
                IQueryable<receipt> samelist;
                //同じ番号の票番検索
                if (classname == Globals.seller_DONATE || classname == Globals.seller_EXT || classname == Globals.seller_LAGACY)
                {
                    samelist = from n in context.receipt
                               where n.receipt_seller == classname
                               where n.receipt_seller_exname == name
                               select n;
                }
                else
                {
                    samelist = from n in context.receipt
                               where n.receipt_seller == classname
                               select n;
                }
                foreach (var receipt in samelist)
                {
                    if (MessageBox.Show(receipt.receipt_seller + " " + receipt.receipt_seller_exname + " " +
                        "(" + receipt.receipt_id.ToString("'R'0000") + ")の票番はすでに存在しています。この票番を開きますか?", "登録確認",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ReceiptOpen(receipt.receipt_id, context);
                        return;
                    }
                }

                //追加
                newreceipt = new receipt { receipt_seller = classname, receipt_seller_exname = name, receipt_time = DateTime.Now };
                context.receipt.InsertOnSubmit(newreceipt);
                try
                {
                    context.SubmitChanges();
                    ReceiptOpen(newreceipt.receipt_id, context);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //変更
                var data = (from n in context.receipt
                            where n.receipt_id == receipt_id
                            select n).First();
                data.receipt_seller = classname;
                data.receipt_seller_exname = name;
                try
                {
                    context.SubmitChanges();
                    itemsGridView1.Load(receipt_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void text_zai_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).Focus();
            ((MaskedTextBox)sender).SelectAll();
        }

        private void text_zai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((MaskedTextBox)sender, true, true, true, true);
            }
        }

        private void text_external_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void 商品追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (receipt_id > 0)
            {
                AddItem form = new AddItem(receipt_id);
                form.Show();
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            if (radio == radio_zaigaku)
            {
                this.text_zai_ban.Enabled = true;
                this.text_zai_kumi.Enabled = true;
                this.text_zai_nen.Enabled = true;
            }
            else
            {
                this.text_zai_ban.Enabled = false;
                this.text_zai_kumi.Enabled = false;
                this.text_zai_nen.Enabled = false;
            }
        }

        private void itemsGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void タグを印刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            List<int> items = new List<int>();
            for (int i = 0; i < this.itemsGridView1.SelectedRows.Count; i++)
            {
                DataGridViewRow row = this.itemsGridView1.SelectedRows[i];

                if (row.Cells[0].Value == null)
                {
                }
                else
                {
                    var data = (from n in context.item
                                where n.item_id == (Int32)row.Cells[0].Value
                                select n).First();
                    items.Add(data.item_id);
                }
            }
            items.Sort();
            ItemsPrintDocument.PrintItems(items);
        }

        private void 受付票を印刷PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (receipt_id <= 0) { return; }
            DataGridView dgv = this.itemsGridView1;
            if (!dgv.Enabled) { return; }


            PageSetupDialog psd = new PageSetupDialog();
            psd.EnableMetric = true; //cf. KB814355 et http://dobon.net/vb/dotnet/graphics/pagesetupdialogbug.html
            psd.PageSettings = Globals.receipt_pageSettings;
            psd.PrinterSettings = Globals.receipt_printerSettings;
            psd.AllowMargins = false;
            psd.ShowDialog();

            PrintDialog prid = new PrintDialog();
            prid.PrinterSettings = Globals.receipt_printerSettings;
            prid.UseEXDialog = true;
            DialogResult pdres = prid.ShowDialog();
            if (pdres != DialogResult.OK) { return; }

            System.Threading.Thread t = new System.Threading.Thread(
                (delegate()
                {
                    prid.Document = new ReceiptPrintDocument(receipt_id, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                    prid.Document.Print();
                }));
            t.Start();
        }

        private void ReceiptForm_KeyDown(object sender, KeyEventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            if (receipt_id > 0)
            {
                var receipt_data = (from n in context.receipt
                                    where n.receipt_id == receipt_id
                                    select n).First();
                string curcom = receipt_data.receipt_comment;
                //コメント入力
                if (e.Alt && e.Control && e.KeyCode == Keys.C)
                {
                    string comment;
                    if (DialogResult.OK == InputBox.Show_Dialog("コメントを入力してください", "コメント入力",
                        curcom, out comment, ImeMode.On, HorizontalAlignment.Left))
                    {
                        receipt_data.receipt_comment = comment;
                        context.SubmitChanges();
                    }

                }
            }
        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemsGridView1.Delete();
        }

        private void ReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (itemsGridView1.notsaved)
            {
                e.Cancel = true;
                itemsGridView1.SubmitCellChange_Completed += (_sender, _e) =>
                {
                    Invoke(new MethodInvoker(delegate()
                    {
                        this.Close();
                    }));
                };
                itemsGridView1.SubmitCellChange();
            }
        }


    }
}
