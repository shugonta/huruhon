namespace kaede3rd
{
    partial class ReceiptPrint
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listBox_genre = new System.Windows.Forms.ListBox();
            this.button_print = new System.Windows.Forms.Button();
            this.checkBox_date = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_id = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_allbox_print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(151, 106);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 19);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // listBox_genre
            // 
            this.listBox_genre.FormattingEnabled = true;
            this.listBox_genre.ItemHeight = 12;
            this.listBox_genre.Location = new System.Drawing.Point(13, 12);
            this.listBox_genre.Name = "listBox_genre";
            this.listBox_genre.Size = new System.Drawing.Size(120, 112);
            this.listBox_genre.TabIndex = 1;
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(12, 168);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(75, 23);
            this.button_print.TabIndex = 2;
            this.button_print.Text = "印刷";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // checkBox_date
            // 
            this.checkBox_date.AutoSize = true;
            this.checkBox_date.Location = new System.Drawing.Point(139, 84);
            this.checkBox_date.Name = "checkBox_date";
            this.checkBox_date.Size = new System.Drawing.Size(72, 16);
            this.checkBox_date.TabIndex = 3;
            this.checkBox_date.Text = "期間指定";
            this.checkBox_date.UseVisualStyleBackColor = true;
            this.checkBox_date.CheckedChanged += new System.EventHandler(this.checkBox_date_CheckedChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(151, 143);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 19);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "～";
            // 
            // checkBox_id
            // 
            this.checkBox_id.AutoSize = true;
            this.checkBox_id.Location = new System.Drawing.Point(139, 12);
            this.checkBox_id.Name = "checkBox_id";
            this.checkBox_id.Size = new System.Drawing.Size(59, 16);
            this.checkBox_id.TabIndex = 6;
            this.checkBox_id.Text = "ID指定";
            this.checkBox_id.UseVisualStyleBackColor = true;
            this.checkBox_id.CheckedChanged += new System.EventHandler(this.checkBox_id_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(151, 33);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 19);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "以上";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(151, 57);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(47, 19);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "以下";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(14, 145);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(120, 19);
            this.textBox_search.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "商品名検索";
            // 
            // button_allbox_print
            // 
            this.button_allbox_print.Location = new System.Drawing.Point(93, 168);
            this.button_allbox_print.Name = "button_allbox_print";
            this.button_allbox_print.Size = new System.Drawing.Size(82, 23);
            this.button_allbox_print.TabIndex = 13;
            this.button_allbox_print.Text = "箱ごとに印刷";
            this.button_allbox_print.UseVisualStyleBackColor = true;
            this.button_allbox_print.Click += new System.EventHandler(this.button_allbox_print_Click);
            // 
            // ReceiptPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 196);
            this.Controls.Add(this.button_allbox_print);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.checkBox_date);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.listBox_genre);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "ReceiptPrint";
            this.Text = "商品一覧印刷";
            this.Load += new System.EventHandler(this.ReceiptPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox listBox_genre;
        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.CheckBox checkBox_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_id;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_allbox_print;
    }
}