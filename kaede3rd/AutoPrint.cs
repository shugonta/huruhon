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
    public partial class AutoPrint : Form
    {
        bool print_enable;
        List<int> pPrint = new List<int>();

        public AutoPrint()
        {
            InitializeComponent();
            this.Text += ("-" + Globals.Config.bumonnname);
            itemsGridView1.Context = new DBClassDataContext(Globals.ConnectionString);
            check_dia.Checked = Globals.ShowPrintDialog_AtTagPrint;
            ItemsPrintDocument.Printed_Tag_Changed += (_sender, _e) =>
            {
                Invoke(new MethodInvoker(delegate()
                {
                    Refresh_Grid();
                    toolStripStatusLabel_count.Text = string.Format("印刷待機中{0}件", itemsGridView1.Rows.Count);
                }));
            };
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (!print_enable)
            {
                //コントロール類
                numericUpDown_interval.Enabled = false;
                timer_refresh.Interval = (Int32)numericUpDown_interval.Value * 1000;
                timer_refresh.Start();
                button_start.Text = "監視終了";
                toolStripStatusLabel_status.Text = "監視中...";
                print_enable = true;
                //タイマーイベント呼び出し
                timer_refresh_Tick(sender, null);

            }
            else
            {
                //コントロール類
                numericUpDown_interval.Enabled = true;
                timer_refresh.Stop();
                button_start.Text = "監視開始";
                toolStripStatusLabel_status.Text = "監視停止中";
                toolStripStatusLabel_count.Text = "";
                print_enable = false;
            }
        }

        public void Refresh_Grid()
        {
            var list = LoadItem();
            itemsGridView1.Load(list);
            itemsGridView1.AutoResizeColumns();
            toolStripStatusLabel_count.Text = string.Format("印刷待機中{0}件", itemsGridView1.Rows.Count);
        }
        private List<item> LoadItem()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            var list = from n in context.item
                       where n.item_tag_printed == false
                       orderby n.item_id ascending
                       select n;
            return list.ToList();
        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            List<item> items = new List<item>();
            var list = LoadItem();
            itemsGridView1.Load(list);
            itemsGridView1.AutoResizeColumns();
            toolStripStatusLabel_count.Text = string.Format("印刷待機中{0}件", itemsGridView1.Rows.Count);
            if (list.Count() >= numericUpDown_count.Value)
            {
                int count = 0;
                int volume_count = 0;
                bool end = false;
                pPrint.Clear();
                foreach (item data in list)
                {
                    //タグ枚数カウント
                    if (data.item_volumes.HasValue && data.item_volumes >= 2)
                    {
                        count += data.item_volumes.Value;
                        volume_count += data.item_volumes.Value - 1;
                        end = true;
                    }
                    else
                    {
                        count++;
                        end = false;
                    }
                    items.Add(data);
                }

                int n = (count - (count % (int)numericUpDown_count.Value)) / (int)numericUpDown_count.Value;
                foreach (var item in items.Take(n * (int)numericUpDown_count.Value - volume_count))
                {
                    pPrint.Add(item.item_id);
                }

                //最後が分冊ありだった場合
                if (end)
                {
                    pPrint.Remove(pPrint.Last());
                }

                //印刷
                try
                {
                    ItemsPrintDocument.PrintItems(pPrint);
                }
                catch { }
            }

        }

        private void check_dia_CheckedChanged(object sender, EventArgs e)
        {
            Globals.ShowPrintDialog_AtTagPrint = check_dia.Checked;
        }

        private void AutoPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.ShowPrintDialog_AtTagPrint = true;
        }

        private void button_forceprint_Click(object sender, EventArgs e)
        {
            pPrint.Clear();
            var list = LoadItem();
            itemsGridView1.Load(list);
            itemsGridView1.AutoResizeColumns();
            foreach (item data in list)
            {
                pPrint.Add(data.item_id);
            }
            //印刷
            ItemsPrintDocument.PrintItems(pPrint);
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            var list = from n in context.item
                       orderby n.item_id ascending
                       select n;
            foreach (var printeditem_id in pPrint)
            {
                foreach (var item in list)
                {
                    if (item.item_id == printeditem_id)
                    {
                        item.item_tag_printed = false;
                    }
                }
            }
            try
            {
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
