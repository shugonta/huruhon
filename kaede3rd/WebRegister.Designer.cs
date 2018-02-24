namespace kaede3rd
{
    partial class WebRegister
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_No = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemReturn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AttNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Class = new System.Windows.Forms.TextBox();
            this.textBox_Grade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_bumon = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip_rowHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.キャンセルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_supplement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip_rowHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "受付No.";
            // 
            // textBox_No
            // 
            this.textBox_No.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_No.Location = new System.Drawing.Point(77, 9);
            this.textBox_No.Name = "textBox_No";
            this.textBox_No.Size = new System.Drawing.Size(64, 26);
            this.textBox_No.TabIndex = 1;
            this.textBox_No.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_No_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.ItemNum,
            this.ItemPrice,
            this.ItemReturn,
            this.ItemVol,
            this.ItemComment});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(734, 327);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // ItemID
            // 
            this.ItemID.FillWeight = 41.72876F;
            this.ItemID.HeaderText = "ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Width = 40;
            // 
            // ItemName
            // 
            this.ItemName.FillWeight = 336.5503F;
            this.ItemName.HeaderText = "商品名";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 350;
            // 
            // ItemNum
            // 
            this.ItemNum.FillWeight = 30.44163F;
            this.ItemNum.HeaderText = "冊数";
            this.ItemNum.Name = "ItemNum";
            this.ItemNum.Width = 35;
            // 
            // ItemPrice
            // 
            this.ItemPrice.FillWeight = 51.38501F;
            this.ItemPrice.HeaderText = "価格";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Width = 35;
            // 
            // ItemReturn
            // 
            this.ItemReturn.FillWeight = 36.76363F;
            this.ItemReturn.HeaderText = "返品";
            this.ItemReturn.Name = "ItemReturn";
            this.ItemReturn.Width = 35;
            // 
            // ItemVol
            // 
            this.ItemVol.FillWeight = 40.2084F;
            this.ItemVol.HeaderText = "分冊";
            this.ItemVol.Name = "ItemVol";
            this.ItemVol.Width = 39;
            // 
            // ItemComment
            // 
            this.ItemComment.FillWeight = 162.9222F;
            this.ItemComment.HeaderText = "コメント";
            this.ItemComment.Name = "ItemComment";
            this.ItemComment.Width = 156;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label_supplement);
            this.splitContainer1.Panel1.Controls.Add(this.button_save);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Name);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_AttNum);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Class);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Grade);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label_bumon);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_No);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(734, 412);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.TabIndex = 3;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_save.Location = new System.Drawing.Point(630, 44);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 27);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "登録";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Name.Location = new System.Drawing.Point(225, 45);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(160, 26);
            this.textBox_Name.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(191, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "番";
            // 
            // textBox_AttNum
            // 
            this.textBox_AttNum.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_AttNum.Location = new System.Drawing.Point(151, 44);
            this.textBox_AttNum.Name = "textBox_AttNum";
            this.textBox_AttNum.Size = new System.Drawing.Size(34, 26);
            this.textBox_AttNum.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(117, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "組";
            // 
            // textBox_Class
            // 
            this.textBox_Class.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Class.Location = new System.Drawing.Point(78, 44);
            this.textBox_Class.Name = "textBox_Class";
            this.textBox_Class.Size = new System.Drawing.Size(34, 26);
            this.textBox_Class.TabIndex = 5;
            // 
            // textBox_Grade
            // 
            this.textBox_Grade.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Grade.Location = new System.Drawing.Point(12, 44);
            this.textBox_Grade.Name = "textBox_Grade";
            this.textBox_Grade.Size = new System.Drawing.Size(34, 26);
            this.textBox_Grade.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(46, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "年";
            // 
            // label_bumon
            // 
            this.label_bumon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_bumon.AutoSize = true;
            this.label_bumon.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_bumon.ForeColor = System.Drawing.Color.Red;
            this.label_bumon.Location = new System.Drawing.Point(598, 9);
            this.label_bumon.Name = "label_bumon";
            this.label_bumon.Size = new System.Drawing.Size(0, 19);
            this.label_bumon.TabIndex = 2;
            this.label_bumon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 304);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 23);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(170, 18);
            this.toolStripStatusLabel1.Text = "Ctrl+S 巻数拡張 Ctrl+R 補充";
            // 
            // contextMenuStrip_rowHeader
            // 
            this.contextMenuStrip_rowHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.削除ToolStripMenuItem,
            this.toolStripSeparator6,
            this.キャンセルToolStripMenuItem});
            this.contextMenuStrip_rowHeader.Name = "contextMenuStrip_rowHeader";
            this.contextMenuStrip_rowHeader.Size = new System.Drawing.Size(137, 54);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(133, 6);
            // 
            // キャンセルToolStripMenuItem
            // 
            this.キャンセルToolStripMenuItem.Name = "キャンセルToolStripMenuItem";
            this.キャンセルToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.キャンセルToolStripMenuItem.Text = "キャンセル";
            this.キャンセルToolStripMenuItem.Click += new System.EventHandler(this.キャンセルToolStripMenuItem_Click);
            // 
            // label_supplement
            // 
            this.label_supplement.AutoSize = true;
            this.label_supplement.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_supplement.ForeColor = System.Drawing.Color.Red;
            this.label_supplement.Location = new System.Drawing.Point(147, 12);
            this.label_supplement.Name = "label_supplement";
            this.label_supplement.Size = new System.Drawing.Size(47, 19);
            this.label_supplement.TabIndex = 13;
            this.label_supplement.Text = "補充";
            this.label_supplement.Visible = false;
            // 
            // WebRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 412);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "WebRegister";
            this.Text = "Web登録";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WebRegister_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip_rowHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_No;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AttNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Class;
        private System.Windows.Forms.TextBox textBox_Grade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_bumon;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemComment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_rowHeader;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem キャンセルToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label_supplement;
    }
}