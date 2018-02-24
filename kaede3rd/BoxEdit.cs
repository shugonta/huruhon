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
    public partial class BoxEdit : Form
    {
        private DBClassDataContext context;

        public BoxEdit()
        {
            InitializeComponent();
            context = new DBClassDataContext(Globals.ConnectionString);
            Data_Load();
        }

        private void Data_Load()
        {
            var list = from n in context.box
                       select n;
            Box_list.Items.Clear();
            foreach (var item in list)
            {
                Box_list.Items.Add(item.box_id);
            }
        }

        private void Box_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Box_list.SelectedIndex >= 0)
            {
                try
                {
                    var item = (from n in context.box
                                where n.box_id == (int)Box_list.SelectedItem
                                select n).First();
                    if (item.box_genre > 0)
                    {
                        label_genre.Text = (from m in context.genre
                                            where m.genre_id == item.box_genre
                                            select m).First().genre_name;
                    }
                    else { label_genre.Text = ""; }
                    text_comment.Text = item.box_comment;
                    text_count.Text = (from o in context.item
                                       where o.item_box_id == item.box_id
                                       select o).Count().ToString();
                }
                catch
                {

                }
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            BoxItem form = new BoxItem();
            form.Show();
        }

        private void button_allitem_Click(object sender, EventArgs e)
        {
            if (Box_list.SelectedIndex >= 0)
            {
                BoxItemShow form = new BoxItemShow((int)Box_list.SelectedItem);
                form.Show();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (Box_list.SelectedIndex >= 0)
            {
                try
                {
                    var item = (from n in context.box
                                where n.box_id == (int)Box_list.SelectedItem
                                select n).First();
                    context.box.DeleteOnSubmit(item);
                    Box_list.Items.RemoveAt(Box_list.SelectedIndex);
                    context.SubmitChanges();
                }
                catch
                {

                }
            }
        }

        private void button_list_print_Click(object sender, EventArgs e)
        {
            if (Box_list.SelectedIndex < 0) { return; }
            int boxid = (Int32)Box_list.SelectedItem;
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
                    prid.Document = new BoxPrintDocument(boxid, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                    prid.Document.Print();
                }));
            t.Start();
        }

        private void text_comment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Box_list.SelectedIndex >= 0)
            {
                var item = (from n in context.box
                            where n.box_id == (int)Box_list.SelectedItem
                            select n).First();
                item.box_comment = text_comment.Text;
                context.SubmitChanges();
                e.SuppressKeyPress = true;
            }
        }
    }
}
