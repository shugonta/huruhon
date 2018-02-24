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
    public partial class RePrint : Form
    {
        List<item> itemList;
        IQueryable<item> source;
        public RePrint()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            InitializeComponent();
            source = from n in context.item
                     where n.item_tag_printed == true
                     select n;
            this.itemsGridView1.Context = context;
            itemList = source.ToList();
            this.itemsGridView1.Load(itemList);
        }


        private void RePrint_Load(object sender, EventArgs e)
        {
            itemsGridView1.AutoResizeColumns();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            int id = -1;
            int.TryParse(textBox_search.Text, out id);
            var search = from n in itemList
                         where (n.item_name.Contains(textBox_search.Text) || n.item_id == id)
                         select n;
            itemsGridView1.Load(search.ToList());
            itemsGridView1.AutoResizeColumns();
        }

        private void button_refresh_Click(object sender, EventArgs e)

        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            var rows = itemsGridView1.SelectedRows;
            if (itemsGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    int id = int.Parse(rows[i].Cells[0].Value.ToString());
                    var list = from n in context.item
                               where n.item_id == id
                               select n;
                    foreach (var item in list)
                    {
                        item.item_tag_printed = false;
                    }

                }
                try
                {
                    context.SubmitChanges();
                    MessageBox.Show("再印刷登録しました");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("登録する行を選択してください");
            }
        }
    }
}
