namespace kaede3rd
{
    partial class AddItem
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.text_itemname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_itemid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check_return = new System.Windows.Forms.CheckBox();
            this.button_pre = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.groupBox_volume = new System.Windows.Forms.GroupBox();
            this.text_volume = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_num = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_supplement = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox_volume.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(369, 23);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 18);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(265, 18);
            this.toolStripStatusLabel2.Text = "Ctrl+S 巻数拡張 Ctrl+C コメント Ctrl+R 補充";
            // 
            // text_itemname
            // 
            this.text_itemname.AcceptsReturn = true;
            this.text_itemname.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.text_itemname.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.text_itemname.Location = new System.Drawing.Point(110, 38);
            this.text_itemname.Multiline = true;
            this.text_itemname.Name = "text_itemname";
            this.text_itemname.Size = new System.Drawing.Size(247, 68);
            this.text_itemname.TabIndex = 0;
            this.text_itemname.TextChanged += new System.EventHandler(this.text_itemname_TextChanged);
            this.text_itemname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_itemname_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "商品名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "品番";
            // 
            // text_itemid
            // 
            this.text_itemid.Location = new System.Drawing.Point(49, 10);
            this.text_itemid.Name = "text_itemid";
            this.text_itemid.Size = new System.Drawing.Size(43, 19);
            this.text_itemid.TabIndex = 6;
            this.text_itemid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_itemid_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "値段";
            // 
            // text_price
            // 
            this.text_price.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.text_price.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_price.Location = new System.Drawing.Point(110, 111);
            this.text_price.Name = "text_price";
            this.text_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text_price.Size = new System.Drawing.Size(79, 28);
            this.text_price.TabIndex = 1;
            this.text_price.TextChanged += new System.EventHandler(this.text_price_TextChanged);
            this.text_price.Enter += new System.EventHandler(this.TextBox_Enter);
            this.text_price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_itemname_KeyDown);
            this.text_price.Leave += new System.EventHandler(this.Num_Validate);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "返品可";
            // 
            // check_return
            // 
            this.check_return.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.check_return.Location = new System.Drawing.Point(110, 139);
            this.check_return.Name = "check_return";
            this.check_return.Size = new System.Drawing.Size(24, 28);
            this.check_return.TabIndex = 2;
            this.check_return.UseVisualStyleBackColor = true;
            this.check_return.KeyDown += new System.Windows.Forms.KeyEventHandler(this.check_return_KeyDown);
            // 
            // button_pre
            // 
            this.button_pre.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_pre.Location = new System.Drawing.Point(10, 299);
            this.button_pre.Name = "button_pre";
            this.button_pre.Size = new System.Drawing.Size(124, 31);
            this.button_pre.TabIndex = 5;
            this.button_pre.Text = "前の商品(&P)";
            this.button_pre.UseVisualStyleBackColor = true;
            this.button_pre.Click += new System.EventHandler(this.button_pre_Click);
            // 
            // button_next
            // 
            this.button_next.Enabled = false;
            this.button_next.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_next.Location = new System.Drawing.Point(242, 299);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(115, 31);
            this.button_next.TabIndex = 4;
            this.button_next.Text = "登録(&N)";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // groupBox_volume
            // 
            this.groupBox_volume.Controls.Add(this.text_volume);
            this.groupBox_volume.Controls.Add(this.label7);
            this.groupBox_volume.Controls.Add(this.text_num);
            this.groupBox_volume.Controls.Add(this.label6);
            this.groupBox_volume.Enabled = false;
            this.groupBox_volume.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox_volume.Location = new System.Drawing.Point(16, 186);
            this.groupBox_volume.Name = "groupBox_volume";
            this.groupBox_volume.Size = new System.Drawing.Size(341, 100);
            this.groupBox_volume.TabIndex = 3;
            this.groupBox_volume.TabStop = false;
            this.groupBox_volume.Text = "複数巻設定";
            // 
            // text_volume
            // 
            this.text_volume.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.text_volume.Location = new System.Drawing.Point(91, 64);
            this.text_volume.Name = "text_volume";
            this.text_volume.Size = new System.Drawing.Size(46, 23);
            this.text_volume.TabIndex = 5;
            this.text_volume.Enter += new System.EventHandler(this.TextBox_Enter);
            this.text_volume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_itemname_KeyDown);
            this.text_volume.Leave += new System.EventHandler(this.Num_Validate);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "分冊";
            // 
            // text_num
            // 
            this.text_num.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.text_num.Location = new System.Drawing.Point(91, 28);
            this.text_num.Name = "text_num";
            this.text_num.Size = new System.Drawing.Size(46, 23);
            this.text_num.TabIndex = 1;
            this.text_num.Enter += new System.EventHandler(this.TextBox_Enter);
            this.text_num.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_itemname_KeyDown);
            this.text_num.Leave += new System.EventHandler(this.Num_Validate);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "冊数";
            // 
            // label_supplement
            // 
            this.label_supplement.AutoSize = true;
            this.label_supplement.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_supplement.ForeColor = System.Drawing.Color.Red;
            this.label_supplement.Location = new System.Drawing.Point(310, 6);
            this.label_supplement.Name = "label_supplement";
            this.label_supplement.Size = new System.Drawing.Size(47, 19);
            this.label_supplement.TabIndex = 12;
            this.label_supplement.Text = "補充";
            this.label_supplement.Visible = false;
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 355);
            this.Controls.Add(this.label_supplement);
            this.Controls.Add(this.groupBox_volume);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_pre);
            this.Controls.Add(this.check_return);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_price);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_itemid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_itemname);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "AddItem";
            this.Text = "商品追加";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddItem_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_volume.ResumeLayout(false);
            this.groupBox_volume.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox text_itemname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_itemid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_return;
        private System.Windows.Forms.Button button_pre;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox_volume;
        private System.Windows.Forms.TextBox text_num;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_volume;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label_supplement;
    }
}