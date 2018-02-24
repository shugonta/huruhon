namespace kaede3rd
{
    partial class BagEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_bag = new System.Windows.Forms.ComboBox();
            this.button_bagadd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_Price = new System.Windows.Forms.Label();
            this.comboBox_genre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.text_name = new System.Windows.Forms.TextBox();
            this.button_item = new System.Windows.Forms.Button();
            this.text_itemid = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTagPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_bag
            // 
            this.comboBox_bag.FormattingEnabled = true;
            this.comboBox_bag.Location = new System.Drawing.Point(12, 9);
            this.comboBox_bag.Name = "comboBox_bag";
            this.comboBox_bag.Size = new System.Drawing.Size(48, 20);
            this.comboBox_bag.TabIndex = 0;
            this.comboBox_bag.SelectedValueChanged += new System.EventHandler(this.comboBox_bag_SelectedValueChanged);
            this.comboBox_bag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_bag_KeyDown);
            // 
            // button_bagadd
            // 
            this.button_bagadd.Location = new System.Drawing.Point(321, 7);
            this.button_bagadd.Name = "button_bagadd";
            this.button_bagadd.Size = new System.Drawing.Size(75, 23);
            this.button_bagadd.TabIndex = 4;
            this.button_bagadd.Text = "福袋追加";
            this.button_bagadd.UseVisualStyleBackColor = true;
            this.button_bagadd.Click += new System.EventHandler(this.button_bagadd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_print);
            this.splitContainer1.Panel1.Controls.Add(this.label_Price);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_genre);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button_save);
            this.splitContainer1.Panel1.Controls.Add(this.text_name);
            this.splitContainer1.Panel1.Controls.Add(this.button_item);
            this.splitContainer1.Panel1.Controls.Add(this.text_itemid);
            this.splitContainer1.Panel1.Controls.Add(this.button_bagadd);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_bag);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(596, 312);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 2;
            // 
            // label_Price
            // 
            this.label_Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Price.AutoSize = true;
            this.label_Price.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Price.Location = new System.Drawing.Point(468, 6);
            this.label_Price.Name = "label_Price";
            this.label_Price.Size = new System.Drawing.Size(0, 16);
            this.label_Price.TabIndex = 8;
            this.label_Price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_genre
            // 
            this.comboBox_genre.FormattingEnabled = true;
            this.comboBox_genre.Location = new System.Drawing.Point(240, 7);
            this.comboBox_genre.Name = "comboBox_genre";
            this.comboBox_genre.Size = new System.Drawing.Size(75, 20);
            this.comboBox_genre.TabIndex = 3;
            this.comboBox_genre.SelectedIndexChanged += new System.EventHandler(this.comboBox_genre_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ジャンル";
            // 
            // button_save
            // 
            this.button_save.Enabled = false;
            this.button_save.Location = new System.Drawing.Point(518, 33);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(66, 9);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(120, 19);
            this.text_name.TabIndex = 1;
            this.text_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_bag_KeyDown);
            // 
            // button_item
            // 
            this.button_item.Enabled = false;
            this.button_item.Location = new System.Drawing.Point(138, 33);
            this.button_item.Name = "button_item";
            this.button_item.Size = new System.Drawing.Size(75, 23);
            this.button_item.TabIndex = 6;
            this.button_item.Text = "商品追加";
            this.button_item.UseVisualStyleBackColor = true;
            this.button_item.Click += new System.EventHandler(this.button_item_Click);
            // 
            // text_itemid
            // 
            this.text_itemid.Location = new System.Drawing.Point(12, 35);
            this.text_itemid.Name = "text_itemid";
            this.text_itemid.Size = new System.Drawing.Size(120, 19);
            this.text_itemid.TabIndex = 5;
            this.text_itemid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_itemid_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.ItemName,
            this.ItemTagPrice,
            this.ItemSellPrice});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(596, 248);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // ItemId
            // 
            this.ItemId.HeaderText = "品番";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.Width = 60;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "商品名";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // ItemTagPrice
            // 
            this.ItemTagPrice.HeaderText = "希望価格";
            this.ItemTagPrice.Name = "ItemTagPrice";
            this.ItemTagPrice.ReadOnly = true;
            // 
            // ItemSellPrice
            // 
            this.ItemSellPrice.HeaderText = "価格";
            this.ItemSellPrice.Name = "ItemSellPrice";
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(402, 7);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(55, 23);
            this.button_print.TabIndex = 9;
            this.button_print.Text = "印刷";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // BagEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 312);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BagEdit";
            this.Text = "福袋編集";
            this.Load += new System.EventHandler(this.BagEdit_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_bag;
        private System.Windows.Forms.Button button_bagadd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.Button button_item;
        private System.Windows.Forms.TextBox text_itemid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ComboBox comboBox_genre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTagPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSellPrice;
        private System.Windows.Forms.Label label_Price;
        private System.Windows.Forms.Button button_print;

    }
}
