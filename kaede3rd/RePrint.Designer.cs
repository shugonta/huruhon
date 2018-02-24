namespace kaede3rd
{
    partial class RePrint
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.itemsGridView1 = new kaede3rd.ItemsGridView();
            this.button_refresh = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_refresh);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_search);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.itemsGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(584, 262);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.TabIndex = 0;
            // 
            // itemsGridView1
            // 
            this.itemsGridView1.AllowUserToAddRows = false;
            this.itemsGridView1.AllowUserToDeleteRows = false;
            this.itemsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView1.Context = null;
            this.itemsGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsGridView1.Location = new System.Drawing.Point(0, 0);
            this.itemsGridView1.Name = "itemsGridView1";
            this.itemsGridView1.ReadOnly = true;
            this.itemsGridView1.ReceiptID = 0;
            this.itemsGridView1.RowTemplate.Height = 21;
            this.itemsGridView1.Size = new System.Drawing.Size(584, 223);
            this.itemsGridView1.TabIndex = 1;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(231, 8);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(85, 23);
            this.button_refresh.TabIndex = 3;
            this.button_refresh.Text = "再印刷登録";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(92, 10);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(119, 19);
            this.textBox_search.TabIndex = 2;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "検索(名前,ID)";
            // 
            // RePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RePrint";
            this.Text = "タグ再印刷";
            this.Load += new System.EventHandler(this.RePrint_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ItemsGridView itemsGridView1;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Label label1;

    }
}