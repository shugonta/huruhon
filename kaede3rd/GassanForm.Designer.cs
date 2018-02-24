namespace kaede3rd
{
    partial class GassanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_reload = new System.Windows.Forms.Button();
            this.button_csv = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnReceipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReturn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReturn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(15, 10);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(60, 23);
            this.button_reload.TabIndex = 8;
            this.button_reload.Text = "更新";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // button_csv
            // 
            this.button_csv.Location = new System.Drawing.Point(102, 10);
            this.button_csv.Name = "button_csv";
            this.button_csv.Size = new System.Drawing.Size(60, 23);
            this.button_csv.TabIndex = 9;
            this.button_csv.Text = "csv";
            this.button_csv.UseVisualStyleBackColor = true;
            this.button_csv.Click += new System.EventHandler(this.button_csv_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReceipt,
            this.ColumnSellPrice,
            this.ColumnSum1,
            this.ColumnReturn1,
            this.ColumnSum2,
            this.ColumnReturn2});
            this.dataGridView1.Location = new System.Drawing.Point(0, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(410, 336);
            this.dataGridView1.TabIndex = 7;
            // 
            // ColumnReceipt
            // 
            this.ColumnReceipt.HeaderText = "出品者";
            this.ColumnReceipt.Name = "ColumnReceipt";
            this.ColumnReceipt.ReadOnly = true;
            this.ColumnReceipt.Width = 160;
            // 
            // ColumnSellPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            this.ColumnSellPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSellPrice.HeaderText = "売上額";
            this.ColumnSellPrice.Name = "ColumnSellPrice";
            this.ColumnSellPrice.ReadOnly = true;
            this.ColumnSellPrice.Width = 70;
            // 
            // ColumnSum1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSum1.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSum1.HeaderText = "Sum1";
            this.ColumnSum1.Name = "ColumnSum1";
            this.ColumnSum1.ReadOnly = true;
            this.ColumnSum1.Width = 70;
            // 
            // ColumnReturn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReturn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnReturn1.HeaderText = "返品個数1";
            this.ColumnReturn1.Name = "ColumnReturn1";
            this.ColumnReturn1.ReadOnly = true;
            this.ColumnReturn1.Width = 70;
            // 
            // ColumnSum2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSum2.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSum2.HeaderText = "Sum2";
            this.ColumnSum2.Name = "ColumnSum2";
            this.ColumnSum2.ReadOnly = true;
            this.ColumnSum2.Width = 70;
            // 
            // ColumnReturn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnReturn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnReturn2.HeaderText = "返品個数2";
            this.ColumnReturn2.Name = "ColumnReturn2";
            this.ColumnReturn2.ReadOnly = true;
            this.ColumnReturn2.Width = 70;
            // 
            // GassanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 380);
            this.Controls.Add(this.button_csv);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GassanForm";
            this.Text = "返金額を合算";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_reload;
        private System.Windows.Forms.Button button_csv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReturn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSum2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReturn2;

    }
}