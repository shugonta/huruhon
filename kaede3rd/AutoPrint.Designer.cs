namespace kaede3rd
{
    partial class AutoPrint
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_restore = new System.Windows.Forms.Button();
            this.button_forceprint = new System.Windows.Forms.Button();
            this.label_ = new System.Windows.Forms.Label();
            this.numericUpDown_interval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_count = new System.Windows.Forms.NumericUpDown();
            this.check_dia = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.itemsGridView1 = new kaede3rd.ItemsGridView();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_restore);
            this.splitContainer1.Panel1.Controls.Add(this.button_forceprint);
            this.splitContainer1.Panel1.Controls.Add(this.label_);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_interval);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_count);
            this.splitContainer1.Panel1.Controls.Add(this.check_dia);
            this.splitContainer1.Panel1.Controls.Add(this.button_start);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.itemsGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(524, 279);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_restore
            // 
            this.button_restore.Location = new System.Drawing.Point(275, 38);
            this.button_restore.Name = "button_restore";
            this.button_restore.Size = new System.Drawing.Size(92, 23);
            this.button_restore.TabIndex = 7;
            this.button_restore.Text = "印刷処理取消";
            this.button_restore.UseVisualStyleBackColor = true;
            this.button_restore.Click += new System.EventHandler(this.button_restore_Click);
            // 
            // button_forceprint
            // 
            this.button_forceprint.Location = new System.Drawing.Point(275, 12);
            this.button_forceprint.Name = "button_forceprint";
            this.button_forceprint.Size = new System.Drawing.Size(92, 23);
            this.button_forceprint.TabIndex = 6;
            this.button_forceprint.Text = "強制印刷";
            this.button_forceprint.UseVisualStyleBackColor = true;
            this.button_forceprint.Click += new System.EventHandler(this.button_forceprint_Click);
            // 
            // label_
            // 
            this.label_.AutoSize = true;
            this.label_.Location = new System.Drawing.Point(136, 43);
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(73, 12);
            this.label_.TabIndex = 5;
            this.label_.Text = "確認間隔(秒)";
            // 
            // numericUpDown_interval
            // 
            this.numericUpDown_interval.Location = new System.Drawing.Point(215, 40);
            this.numericUpDown_interval.Name = "numericUpDown_interval";
            this.numericUpDown_interval.Size = new System.Drawing.Size(32, 19);
            this.numericUpDown_interval.TabIndex = 4;
            this.numericUpDown_interval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "印刷枚数";
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.Location = new System.Drawing.Point(215, 15);
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.Size = new System.Drawing.Size(32, 19);
            this.numericUpDown_count.TabIndex = 2;
            this.numericUpDown_count.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // check_dia
            // 
            this.check_dia.AutoSize = true;
            this.check_dia.Checked = true;
            this.check_dia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_dia.Location = new System.Drawing.Point(13, 42);
            this.check_dia.Name = "check_dia";
            this.check_dia.Size = new System.Drawing.Size(112, 16);
            this.check_dia.TabIndex = 1;
            this.check_dia.Text = "印刷前に確認する";
            this.check_dia.UseVisualStyleBackColor = true;
            this.check_dia.CheckedChanged += new System.EventHandler(this.check_dia_CheckedChanged);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "監視開始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_status,
            this.toolStripStatusLabel_count});
            this.statusStrip1.Location = new System.Drawing.Point(0, 183);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(524, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_status
            // 
            this.toolStripStatusLabel_status.AutoSize = false;
            this.toolStripStatusLabel_status.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_status.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_status.Name = "toolStripStatusLabel_status";
            this.toolStripStatusLabel_status.Size = new System.Drawing.Size(130, 18);
            this.toolStripStatusLabel_status.Text = "監視停止中";
            this.toolStripStatusLabel_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_count
            // 
            this.toolStripStatusLabel_count.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_count.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_count.Name = "toolStripStatusLabel_count";
            this.toolStripStatusLabel_count.Size = new System.Drawing.Size(4, 18);
            this.toolStripStatusLabel_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.itemsGridView1.Size = new System.Drawing.Size(524, 206);
            this.itemsGridView1.TabIndex = 0;
            // 
            // timer_refresh
            // 
            this.timer_refresh.Tick += new System.EventHandler(this.timer_refresh_Tick);
            // 
            // AutoPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 279);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AutoPrint";
            this.Text = "タグ自動印刷";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoPrint_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_forceprint;
        private System.Windows.Forms.Label label_;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_count;
        private System.Windows.Forms.CheckBox check_dia;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_count;
        private ItemsGridView itemsGridView1;
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_status;
        private System.Windows.Forms.Button button_restore;
    }
}