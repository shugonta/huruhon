using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Windows.Forms;
using System.Windows;

namespace kaede3rd
{
    class ReceiptGridView : DataGridView
    {
        public System.Windows.Forms.DataGridViewButtonColumn Receipt_id;
        public System.Windows.Forms.DataGridViewTextBoxColumn Receipt_name_class;
        public System.Windows.Forms.DataGridViewTextBoxColumn Receipt_name;
        public System.Windows.Forms.DataGridViewTextBoxColumn Receipt_date;
        public System.Windows.Forms.DataGridViewTextBoxColumn Receipt_comment;

        public ReceiptGridView()
        {
            // 
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Receipt_id = new DataGridViewButtonColumn();
            Receipt_name_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Receipt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Receipt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Receipt_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }
        public void Load(DBClassDataContext context)
        {
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Receipt_id,
            this.Receipt_name_class,
            this.Receipt_name,
            this.Receipt_date,
            this.Receipt_comment});
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.ReadOnly = true;
            this.RowTemplate.Height = 21;
            this.TabIndex = 1;

            // Receipt_id
            // 
            this.Receipt_id.HeaderText = "票番";
            this.Receipt_id.Name = "Receipt_id";
            this.Receipt_id.ReadOnly = true;
            this.Receipt_id.SortMode = DataGridViewColumnSortMode.Automatic;
            this.Receipt_id.Width = 40;
            // 
            // Receipt_name_class
            // 
            this.Receipt_name_class.HeaderText = "クラス";
            this.Receipt_name_class.Name = "Receipt_name_class";
            this.Receipt_name_class.ReadOnly = true;
            this.Receipt_name_class.Width = 61;
            // 
            // Receipt_name
            // 
            this.Receipt_name.HeaderText = "出品者";
            this.Receipt_name.Name = "Receipt_name";
            this.Receipt_name.ReadOnly = true;
            this.Receipt_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Receipt_name.Width = 72;
            // 
            // Receipt_date
            // 
            this.Receipt_date.HeaderText = "受付日時";
            this.Receipt_date.Name = "Receipt_date";
            this.Receipt_date.ReadOnly = true;
            this.Receipt_date.Width = 85;
            // 
            // Receipt_comment
            // 
            this.Receipt_comment.HeaderText = "コメント";
            this.Receipt_comment.Name = "Receipt_comment";
            this.Receipt_comment.ReadOnly = true;
            this.Receipt_comment.Width = 70;
            this.Rows.Clear();

            if (context != null)
            {
                var list = from n in context.receipt
                           select n;
                foreach (var q in list)
                {
                    string classname;
                    string receipt_seller = q.receipt_seller;
                    //クラス判別
                    if (receipt_seller[0] != '9')
                    {
                        classname = string.Format("{0}年{1}組{2}番", receipt_seller[0], receipt_seller[1], receipt_seller.Substring(2));
                    }
                    else
                    {
                        if (receipt_seller[2] == '9') classname = "外部";
                        else if (receipt_seller[3] == '1') classname = "遺産";
                        else if (receipt_seller[3] == '2') classname = "寄付";
                        else classname = "その他";
                    }
                    //追加
                    this.Rows.Add(new object[]{
                            q.receipt_id.ToString("'R'0000"),
                            classname,
                            q.receipt_seller_exname,
                            q.receipt_time,
                            q.receipt_comment
                        });
                }

            }
        }
    }

    public class ItemsGridView : DataGridView
    {
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_id;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_name;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_receipt_id;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_price;
        public System.Windows.Forms.DataGridViewCheckBoxColumn Items_isReturn;
        public System.Windows.Forms.DataGridViewCheckBoxColumn Items_tag_printed;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_receipt_date;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_volume;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_boxid;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_comment;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_sell_price;
        public System.Windows.Forms.DataGridViewTextBoxColumn Items_sell_date;
        public DBClassDataContext Context { get; set; }
        public int ReceiptID { get; set; }
        private item newitem;
        private object pValue;
        public bool notsaved = false;
        private int pRow = -1;
        private bool edited = false;
        public event DataGridViewCellEventHandler Submit_Completed;
        public event EventHandler SubmitCellChange_Completed;
        public ItemsGridView()
        {
            // 
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AutoGenerateColumns = false;
            Items_id = new DataGridViewTextBoxColumn();
            Items_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_receipt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_isReturn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Items_tag_printed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Items_receipt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_boxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_sell_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Items_sell_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CellBeginEdit += new DataGridViewCellCancelEventHandler(ItemsGridView_CellBeginEdit);
            this.CellEndEdit += new DataGridViewCellEventHandler(ItemsGridView_CellEndEdit);
            this.RowLeave += new DataGridViewCellEventHandler(ItemsGridView_RowLeave);
            this.RowEnter += new DataGridViewCellEventHandler(ItemsGridView_RowEnter);
            this.Leave += new EventHandler(ItemsGridView_Leave);
            this.UserDeletingRow += new DataGridViewRowCancelEventHandler(ItemsGridView_UserDeletingRow);
            this.UserDeletedRow += new DataGridViewRowEventHandler(ItemsGridView_UserDeletedRow);

        }

        void ItemsGridView_Leave(object sender, EventArgs e)
        {
            EndEdit();
            SubmitCellChange();
        }

        public void SubmitCellChange()
        {
            OnRowLeave(new DataGridViewCellEventArgs(SelectedCells[0].ColumnIndex, SelectedCells[0].RowIndex));
            OnRowEnter(null);
            DataGridViewCellEventHandler handler = new DataGridViewCellEventHandler((sender, e) => { });
            handler = (sender, e) =>
            {
                if (SubmitCellChange_Completed != null)
                {
                    this.Submit_Completed -= handler;
                    SubmitCellChange_Completed(this, null);
                }
            };
            this.Submit_Completed += handler;
        }

        void ItemsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show((e.Row.Index + 1) + "列目を削除してもよろしいですか?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No) e.Cancel = true;
        }

        void ItemsGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int id = Convert.ToInt32(e.Row.Cells["Items_id"].Value);
            if (id > 0)
            {
                var list = from n in Context.item
                           where n.item_id == id
                           select n;
                foreach (item q in list)
                {
                    Context.item.DeleteOnSubmit(q);
                }
                try
                {
                    Context.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict occ in Context.ChangeConflicts)
                    {
                        occ.Resolve(RefreshMode.KeepCurrentValues);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }

        void ItemsGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (pRow >= 0 && edited)
            {
                //LINQクラスに変更を適用
                DataGridViewCellCollection cell = this.Rows[pRow].Cells;
                int id = Convert.ToInt32(cell["Items_id"].Value);
                if (id > 0)
                {
                    var list = from n in Context.item
                               where n.item_id == id
                               select n;
                    foreach (item q in list)
                    {
                        q.item_name = Convert.ToString(cell["Items_name"].Value);
                        q.item_tagprice = Convert.ToInt32(cell["Items_price"].Value);
                        q.item_return = Convert.ToBoolean(cell["Items_isReturn"].Value);
                        q.item_tag_printed = Convert.ToBoolean(cell["Items_tag_printed"].Value);
                        if (cell["Items_boxid"].Value == null) q.item_box_id = null;
                        else q.item_box_id = Convert.ToInt32(cell["Items_boxid"].Value);
                        if (cell["Items_volume"].Value == null) q.item_volumes = null;
                        else q.item_volumes = Convert.ToInt32(cell["Items_volume"].Value);
                        if (cell["Items_comment"].Value == null) q.item_comment = null;
                        else q.item_comment = Convert.ToString(cell["Items_comment"].Value);
                        if (cell["Items_sell_price"].Value == null) q.item_sellprice = null;
                        else q.item_sellprice = Convert.ToInt32(cell["Items_sell_price"].Value);
                        newitem = q;
                    }
                }

                else
                {
                    item q = new item();
                    q.item_name = Convert.ToString(cell["Items_name"].Value);
                    q.item_tagprice = Convert.ToInt32(cell["Items_price"].Value);
                    q.item_return = Convert.ToBoolean(cell["Items_isReturn"].Value);
                    q.item_tag_printed = Convert.ToBoolean(cell["Items_tag_printed"].Value);
                    q.item_receipt_id = this.ReceiptID;
                    q.item_receipt_time = DateTime.Now;
                    if (cell["Items_boxid"].Value == null) q.item_box_id = null;
                    else q.item_box_id = Convert.ToInt32(cell["Items_boxid"].Value);
                    if (cell["Items_volume"].Value == null) q.item_volumes = null;
                    else q.item_volumes = Convert.ToInt32(cell["Items_volume"].Value);
                    if (cell["Items_comment"].Value == null) q.item_comment = null;
                    else q.item_comment = Convert.ToString(cell["Items_comment"].Value);
                    if (cell["Items_sell_price"].Value == null) q.item_sellprice = null;
                    else q.item_sellprice = Convert.ToInt32(cell["Items_sell_price"]);
                    //追加
                    try
                    {
                        Context.item.InsertOnSubmit(q);
                    }
                    catch (Exception ex)
                    {
                        if (DialogResult.Retry == MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.RetryCancel))
                        {
                            Context.item.InsertOnSubmit(q);
                        }
                    }
                    newitem = q;
                }
                //登録
                SubmitChange_Start();
            }
            notsaved = false;

        }

        void SubmitChange_Start()
        {
            System.Threading.Thread t = new System.Threading.Thread(SubmitChange_Method);
            t.Start();
        }

        void SubmitChange_Method()
        {
            bool s = true;
            while (s)
            {
                try
                {
                    Context.SubmitChanges();
                    s = false;
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict occ in Context.ChangeConflicts)
                    {
                        occ.Resolve(RefreshMode.KeepCurrentValues);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "SubmitChanges の呼び出し中は、その操作を実行できません。")
                    {
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            if (DialogResult.Retry != MessageBox.Show(ex.Message, "再試行しますか?", MessageBoxButtons.RetryCancel))
                            {
                                s = false;
                            }
                        }));
                    }
                }
            }

            this.Invoke(new MethodInvoker(delegate
            {
                if (pRow > 0)
                {
                    this.Rows[pRow].Cells["Items_id"].Value = newitem.item_id;
                    this.Rows[pRow].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }));
            edited = false;
            notsaved = false;
            if (Submit_Completed != null)
            {
                Submit_Completed(this, new DataGridViewCellEventArgs(this.Rows[pRow].Cells[0].ColumnIndex, this.Rows[pRow].Cells[0].RowIndex));
            }
            newitem = null;
            pRow = -1;
        }

        void ItemsGridView_LostFocus(object sender, EventArgs e)
        {

        }


        void ItemsGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            pRow = e.RowIndex;
        }

        void ItemsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            notsaved = true;
            pValue = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            this.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
        }

        void ItemsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != pValue)
            {
                edited = true;
            }
            this.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
            pValue = null;
        }

        public void Load(List<item> data)
        {
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items_id,
            this.Items_name,
            this.Items_receipt_id,
            this.Items_price,
            this.Items_isReturn,
            this.Items_tag_printed,
            this.Items_receipt_date,
            this.Items_volume,
            this.Items_boxid,
            this.Items_comment,
            this.Items_sell_price,
            this.Items_sell_date});

            // Items_id
            // 
            this.Items_id.HeaderText = "品番";
            this.Items_id.Name = "Items_id";
            this.Items_id.ReadOnly = true;

            // 
            // Items_name
            // 
            this.Items_name.HeaderText = "商品名";
            this.Items_name.Name = "Items_name";
            this.Items_name.ReadOnly = false;
            this.Items_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;

            // 
            // Items_receipt_id
            // 
            this.Items_receipt_id.HeaderText = "出品者";
            this.Items_receipt_id.Name = "Items_receipt_id";
            this.Items_receipt_id.ReadOnly = true;
            this.Items_receipt_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;

            // 
            // Items_price
            // 
            this.Items_price.HeaderText = "定価";
            this.Items_price.Name = "Items_price";
            this.Items_price.ReadOnly = false;
            // 
            // Items_isReturn
            // 
            this.Items_isReturn.HeaderText = "返品";
            this.Items_isReturn.Name = "Items_isReturn";
            this.Items_isReturn.ReadOnly = false;
            // 
            // Items_tag_printed
            // 
            this.Items_tag_printed.HeaderText = "タグ印刷済み";
            this.Items_tag_printed.Name = "Items_tag_printed";
            this.Items_tag_printed.ReadOnly = false;
            //
            // Items_recipt_date
            // 
            this.Items_receipt_date.HeaderText = "登録日時";
            this.Items_receipt_date.Name = "Items_receipt_date";
            this.Items_receipt_date.ReadOnly = true;
            //
            // Items_volume
            // 
            this.Items_volume.HeaderText = "分冊";
            this.Items_volume.Name = "Items_volume";
            this.Items_volume.ReadOnly = false;
            //
            // Items_boxid
            // 
            this.Items_boxid.HeaderText = "箱番";
            this.Items_boxid.Name = "Items_boxid";
            this.Items_boxid.ReadOnly = true;
            // 
            // Items_comment
            // 
            this.Items_comment.HeaderText = "コメント";
            this.Items_comment.Name = "Items_comment";
            this.Items_comment.ReadOnly = false;
            // 
            // Items_sell_date
            // 
            this.Items_sell_date.HeaderText = "販売日時";
            this.Items_sell_date.Name = "Items_sell_date";
            this.Items_sell_date.ReadOnly = true;
            // 
            // Items_sell_price
            // 
            this.Items_sell_price.HeaderText = "売価";
            this.Items_sell_price.Name = "Items_sell_price";
            this.Items_sell_price.ReadOnly = false;
            this.Rows.Clear();
            if (Context != null)
            {
                foreach (var q in data)
                {
                    this.Rows.Add(new object[]{
                        q.item_id,
                        q.item_name,
                        q.item_receipt_id,
                        q.item_tagprice,
                        q.item_return,
                        q.item_tag_printed,
                        q.item_receipt_time,
                        q.item_volumes,
                        q.item_box_id,
                        q.item_comment,
                        q.item_sellprice,
                        q.item_selltime
                        });
                }
            }
        }

        public void Delete()
        {
            foreach (DataGridViewRow row in this.SelectedRows)
            {
                DialogResult result =
                    MessageBox.Show((row.Index + 1) + "列目を削除してもよろしいですか?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No) return;
                //データベースアクセス
                int id = Convert.ToInt32(row.Cells[0].Value);
                if (id > 0)
                {
                    var list = from n in Context.item
                               where n.item_id == id
                               select n;
                    foreach (item q in list)
                    {
                        Context.item.DeleteOnSubmit(q);
                    }
                    try
                    {
                        Context.SubmitChanges();
                    }
                    catch (ChangeConflictException)
                    {
                        foreach (ObjectChangeConflict occ in Context.ChangeConflicts)
                        {
                            occ.Resolve(RefreshMode.KeepCurrentValues);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {

                }
                Rows.Remove(row);

            }
        }

        public void Load(int id = -1)
        {
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items_id,
            this.Items_name,
            this.Items_receipt_id,
            this.Items_price,
            this.Items_isReturn,
            this.Items_tag_printed,
            this.Items_receipt_date,
            this.Items_volume,
            this.Items_boxid,
            this.Items_comment,
            this.Items_sell_price,
            this.Items_sell_date});

            // Items_id
            // 
            this.Items_id.HeaderText = "品番";
            this.Items_id.Name = "Items_id";
            this.Items_id.ReadOnly = true;

            // 
            // Items_name
            // 
            this.Items_name.HeaderText = "商品名";
            this.Items_name.Name = "Items_name";
            this.Items_name.ReadOnly = false;
            this.Items_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Items_receipt_id
            // 
            this.Items_receipt_id.HeaderText = "出品者";
            this.Items_receipt_id.Name = "Items_receipt_id";
            this.Items_receipt_id.ReadOnly = true;
            this.Items_receipt_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Items_price
            // 
            this.Items_price.HeaderText = "定価";
            this.Items_price.Name = "Items_price";
            this.Items_price.ReadOnly = false;
            // 
            // Items_isReturn
            // 
            this.Items_isReturn.HeaderText = "返品";
            this.Items_isReturn.Name = "Items_isReturn";
            this.Items_isReturn.ReadOnly = false;
            // 
            // Items_tag_printed
            // 
            this.Items_tag_printed.HeaderText = "タグ印刷済み";
            this.Items_tag_printed.Name = "Items_tag_printed";
            this.Items_tag_printed.ReadOnly = false;
            //
            // Items_recipt_date
            // 
            this.Items_receipt_date.HeaderText = "登録日時";
            this.Items_receipt_date.Name = "Items_receipt_date";
            this.Items_receipt_date.ReadOnly = true;
            //
            // Items_volume
            // 
            this.Items_volume.HeaderText = "分冊";
            this.Items_volume.Name = "Items_volume";
            this.Items_volume.ReadOnly = false;
            //
            // Items_boxid
            // 
            this.Items_boxid.HeaderText = "箱番";
            this.Items_boxid.Name = "Items_boxid";
            this.Items_boxid.ReadOnly = true;
            // 
            // Items_comment
            // 
            this.Items_comment.HeaderText = "コメント";
            this.Items_comment.Name = "Items_comment";
            this.Items_comment.ReadOnly = false;
            // 
            // Items_sell_date
            // 
            this.Items_sell_date.HeaderText = "販売日時";
            this.Items_sell_date.Name = "Items_sell_date";
            this.Items_sell_date.ReadOnly = true;
            // 
            // Items_sell_price
            // 
            this.Items_sell_price.HeaderText = "売価";
            this.Items_sell_price.Name = "Items_sell_price";
            this.Items_sell_price.ReadOnly = false;
            this.Rows.Clear();
            if (Context != null)
            {
                IQueryable<item> list;
                if (id >= 0)
                {
                    this.ReceiptID = id;
                    list = from n in Context.item
                           where n.item_receipt_id == id
                           select n;
                }
                else
                {
                    return;
                }
                foreach (var q in list)
                {
                    this.Rows.Add(new object[]{
                        q.item_id,
                        q.item_name,
                        q.item_receipt_id,
                        q.item_tagprice,
                        q.item_return,
                        q.item_tag_printed,
                        q.item_receipt_time,
                        q.item_volumes,
                        q.item_box_id,
                        q.item_comment,
                        q.item_sellprice,
                        q.item_selltime
                        });
                }
            }
        }
    }
}
