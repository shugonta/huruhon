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
    public partial class ItemsShow : Form
    {
        public delegate List<item> ItemReturnDelegate();
        private ItemReturnDelegate itemReturner;
        public List<item> itemList;
        public ItemsShow()
        {
            InitializeComponent();
            this.itemsGridView1.Context = new DBClassDataContext(Globals.ConnectionString);
            itemList = RefreshList();
            this.itemsGridView1.Load(itemList);
        }

        public ItemsShow(bool load)
        {
            if (!load)
            {
                InitializeComponent();
                this.itemsGridView1.Context = new DBClassDataContext(Globals.ConnectionString);
            }
        }

        public ItemsShow(ItemReturnDelegate returner, string windowTitle)
        {
            InitializeComponent();
            itemReturner = returner;
            this.itemsGridView1.Context = new DBClassDataContext(Globals.ConnectionString);
            this.itemsGridView1.Load(returner());

        }

        private void ItemsShow_Load(object sender, EventArgs e)
        {
            itemsGridView1.AutoResizeColumns();
        }

        virtual public List<item> RefreshList()
        {
            if (itemReturner == null)
            {
                return (from n in new DBClassDataContext(Globals.ConnectionString).item
                        select n).ToList();
            }
            else
            {
                return itemReturner();
            }
        }


        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            int id = -1;
            int.TryParse(textBox_search.Text, out id);
            List<item> search;
            if (checkBox_regex.Checked)
            {
                return;
            }
            else
            {
                search = (from n in itemList
                          where (n.item_name.Contains(textBox_search.Text) || n.item_id == id)
                          select n).ToList();
            }
            itemsGridView1.Load(search);
            itemsGridView1.AutoResizeColumns();
        }
        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<item> search;
                System.Text.RegularExpressions.Regex searchTerm =
                    new System.Text.RegularExpressions.Regex(textBox_search.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                search = (from n in itemList
                          let matches = searchTerm.Matches(n.item_name)
                          where matches.Count > 0
                          select n).ToList();
                itemsGridView1.Load(search);
                itemsGridView1.AutoResizeColumns();
            }
        }

        private void ItemsShow_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button_refresh_Click(object sender, EventArgs e)
        {
            itemList = RefreshList();
            this.itemsGridView1.Load(itemList);
            itemsGridView1.AutoResizeColumns();
        }


    }
}
