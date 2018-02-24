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
    public partial class BoxItem : Form
    {
        private DBClassDataContext context;
        box box_data;
        int genre;
        int item_id;
        int? pgenre;
        int? pboxid;
        List<int> selection;

        public BoxItem()
        {
            InitializeComponent();
            context = new DBClassDataContext(Globals.ConnectionString);
            selection = new List<int>();
            Data_Load();
        }

        private void Data_Load()
        {
            var list = from n in context.genre
                       select n;
            foreach (var item in list)
            {
                list_genre.Items.Add(item.genre_name);
                selection.Add(-1);
            }
        }

        private void list_genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (from n in context.genre
                        where n.genre_name == list_genre.SelectedItem.ToString()
                        select n).First();
            genre = item.genre_id;
            var boxlist = from m in context.box
                          where m.box_genre == item.genre_id || m.box_genre == null
                          select m;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            foreach (var i in boxlist)
            {
                comboBox1.Items.Add(i.box_id);
            }
            int index;
            index = selection[list_genre.SelectedIndex];
            if (index < 0) index = comboBox1.Items.Count - 1;
            comboBox1.SelectedIndex = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            context.box.InsertOnSubmit(new box { box_genre = genre });
            try
            {
                context.SubmitChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            list_genre_SelectedIndexChanged(sender, null);
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection[list_genre.SelectedIndex] = comboBox1.SelectedIndex;
            if (comboBox1.SelectedIndex >= 0)
            {
                textBox1.Enabled = true;
                box_data = (from n in context.box
                            where n.box_id == (int)comboBox1.SelectedItem
                            select n).First();
                label_comment.Text = box_data.box_comment;
                label_count.Text = Box_Item_Count().ToString();
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = this.textBox1.Text;
                if (s == null) { return; }

                int shinaBan;

                if (Globals.TryParseBarcode(s, out shinaBan))
                {
                }
                else
                {
                    if (!int.TryParse(this.textBox1.Text, out shinaBan))
                    {
                        MessageBox.Show("不明な文字列です");
                        return;
                    }
                }

                if (!(0 <= shinaBan && shinaBan <= 999999))
                {
                    MessageBox.Show("不正な品番です");
                    return;
                }
                button_cancel.Enabled = true;
                textBox1.Text = shinaBan.ToString();
                textBox1.SelectAll();

                //データベースアクセス
                try
                {
                    var data = (from n in context.item
                                where n.item_id == shinaBan
                                select n).First();
                    label_name.Text = data.item_name;
                    pboxid = data.item_box_id;
                    pgenre = data.item_genre;
                    data.item_box_id = box_data.box_id;
                    data.item_genre = genre;
                    item_id = data.item_id;
                    context.SubmitChanges();
                    label_count.Text = Box_Item_Count().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BoxItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (list_genre.SelectedIndex > 0)
                {
                    list_genre.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (list_genre.SelectedIndex < list_genre.Items.Count - 1)
                {
                    list_genre.SelectedIndex++;
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (from n in context.item
                            where n.item_id == item_id
                            select n).First();
                data.item_box_id = pboxid;
                data.item_genre = pgenre;
                context.SubmitChanges();
                button_cancel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int Box_Item_Count()
        {
            int count = (from n in context.item
                         where n.item_box_id == box_data.box_id
                         select n).Count();
            return count;
        }
    }
}
