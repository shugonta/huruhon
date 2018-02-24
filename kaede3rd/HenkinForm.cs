using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace kaede3rd
{
    public partial class HenkinForm : Form
    {
        private IEnumerable<IGrouping<string, item>> itemGroup = null;
        private delegate void CellValueSetDelegate(DataGridViewCell cell, object obj);

        public HenkinForm()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DefaultCellStyle.BackColor = Globals.Config.symbolcolor;
            this.dataGridView1.RowTemplate.Height = 20;

            this.RefreshData();
        }

        public void RefreshData()
        {
            var context = new DBClassDataContext(Globals.ConnectionString);
            List<item> items = (from n in context.item
                                select n).ToList();

            this.itemGroup = (from i in items
                              group i by Globals.getSellerString(context.receipt.Single(n => n.receipt_id == i.item_receipt_id).receipt_seller,
                               context.receipt.Single(n => n.receipt_id == i.item_receipt_id).receipt_seller_exname))
                              .OrderByDescending(g => (from i in g where i.item_sellprice.HasValue == false select i).Count());

            this.dataGridView1.Rows.Clear();
            foreach (var g in this.itemGroup)
            {
                DataGridViewRow row = this.dataGridView1.Rows[this.dataGridView1.Rows.Add()];
                row.Cells["ColumnIchiran"].Value = "一覧";
                //出品者取得

                string receipt_seller = context.receipt.Single(n => n.receipt_id == g.First().item_receipt_id).receipt_seller;
                string receipt_seller_exname = context.receipt.Single(n => n.receipt_id == g.First().item_receipt_id).receipt_seller_exname;
                string sellerstring = Globals.getSellerString(receipt_seller, receipt_seller_exname);
                row.Cells["ColumnReceipt"].Value = sellerstring;
                row.Cells["ColumnReceipt"].Tag = Globals.getSellerSortKey(receipt_seller, receipt_seller_exname);
                //売上額
                row.Cells["ColumnSellPrice"].Value = (from i in g where i.item_sellprice.HasValue select i.item_sellprice.Value).Sum(a => (int)a);
                //返品個数
                row.Cells["ColumnReturn"].Value = (from i in g where i.item_sellprice.HasValue == false select i).Count();
            }

            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.VirtualMode = false;
            this.dataGridView1.Enabled = true;
            this.dataGridView1.Focus();
        }


        protected void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Enabled == false) { return; }
            if (this.itemGroup == null) { return; }

            if (e.RowIndex < 0) { return; }
            object shupp = dgv["ColumnReceipt", e.RowIndex].Value;
            if (shupp == null) { return; }

            var grps = from gg in this.itemGroup where gg.Key == (string)shupp select gg;
            if (grps.Count() == 0) { return; }

            var grp = grps.Single();

            if (dgv.Columns[e.ColumnIndex].Name == "ColumnReturn")
            {
                ItemsShow f = new ItemsShow(
                    delegate()
                    {
                        return (from i in grp where i.item_sellprice.HasValue == false select i).ToList();
                    }, grp.Key + "の返品物一覧");
                f.Show();
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "ColumnIchiran")
            {
                ItemsShow f = new ItemsShow(
                    delegate()
                    {
                        return grp.ToList();
                    }, grp.Key + "の出品物一覧");
                f.Show();
            }
        }

        private List<IGrouping<string, item>> getGrpListSelected()
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                return this.itemGroup.ToList();
            }
            else
            {
                var list = new List<IGrouping<string, item>>();

                for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = this.dataGridView1.SelectedRows[i];
                    object shupp = row.Cells["ColumnReceipt"].Value;
                    if (shupp == null) { return null; }

                    var grps = from gg in this.itemGroup where gg.Key == (string)shupp select gg;
                    if (grps.Count() == 0) { return null; }

                    list.Add(grps.Single());
                }

                return list;
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            
            if (this.itemGroup == null) { return; }
            DataGridView dgv = this.dataGridView1;
            if (!dgv.Enabled) { return; }

            var list = this.getGrpListSelected();
            if (list == null) { return; }


            ReturnListPrintDocument.PrintType type;
            ReturnListPrintDocument.SortType sort = ReturnListPrintDocument.SortType.ItemId;
            if (sender == this.button_return_print)
            {
                type = ReturnListPrintDocument.PrintType.Return;
            }
            else if (sender == this.button_meisai_print)
            {
                type = ReturnListPrintDocument.PrintType.MeisaiWithoutReturn;
                if (MessageBox.Show("売価の高い順に並び替えますか？", "明細印刷", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sort = ReturnListPrintDocument.SortType.SellPriceDesc;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }

            PageSetupDialog psd = new PageSetupDialog();
            psd.EnableMetric = true; //cf. KB814355 et http://dobon.net/vb/dotnet/graphics/pagesetupdialogbug.html
            psd.PageSettings = Globals.receipt_pageSettings;
            psd.PrinterSettings = Globals.receipt_printerSettings;
            psd.AllowMargins = false;
            psd.ShowDialog();

            PrintDialog prid = new PrintDialog();
            prid.PrinterSettings = Globals.receipt_printerSettings;
            prid.UseEXDialog = true;


            prid.Document = new ReturnListPrintDocument(list, Globals.receipt_pageSettings,
                Globals.receipt_printerSettings, type, sort);
            DialogResult pdres = prid.ShowDialog();

            if (pdres != DialogResult.OK) { return; }

            PrintPreviewDialog ppp = new PrintPreviewDialog();
            ppp.Document = prid.Document;
            ppp.Show();
            return;

            /*
            try
            {
                prid.Document.Print();
            }
            catch (Exception iex)
            {
                MessageBox.Show("印刷が実行できませんでした: " + iex.ToString());
            }
           */
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private int countHenpinItems(IGrouping<string, item> grp)
        {
            return (from i in grp where i.item_sellprice.HasValue == false select i).Count();
        }

        private void button_csv_Click(object sender, EventArgs e)
        {
            if (this.itemGroup == null) { return; }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Globals.Config.bumonnname + "_返金返品.csv";
            sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            sfd.Filter = "CSVファイル (*.csv)|*.csv";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                using (Stream st = sfd.OpenFile())
                {
                    using (StreamWriter stw = new StreamWriter(st, Encoding.GetEncoding(932)))
                    {
                        stw.WriteLine("出品者,売上額,返品個数");

                        for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                        {
                            var r = this.dataGridView1.Rows[i];
                            stw.Write(((string)r.Cells["ColumnReceipt"].Value).ToCSVString());
                            stw.Write(",");
                            stw.Write(r.Cells["ColumnSellPrice"].Value.ToString());
                            stw.Write(",");
                            stw.Write(r.Cells["ColumnReturn"].Value.ToString());
                            stw.Write("\n");
                        }

                        stw.Close();
                    }
                    st.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.itemGroup == null) { return; }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Globals.Config.bumonnname + "_返品リスト.csv";
            sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            sfd.Filter = "CSVファイル (*.csv)|*.csv";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                var list = this.getGrpListSelected();
                using (Stream st = sfd.OpenFile())
                {
                    using (StreamWriter stw = new StreamWriter(st, Encoding.GetEncoding(932)))
                    {
                        stw.WriteLine(",票番,品番,商品名,定価,返品?");
                        foreach (var g in list)
                        {
                            var its = (from i in g where i.item_sellprice.HasValue == false select i).ToList();
                            if (its.Count == 0) { continue; }

                            stw.WriteLine(g.Key.ToCSVString());

                            long reid = 0;
                            int count = 1;
                            foreach (item it in its)
                            {
                                stw.Write(count.ToString());
                                stw.Write(",");
                                if (reid != it.item_receipt_id)
                                {
                                    stw.Write("R" + it.item_receipt_id.ToString("0000"));
                                    reid = it.item_receipt_id;
                                }
                                stw.Write(",");
                                stw.Write(it.item_id.ToString("00000"));
                                stw.Write(",");
                                stw.Write(it.item_name.ToCSVString());
                                stw.Write(",");
                                stw.Write(it.item_tagprice.ToString());
                                stw.Write(",");
                                if (it.item_return == true)
                                {
                                    stw.Write("返品");
                                }
                                stw.Write("\n");
                                count++;
                            }
                            stw.Write("\n");
                        }

                        stw.Close();
                    }
                    st.Close();
                }
            }
        }



    }
}
