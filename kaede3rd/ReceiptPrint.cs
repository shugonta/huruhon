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
    public partial class ReceiptPrint : Form
    {
        public ReceiptPrint()
        {
            InitializeComponent();
        }
        private int maximamid;
        private void ReceiptPrint_Load(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            var genrelist = from n in context.genre
                            select n;
            foreach (var genre in genrelist)
            {
                listBox_genre.Items.Add(genre.genre_name);
            }
            int itemlastid = (from n in context.item
                              orderby n.item_id descending
                              select n).First().item_id;
            maximamid = itemlastid;
            numericUpDown1.Maximum = itemlastid;
            numericUpDown2.Maximum = itemlastid;
            numericUpDown2.Value = itemlastid;
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            if (listBox_genre.SelectedIndex < 0) { return; }
            var data = (from n in context.genre
                        where n.genre_name == listBox_genre.SelectedItem.ToString()
                        select n);
            int genreid = -1;
            foreach (var item in data)
            {
                genreid = item.genre_id;
            }
            if (genreid <= 0) return;
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
            System.Threading.Thread t;
            if (checkBox_id.Checked || checkBox_date.Checked || textBox_search.Text.Length > 0)
            {
                int id1;
                int id2;
                DateTime date1;
                DateTime date2;
                if (checkBox_id.Checked)
                {
                    id1 = (int)numericUpDown1.Value;
                    id2 = (int)numericUpDown2.Value;
                }
                else
                {
                    id1 = 1;
                    id2 = maximamid;
                }
                if (checkBox_date.Checked)
                {
                    date1 = dateTimePicker1.Value.Date;
                    date2 = dateTimePicker2.Value.Date;
                    t = new System.Threading.Thread(
                   (delegate()
                     {
                         prid.Document = new GenrePrintDocument(genreid, id1, id2, date1, date2, textBox_search.Text, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                         prid.Document.Print();

                     }));
                    t.Start();
                }
                else
                {
                    t = new System.Threading.Thread(
                       (delegate()
                       {
                           prid.Document = new GenrePrintDocument(genreid, id1, id2, null, null, textBox_search.Text, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                           prid.Document.Print();
                       }));
                    t.Start();
                }
            }
            else
            {
                t = new System.Threading.Thread(
                    (delegate()
                    {
                        prid.Document = new GenrePrintDocument(genreid, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                        prid.Document.Print();
                    }));
                t.Start();
            }
        }

        private void checkBox_id_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_id.Checked)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        private void checkBox_date_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_date.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void button_allbox_print_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            if (listBox_genre.SelectedIndex < 0) { return; }
            var data = (from n in context.genre
                        where n.genre_name == listBox_genre.SelectedItem.ToString()
                        select n);
            int genreid = -1;
            foreach (var item in data)
            {
                genreid = item.genre_id;
            }
            if (genreid <= 0) return;
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
            System.Threading.Thread t;
            if (checkBox_id.Checked || checkBox_date.Checked || textBox_search.Text.Length > 0)
            {
                int id1;
                int id2;
                DateTime date1;
                DateTime date2;
                if (checkBox_id.Checked)
                {
                    id1 = (int)numericUpDown1.Value;
                    id2 = (int)numericUpDown2.Value;
                }
                else
                {
                    id1 = 1;
                    id2 = maximamid;
                }
                if (checkBox_date.Checked)
                {
                    date1 = dateTimePicker1.Value.Date;
                    date2 = dateTimePicker2.Value.Date;
                    t = new System.Threading.Thread(
                   (delegate()
                   {
                       prid.Document = new AllBoxPrintDocument(genreid, id1, id2, date1, date2, textBox_search.Text, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                       prid.Document.Print();

                   }));
                    t.Start();
                }
                else
                {
                    t = new System.Threading.Thread(
                       (delegate()
                       {
                           prid.Document = new AllBoxPrintDocument(genreid, id1, id2, null, null, textBox_search.Text, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                           prid.Document.Print();
                       }));
                    t.Start();
                }
            }
            else
            {
                t = new System.Threading.Thread(
                    (delegate()
                    {
                        prid.Document = new AllBoxPrintDocument(genreid, 0, maximamid, null, null, "", Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                        prid.Document.Print();
                    }));
                t.Start();
            }
        }
    }
}
