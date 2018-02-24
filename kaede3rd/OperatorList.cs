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
    public partial class OperatorList : Form
    {
        public OperatorList()
        {
            InitializeComponent();
            LoadOperator();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadOperator();
        }

        private void LoadOperator()
        {
            dataGridView1.Rows.Clear();
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            var list = from n in context.@operator
                       select n;
            foreach (var q in list)
            {
                this.dataGridView1.Rows.Add(
                    q.operator_id,
                    q.operator_name,
                    q.operator_comment
                    );
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string value;
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                return;
            }
            else
            {
                value = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }

            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            int id;
            @operator operator_item;
            if (int.TryParse((this.dataGridView1.Rows[e.RowIndex].Cells["OperatorId"].Value??"").ToString(), out id))
            {
                operator_item = context.@operator.Single(n => n.operator_id == id);
            }
            else
            {
                operator_item = new @operator();
                context.@operator.InsertOnSubmit(operator_item);

            }
            switch (e.ColumnIndex)
            {
                case 1:
                    operator_item.operator_name = value;
                    break;
                case 2:
                    operator_item.operator_comment = value;
                    break;
            }
            try
            {
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadOperator();
        }
    }
}
