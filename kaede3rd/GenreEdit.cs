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
    public partial class GenreEdit : Form
    {
        public GenreEdit()
        {
            InitializeComponent();
            Item_Load();
        }

        private void Item_Load()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            var list = from n in context.genre
                       orderby n.genre_id ascending
                       select n;
            listBox_genre.Items.Clear();
            foreach (genre data in list)
            {
                listBox_genre.Items.Add(data.genre_name);
            }
        }

        private void Add()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    var list = from n in context.genre
                               where n.genre_name == textBox1.Text
                               select n;
                    genre data = new genre { genre_name = textBox1.Text };
                    context.genre.InsertOnSubmit(data);
                    context.SubmitChanges();
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Edit()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            try
            {
                var data = (from n in context.genre
                            where n.genre_name == listBox_genre.SelectedItem.ToString()
                            select n).First();
                data.genre_name = textBox1.Text;
                context.SubmitChanges();
                textBox1.Text = "";
                listBox_genre.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Delete()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            if (listBox_genre.SelectedIndex >= 0)
            {
                try
                {
                    var data = (from n in context.genre
                                where n.genre_name == listBox_genre.SelectedItem.ToString()
                                select n).First();
                    context.genre.DeleteOnSubmit(data);
                    context.SubmitChanges();
                    textBox1.Text = "";
                    listBox_genre.ClearSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            if (button_add.Text == "追加")
            {
                Add();
            }
            else
            {
                Edit();
            }
            Item_Load();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            Delete();
            Item_Load();
        }

        private void listBox_genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_genre.SelectedIndex >= 0)
            {
                textBox1.Text = listBox_genre.SelectedItem.ToString();
                button_add.Text = "変更";
            }
            else
            {
                button_add.Text = "追加";
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
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

            System.Threading.Thread t = new System.Threading.Thread(
                (delegate()
                {
                    prid.Document = new GenrePrintDocument(genreid, Globals.receipt_pageSettings, Globals.receipt_printerSettings);
                    prid.Document.Print();
                }));
            t.Start();
        }



    }
}
