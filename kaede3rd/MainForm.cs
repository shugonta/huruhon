using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kaede3rd
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            using (Login lf = new Login())
            {
                if (lf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.BackColor = Globals.Config.symbolcolor;
            this.Text = Globals.Config.bumonnname;
            this.label_company.Text = Globals.Config.companyname;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        //セルクリック
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) //ボタン行
            {

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Substring(1));
                ReceiptForm form = new ReceiptForm(id);
                form.Show();
            }
        }


        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button_receipt_Click(object sender, EventArgs e)
        {
            ReceiptForm form = new ReceiptForm();
            form.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            dataGridView1.Load(new DBClassDataContext(Globals.ConnectionString));
            //ステータスバー更新
            var context = new DBClassDataContext(Globals.ConnectionString);
            int count = context.item.Count();
            int sellcount = context.item.Count(n => n.item_sellprice.HasValue);
            int sellpricecount = context.item.Sum(n => n.item_sellprice.HasValue ? n.item_sellprice.Value : 0);
            toolStripStatusLabel_count.Text = "商品数:" + count;
            toolStripStatusLabel_sellcount.Text = string.Format("売上:{0}円 ({1}商品)", sellpricecount, sellcount);
        }

        private void 部門設定を変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm form = new ConfigForm();
            form.ShowDialog();
            this.dataGridView1.DefaultCellStyle.BackColor = Globals.Config.symbolcolor;
            this.Text = Globals.Config.bumonnname;
            this.label_company.Text = Globals.Config.companyname;
        }

        private void button_tagprint_Click(object sender, EventArgs e)
        {
            ControlUtil.DGV_ExSelect(this.dataGridView1);
            this.PrintSelections();
        }

        private void PrintSelections()
        {

            var rows = this.dataGridView1.SelectedRows;

            List<int> items = new List<int>();

            if (rows.Count == 0) { return; }
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            for (int i = 0; i < rows.Count; i++)
            {
                var list = from n in context.item
                           where n.item_receipt_id == int.Parse(rows[i].Cells[0].Value.ToString().Substring(1, 4))
                           select n;
                foreach (var item in list)
                {
                    items.Add(item.item_id);
                }
            }
            ItemsPrintDocument.PrintItems(items);
            context.SubmitChanges();
        }

        private void 新Receiptを追加FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_receipt_Click(sender, null);
        }

        private void 最新の情報に更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_refresh_Click(sender, null);
        }

        private void 箱管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxEdit form = new BoxEdit();
            form.Show();
        }

        private void 箱に商品を追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxItem form = new BoxItem();
            form.Show();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void タグ印刷PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_tagprint_Click(sender, null);
        }

        private void ページ設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.EnableMetric = true; //cf. KB814355 et http://dobon.net/vb/dotnet/graphics/pagesetupdialogbug.html
            psd.PageSettings = Globals.pageSettings;
            psd.PrinterSettings = Globals.printerSettings;
            psd.AllowMargins = true;
            psd.ShowDialog();
        }

        private void ログアウトLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Globals.ConnectionString = null;
            using (Login lf = new Login())
            {
                if (lf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            MainForm_Load(sender, null);
            this.Show();
            this.dataGridView1.DefaultCellStyle.BackColor = Globals.Config.symbolcolor;
            this.Text = Globals.Config.bumonnname;
            this.label_company.Text = Globals.Config.companyname;
        }

        private void タグ自動印刷TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoPrint form = new AutoPrint();
            form.Show();
        }

        private void button_all_Click(object sender, EventArgs e)
        {
            ItemsShow form = new ItemsShow();
            form.Show();
        }

        private void タグ再印刷RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RePrint form = new RePrint();
            form.Show();
        }

        private void button_webregist_Click(object sender, EventArgs e)
        {
            WebRegister form = new WebRegister();
            form.Show();
        }

        private void 受付票印刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiptPrint form = new ReceiptPrint();
            form.Show();
        }

        private void オペレーターIDを管理OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperatorList form = new OperatorList();
            form.Show();
        }

        private void 売却ウィンドウSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellForm form = new SellForm();
            form.Show();
        }

        private void 福袋管理FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BagEdit form = new BagEdit();
            form.Show();
        }

        private void 監査ウィンドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KansaForm form = new KansaForm();
            form.Show();
        }

        private void 返金返品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HenkinForm form = new HenkinForm();
            form.Show();
        }

        private void 各部門の返金額合算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GassanForm form = new GassanForm();
            form.Show();
        }
    }
}
