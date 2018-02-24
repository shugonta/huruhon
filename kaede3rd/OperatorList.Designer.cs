namespace kaede3rd
{
    partial class OperatorList
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
            this.button_refresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OperatorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(16, 2);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 3;
            this.button_refresh.Text = "更新";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OperatorId,
            this.OperatorName,
            this.OperatorComment});
            this.dataGridView1.Location = new System.Drawing.Point(4, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(334, 249);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // OperatorId
            // 
            this.OperatorId.Frozen = true;
            this.OperatorId.HeaderText = "ID";
            this.OperatorId.Name = "OperatorId";
            this.OperatorId.ReadOnly = true;
            this.OperatorId.Width = 40;
            // 
            // OperatorName
            // 
            this.OperatorName.HeaderText = "名前";
            this.OperatorName.Name = "OperatorName";
            // 
            // OperatorComment
            // 
            this.OperatorComment.HeaderText = "コメント";
            this.OperatorComment.Name = "OperatorComment";
            this.OperatorComment.Width = 150;
            // 
            // OperatorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 282);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OperatorList";
            this.Text = "オペレーターを管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorComment;
    }
}