﻿namespace kaede3rd
{
    partial class SellForm
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
            this.label_sellop = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_operator = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button_mibai = new System.Windows.Forms.Button();
            this.label_sellzumi = new System.Windows.Forms.Label();
            this.label_teikaBaikyaku = new System.Windows.Forms.Label();
            this.label_CtrlZ = new System.Windows.Forms.Label();
            this.textBox_nebiki = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_teika = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_baikaEnter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_baika = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_ban = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_sellop
            // 
            this.label_sellop.AutoSize = true;
            this.label_sellop.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label_sellop.Location = new System.Drawing.Point(12, 163);
            this.label_sellop.Name = "label_sellop";
            this.label_sellop.Size = new System.Drawing.Size(47, 12);
            this.label_sellop.TabIndex = 43;
            this.label_sellop.Text = "入力者: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.TabStop = false;
            this.button1.Text = "変更 (&L)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_operator
            // 
            this.textBox_operator.Location = new System.Drawing.Point(59, 304);
            this.textBox_operator.Name = "textBox_operator";
            this.textBox_operator.ReadOnly = true;
            this.textBox_operator.Size = new System.Drawing.Size(122, 19);
            this.textBox_operator.TabIndex = 41;
            this.textBox_operator.TabStop = false;
            this.textBox_operator.Text = "Operator";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 40;
            this.label12.Text = "入力者";
            // 
            // button_mibai
            // 
            this.button_mibai.Location = new System.Drawing.Point(194, 134);
            this.button_mibai.Name = "button_mibai";
            this.button_mibai.Size = new System.Drawing.Size(112, 23);
            this.button_mibai.TabIndex = 39;
            this.button_mibai.TabStop = false;
            this.button_mibai.Text = "未売却にする (&M)";
            this.button_mibai.UseVisualStyleBackColor = true;
            this.button_mibai.Click += new System.EventHandler(this.button_mibai_Click);
            // 
            // label_sellzumi
            // 
            this.label_sellzumi.AutoSize = true;
            this.label_sellzumi.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_sellzumi.ForeColor = System.Drawing.Color.Red;
            this.label_sellzumi.Location = new System.Drawing.Point(10, 138);
            this.label_sellzumi.Name = "label_sellzumi";
            this.label_sellzumi.Size = new System.Drawing.Size(145, 19);
            this.label_sellzumi.TabIndex = 38;
            this.label_sellzumi.Text = "売却済 00,000円";
            this.label_sellzumi.Visible = false;
            // 
            // label_teikaBaikyaku
            // 
            this.label_teikaBaikyaku.AutoSize = true;
            this.label_teikaBaikyaku.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label_teikaBaikyaku.Location = new System.Drawing.Point(102, 229);
            this.label_teikaBaikyaku.Name = "label_teikaBaikyaku";
            this.label_teikaBaikyaku.Size = new System.Drawing.Size(152, 12);
            this.label_teikaBaikyaku.TabIndex = 37;
            this.label_teikaBaikyaku.Text = "定価通りの売却は \"-\" を入力";
            // 
            // label_CtrlZ
            // 
            this.label_CtrlZ.AutoSize = true;
            this.label_CtrlZ.Location = new System.Drawing.Point(12, 265);
            this.label_CtrlZ.Name = "label_CtrlZ";
            this.label_CtrlZ.Size = new System.Drawing.Size(169, 12);
            this.label_CtrlZ.TabIndex = 36;
            this.label_CtrlZ.Text = "最後の変更を取り消すには Ctrl+Z";
            // 
            // textBox_nebiki
            // 
            this.textBox_nebiki.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_nebiki.Location = new System.Drawing.Point(203, 100);
            this.textBox_nebiki.Name = "textBox_nebiki";
            this.textBox_nebiki.ReadOnly = true;
            this.textBox_nebiki.Size = new System.Drawing.Size(50, 23);
            this.textBox_nebiki.TabIndex = 35;
            this.textBox_nebiki.TabStop = false;
            this.textBox_nebiki.Text = "×";
            this.textBox_nebiki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "値引";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(59, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "¥";
            // 
            // textBox_teika
            // 
            this.textBox_teika.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_teika.Location = new System.Drawing.Point(77, 100);
            this.textBox_teika.Name = "textBox_teika";
            this.textBox_teika.ReadOnly = true;
            this.textBox_teika.Size = new System.Drawing.Size(63, 23);
            this.textBox_teika.TabIndex = 32;
            this.textBox_teika.TabStop = false;
            this.textBox_teika.Text = "0";
            this.textBox_teika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "定価";
            // 
            // label_baikaEnter
            // 
            this.label_baikaEnter.AutoSize = true;
            this.label_baikaEnter.Location = new System.Drawing.Point(232, 205);
            this.label_baikaEnter.Name = "label_baikaEnter";
            this.label_baikaEnter.Size = new System.Drawing.Size(74, 12);
            this.label_baikaEnter.TabIndex = 30;
            this.label_baikaEnter.Text = "入力してEnter";
            this.label_baikaEnter.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "入力してEnter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(77, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "¥";
            // 
            // textBox_baika
            // 
            this.textBox_baika.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_baika.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_baika.Location = new System.Drawing.Point(104, 189);
            this.textBox_baika.Name = "textBox_baika";
            this.textBox_baika.Size = new System.Drawing.Size(109, 34);
            this.textBox_baika.TabIndex = 24;
            this.textBox_baika.Text = "0";
            this.textBox_baika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_baika.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox_baika.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_baika_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "売価";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "商品名";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_name.Location = new System.Drawing.Point(77, 67);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(249, 23);
            this.textBox_name.TabIndex = 25;
            this.textBox_name.TabStop = false;
            this.textBox_name.Text = "商品名";
            // 
            // textBox_ban
            // 
            this.textBox_ban.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_ban.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_ban.Location = new System.Drawing.Point(113, 12);
            this.textBox_ban.Name = "textBox_ban";
            this.textBox_ban.Size = new System.Drawing.Size(100, 28);
            this.textBox_ban.TabIndex = 22;
            this.textBox_ban.Text = "品番";
            this.textBox_ban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_ban.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox_ban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ban_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "品番orバーコード";
            // 
            // SellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 337);
            this.Controls.Add(this.label_sellop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_operator);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button_mibai);
            this.Controls.Add(this.label_sellzumi);
            this.Controls.Add(this.label_teikaBaikyaku);
            this.Controls.Add(this.label_CtrlZ);
            this.Controls.Add(this.textBox_nebiki);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_teika);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_baikaEnter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_baika);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.textBox_ban);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellForm";
            this.Text = "売却";
            this.Load += new System.EventHandler(this.SellForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SellForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sellop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_operator;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_mibai;
        private System.Windows.Forms.Label label_sellzumi;
        private System.Windows.Forms.Label label_teikaBaikyaku;
        private System.Windows.Forms.Label label_CtrlZ;
        private System.Windows.Forms.TextBox textBox_nebiki;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_teika;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_baikaEnter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_baika;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_ban;
        private System.Windows.Forms.Label label1;
    }
}