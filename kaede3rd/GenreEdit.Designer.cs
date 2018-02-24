namespace kaede3rd
{
    partial class GenreEdit
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
            this.listBox_genre = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_genre
            // 
            this.listBox_genre.FormattingEnabled = true;
            this.listBox_genre.ItemHeight = 12;
            this.listBox_genre.Location = new System.Drawing.Point(13, 13);
            this.listBox_genre.Name = "listBox_genre";
            this.listBox_genre.Size = new System.Drawing.Size(168, 100);
            this.listBox_genre.TabIndex = 0;
            this.listBox_genre.SelectedIndexChanged += new System.EventHandler(this.listBox_genre_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 1;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(13, 119);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(63, 23);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "追加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(13, 146);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(64, 23);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "削除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(107, 173);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(13, 172);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(72, 23);
            this.button_print.TabIndex = 5;
            this.button_print.Text = "一覧印刷";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // GenreEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 201);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox_genre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenreEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ジャンル編集";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_genre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_print;

    }
}