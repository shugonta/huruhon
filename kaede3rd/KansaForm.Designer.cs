﻿namespace kaede3rd
{
    partial class KansaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ban = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_baika = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_teika = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_nebiki = new System.Windows.Forms.TextBox();
            this.button_mibai = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_operator = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_teisei = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_remain = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_allkansa = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_sum = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_sellop = new System.Windows.Forms.TextBox();
            this.button_allend = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_selltime = new System.Windows.Forms.TextBox();
            this.button_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "品番orバーコード";
            // 
            // textBox_ban
            // 
            this.textBox_ban.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_ban.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_ban.Location = new System.Drawing.Point(122, 20);
            this.textBox_ban.Name = "textBox_ban";
            this.textBox_ban.Size = new System.Drawing.Size(100, 28);
            this.textBox_ban.TabIndex = 0;
            this.textBox_ban.Text = "品番";
            this.textBox_ban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_ban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ban_KeyDown);
            this.textBox_ban.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_name.Location = new System.Drawing.Point(86, 75);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(249, 23);
            this.textBox_name.TabIndex = 2;
            this.textBox_name.TabStop = false;
            this.textBox_name.Text = "商品名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "商品名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "売価";
            // 
            // textBox_baika
            // 
            this.textBox_baika.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_baika.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_baika.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_baika.Location = new System.Drawing.Point(113, 147);
            this.textBox_baika.Name = "textBox_baika";
            this.textBox_baika.ReadOnly = true;
            this.textBox_baika.Size = new System.Drawing.Size(109, 34);
            this.textBox_baika.TabIndex = 1;
            this.textBox_baika.Text = "0";
            this.textBox_baika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_baika.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(86, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "¥";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "入力してEnter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(68, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "¥";
            // 
            // textBox_teika
            // 
            this.textBox_teika.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_teika.Location = new System.Drawing.Point(86, 108);
            this.textBox_teika.Name = "textBox_teika";
            this.textBox_teika.ReadOnly = true;
            this.textBox_teika.Size = new System.Drawing.Size(63, 23);
            this.textBox_teika.TabIndex = 10;
            this.textBox_teika.TabStop = false;
            this.textBox_teika.Text = "0";
            this.textBox_teika.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "定価";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "値引";
            // 
            // textBox_nebiki
            // 
            this.textBox_nebiki.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_nebiki.Location = new System.Drawing.Point(212, 108);
            this.textBox_nebiki.Name = "textBox_nebiki";
            this.textBox_nebiki.ReadOnly = true;
            this.textBox_nebiki.Size = new System.Drawing.Size(50, 23);
            this.textBox_nebiki.TabIndex = 13;
            this.textBox_nebiki.TabStop = false;
            this.textBox_nebiki.Text = "×";
            this.textBox_nebiki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_mibai
            // 
            this.button_mibai.Enabled = false;
            this.button_mibai.Location = new System.Drawing.Point(122, 244);
            this.button_mibai.Name = "button_mibai";
            this.button_mibai.Size = new System.Drawing.Size(112, 23);
            this.button_mibai.TabIndex = 17;
            this.button_mibai.TabStop = false;
            this.button_mibai.Text = "未売却にする (&M)";
            this.button_mibai.UseVisualStyleBackColor = true;
            this.button_mibai.Click += new System.EventHandler(this.button_mibai_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 336);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "入力者";
            // 
            // textBox_operator
            // 
            this.textBox_operator.Location = new System.Drawing.Point(68, 333);
            this.textBox_operator.Name = "textBox_operator";
            this.textBox_operator.ReadOnly = true;
            this.textBox_operator.Size = new System.Drawing.Size(122, 19);
            this.textBox_operator.TabIndex = 19;
            this.textBox_operator.TabStop = false;
            this.textBox_operator.Text = "Operator";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.TabStop = false;
            this.button1.Text = "変更 (&L)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_teisei
            // 
            this.button_teisei.Enabled = false;
            this.button_teisei.Location = new System.Drawing.Point(23, 244);
            this.button_teisei.Name = "button_teisei";
            this.button_teisei.Size = new System.Drawing.Size(75, 23);
            this.button_teisei.TabIndex = 21;
            this.button_teisei.TabStop = false;
            this.button_teisei.Text = "訂正 (&F)";
            this.button_teisei.UseVisualStyleBackColor = true;
            this.button_teisei.Click += new System.EventHandler(this.button_teisei_Click);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(21, 283);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(156, 12);
            this.label_error.TabIndex = 22;
            this.label_error.Text = "監査する品番を入力してください";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(357, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "残り未監査";
            // 
            // textBox_remain
            // 
            this.textBox_remain.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_remain.Location = new System.Drawing.Point(424, 71);
            this.textBox_remain.Name = "textBox_remain";
            this.textBox_remain.ReadOnly = true;
            this.textBox_remain.Size = new System.Drawing.Size(58, 23);
            this.textBox_remain.TabIndex = 26;
            this.textBox_remain.Text = "???";
            this.textBox_remain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(488, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "品";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 28;
            this.button2.TabStop = false;
            this.button2.Text = "一覧";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(488, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 31;
            this.label13.Text = "品";
            // 
            // textBox_allkansa
            // 
            this.textBox_allkansa.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_allkansa.Location = new System.Drawing.Point(424, 104);
            this.textBox_allkansa.Name = "textBox_allkansa";
            this.textBox_allkansa.ReadOnly = true;
            this.textBox_allkansa.Size = new System.Drawing.Size(58, 23);
            this.textBox_allkansa.TabIndex = 30;
            this.textBox_allkansa.Text = "???";
            this.textBox_allkansa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(357, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "監査対象";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(509, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "円";
            // 
            // textBox_sum
            // 
            this.textBox_sum.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_sum.Location = new System.Drawing.Point(424, 131);
            this.textBox_sum.Name = "textBox_sum";
            this.textBox_sum.ReadOnly = true;
            this.textBox_sum.Size = new System.Drawing.Size(79, 23);
            this.textBox_sum.TabIndex = 33;
            this.textBox_sum.Text = "??,???";
            this.textBox_sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(381, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "合計";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(511, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 23);
            this.button3.TabIndex = 35;
            this.button3.TabStop = false;
            this.button3.Text = "一覧";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(356, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 12);
            this.label17.TabIndex = 36;
            this.label17.Text = "（5秒ごと自動更新）";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 190);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 37;
            this.label18.Text = "売却入力者";
            // 
            // textBox_sellop
            // 
            this.textBox_sellop.Location = new System.Drawing.Point(113, 187);
            this.textBox_sellop.Name = "textBox_sellop";
            this.textBox_sellop.ReadOnly = true;
            this.textBox_sellop.Size = new System.Drawing.Size(109, 19);
            this.textBox_sellop.TabIndex = 38;
            // 
            // button_allend
            // 
            this.button_allend.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_allend.Location = new System.Drawing.Point(397, 336);
            this.button_allend.Name = "button_allend";
            this.button_allend.Size = new System.Drawing.Size(172, 18);
            this.button_allend.TabIndex = 39;
            this.button_allend.TabStop = false;
            this.button_allend.Text = "本日の監査を完了（管理用）";
            this.button_allend.UseVisualStyleBackColor = true;
            this.button_allend.Click += new System.EventHandler(this.button_allend_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "売却日時";
            // 
            // textBox_selltime
            // 
            this.textBox_selltime.Location = new System.Drawing.Point(113, 212);
            this.textBox_selltime.Name = "textBox_selltime";
            this.textBox_selltime.ReadOnly = true;
            this.textBox_selltime.Size = new System.Drawing.Size(109, 19);
            this.textBox_selltime.TabIndex = 41;
            // 
            // button_reset
            // 
            this.button_reset.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_reset.Location = new System.Drawing.Point(397, 312);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(172, 18);
            this.button_reset.TabIndex = 42;
            this.button_reset.TabStop = false;
            this.button_reset.Text = "本日の監査をやりなおす（管理用）";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // KansaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 382);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.textBox_selltime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_allend);
            this.Controls.Add(this.textBox_sellop);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox_sum);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox_allkansa);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_remain);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.button_teisei);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_operator);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button_mibai);
            this.Controls.Add(this.textBox_nebiki);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_teika);
            this.Controls.Add(this.label8);
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
            this.Name = "KansaForm";
            this.Text = "監査";
            this.Load += new System.EventHandler(this.KansaForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KansaForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ban;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_baika;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_teika;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_nebiki;
        private System.Windows.Forms.Button button_mibai;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_operator;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_teisei;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_remain;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_allkansa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_sum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_sellop;
        private System.Windows.Forms.Button button_allend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_selltime;
        private System.Windows.Forms.Button button_reset;
    }
}