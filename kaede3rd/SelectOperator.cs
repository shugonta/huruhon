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
    public partial class SelectOperator : Form
    {
        private int retop_id;

        public SelectOperator()
        {
            InitializeComponent();
            var context = new DBClassDataContext(Globals.ConnectionString);
            bool success = false; ;
            List<@operator> lop = new List<@operator>();

            while (!success)
            {
                try
                {
                    lop = (from n in context.@operator
                           select n).ToList();
                    break;
                }
                catch (Exception ex)
                {
                    if (Globals.ConnectionString.State == ConnectionState.Open) { }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            foreach (@operator op in lop)
            {
                this.listBox1.Items.Add(op.operator_name);
            }

            if (lop.Count == 0)
            {
                MessageBox.Show("先に[機能]→[オペレーターIDを管理]で設定を済ませてください");
            }
        }

        public static DialogResult ShowSelectOperatorDialog(out int op)
        {
            SelectOperator f = new SelectOperator();
            DialogResult res = f.ShowDialog();

            op = f.retop_id;

            f.Dispose();

            return res;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem == null) { return; }
            var context = new DBClassDataContext(Globals.ConnectionString);
            this.textBox1.Text = (context.@operator.Single(n => n.operator_name == (string)this.listBox1.SelectedItem)).operator_id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long opid;
            var context = new DBClassDataContext(Globals.ConnectionString);
            if (long.TryParse(this.textBox1.Text, out opid))
            {
                List<@operator> lop = (from n in context.@operator
                                       where n.operator_id == opid
                                       select n).ToList();
                if (lop.Count == 1)
                {
                    this.retop_id = lop[0].operator_id;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }

            this.textBox1.BackColor = Color.LightPink;
            this.textBox1.Focus();
            this.textBox1.SelectAll();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.button1.PerformClick();
        }
    }
}
