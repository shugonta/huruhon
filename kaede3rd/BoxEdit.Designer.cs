namespace kaede3rd
{
    partial class BoxEdit
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
            this.Box_list = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_genre = new System.Windows.Forms.Label();
            this.text_comment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_allitem = new System.Windows.Forms.Button();
            this.button_list_print = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.text_count = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Box_list
            // 
            this.Box_list.FormattingEnabled = true;
            this.Box_list.ItemHeight = 12;
            this.Box_list.Location = new System.Drawing.Point(10, 24);
            this.Box_list.Name = "Box_list";
            this.Box_list.Size = new System.Drawing.Size(57, 88);
            this.Box_list.TabIndex = 0;
            this.Box_list.SelectedIndexChanged += new System.EventHandler(this.Box_list_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_count);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label_genre);
            this.groupBox1.Controls.Add(this.text_comment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(74, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "箱情報";
            // 
            // label_genre
            // 
            this.label_genre.AutoSize = true;
            this.label_genre.Location = new System.Drawing.Point(52, 19);
            this.label_genre.Name = "label_genre";
            this.label_genre.Size = new System.Drawing.Size(0, 12);
            this.label_genre.TabIndex = 3;
            // 
            // text_comment
            // 
            this.text_comment.Location = new System.Drawing.Point(53, 37);
            this.text_comment.Multiline = true;
            this.text_comment.Name = "text_comment";
            this.text_comment.Size = new System.Drawing.Size(141, 45);
            this.text_comment.TabIndex = 2;
            this.text_comment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_comment_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "コメント:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "ジャンル:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "箱一覧";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(10, 147);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "商品追加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(199, 147);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 4;
            this.button_delete.Text = "削除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_allitem
            // 
            this.button_allitem.Location = new System.Drawing.Point(10, 118);
            this.button_allitem.Name = "button_allitem";
            this.button_allitem.Size = new System.Drawing.Size(97, 23);
            this.button_allitem.TabIndex = 5;
            this.button_allitem.Text = "箱内の商品一覧";
            this.button_allitem.UseVisualStyleBackColor = true;
            this.button_allitem.Click += new System.EventHandler(this.button_allitem_Click);
            // 
            // button_list_print
            // 
            this.button_list_print.Location = new System.Drawing.Point(152, 118);
            this.button_list_print.Name = "button_list_print";
            this.button_list_print.Size = new System.Drawing.Size(122, 23);
            this.button_list_print.TabIndex = 6;
            this.button_list_print.Text = "商品リストを印刷 (&P)";
            this.button_list_print.UseVisualStyleBackColor = true;
            this.button_list_print.Click += new System.EventHandler(this.button_list_print_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "商品数:";
            // 
            // text_count
            // 
            this.text_count.AutoSize = true;
            this.text_count.Location = new System.Drawing.Point(168, 19);
            this.text_count.Name = "text_count";
            this.text_count.Size = new System.Drawing.Size(0, 12);
            this.text_count.TabIndex = 5;
            // 
            // BoxEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 175);
            this.Controls.Add(this.button_list_print);
            this.Controls.Add(this.button_allitem);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Box_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BoxEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "箱管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Box_list;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_comment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label_genre;
        private System.Windows.Forms.Button button_allitem;
        private System.Windows.Forms.Button button_list_print;
        private System.Windows.Forms.Label text_count;
        private System.Windows.Forms.Label label4;
    }
}