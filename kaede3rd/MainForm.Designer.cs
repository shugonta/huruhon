namespace kaede3rd
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ログアウトLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.タグ印刷PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ページ設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.データToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新Receiptを追加FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最新の情報に更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.箱に商品を追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.部門設定を変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.機能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.売却ウィンドウSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.監査ウィンドウToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.箱管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.福袋管理FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返金返品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.タグ自動印刷TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.タグ再印刷RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品一覧印刷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.オペレーターIDを管理OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.バージョン情報AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_receipt = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.label_company = new System.Windows.Forms.Label();
            this.button_tagprint = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_webregist = new System.Windows.Forms.Button();
            this.button_all = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_sellcount = new System.Windows.Forms.ToolStripStatusLabel();
            this.各部門の返金額合算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new kaede3rd.ReceiptGridView();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.データToolStripMenuItem,
            this.機能ToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(623, 26);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ログアウトLToolStripMenuItem,
            this.タグ印刷PToolStripMenuItem,
            this.ページ設定ToolStripMenuItem,
            this.toolStripSeparator2,
            this.終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // ログアウトLToolStripMenuItem
            // 
            this.ログアウトLToolStripMenuItem.Name = "ログアウトLToolStripMenuItem";
            this.ログアウトLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.ログアウトLToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.ログアウトLToolStripMenuItem.Text = "ログアウト (&L)";
            this.ログアウトLToolStripMenuItem.Click += new System.EventHandler(this.ログアウトLToolStripMenuItem_Click);
            // 
            // タグ印刷PToolStripMenuItem
            // 
            this.タグ印刷PToolStripMenuItem.Name = "タグ印刷PToolStripMenuItem";
            this.タグ印刷PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.タグ印刷PToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.タグ印刷PToolStripMenuItem.Text = "タグ印刷 (&P)";
            this.タグ印刷PToolStripMenuItem.Click += new System.EventHandler(this.タグ印刷PToolStripMenuItem_Click);
            // 
            // ページ設定ToolStripMenuItem
            // 
            this.ページ設定ToolStripMenuItem.Name = "ページ設定ToolStripMenuItem";
            this.ページ設定ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.ページ設定ToolStripMenuItem.Text = "ページ設定 (&U)";
            this.ページ設定ToolStripMenuItem.Click += new System.EventHandler(this.ページ設定ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.End)));
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.終了ToolStripMenuItem.Text = "終了 (&X)";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // データToolStripMenuItem
            // 
            this.データToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新Receiptを追加FToolStripMenuItem,
            this.最新の情報に更新ToolStripMenuItem,
            this.箱に商品を追加ToolStripMenuItem,
            this.toolStripSeparator1,
            this.部門設定を変更ToolStripMenuItem});
            this.データToolStripMenuItem.Name = "データToolStripMenuItem";
            this.データToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.データToolStripMenuItem.Text = "データ(&D)";
            // 
            // 新Receiptを追加FToolStripMenuItem
            // 
            this.新Receiptを追加FToolStripMenuItem.Name = "新Receiptを追加FToolStripMenuItem";
            this.新Receiptを追加FToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.新Receiptを追加FToolStripMenuItem.Text = "新Receiptを追加 (&U)";
            this.新Receiptを追加FToolStripMenuItem.Click += new System.EventHandler(this.新Receiptを追加FToolStripMenuItem_Click);
            // 
            // 最新の情報に更新ToolStripMenuItem
            // 
            this.最新の情報に更新ToolStripMenuItem.Name = "最新の情報に更新ToolStripMenuItem";
            this.最新の情報に更新ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.最新の情報に更新ToolStripMenuItem.Text = "最新の情報に更新 (&R)";
            this.最新の情報に更新ToolStripMenuItem.Click += new System.EventHandler(this.最新の情報に更新ToolStripMenuItem_Click);
            // 
            // 箱に商品を追加ToolStripMenuItem
            // 
            this.箱に商品を追加ToolStripMenuItem.Name = "箱に商品を追加ToolStripMenuItem";
            this.箱に商品を追加ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.箱に商品を追加ToolStripMenuItem.Text = "箱に商品を追加 (&N)";
            this.箱に商品を追加ToolStripMenuItem.Click += new System.EventHandler(this.箱に商品を追加ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // 部門設定を変更ToolStripMenuItem
            // 
            this.部門設定を変更ToolStripMenuItem.Name = "部門設定を変更ToolStripMenuItem";
            this.部門設定を変更ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.部門設定を変更ToolStripMenuItem.Text = "部門設定を変更 (&S)";
            this.部門設定を変更ToolStripMenuItem.Click += new System.EventHandler(this.部門設定を変更ToolStripMenuItem_Click);
            // 
            // 機能ToolStripMenuItem
            // 
            this.機能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.売却ウィンドウSToolStripMenuItem,
            this.監査ウィンドウToolStripMenuItem,
            this.箱管理ToolStripMenuItem,
            this.福袋管理FToolStripMenuItem,
            this.返金返品ToolStripMenuItem,
            this.各部門の返金額合算ToolStripMenuItem,
            this.toolStripSeparator3,
            this.タグ自動印刷TToolStripMenuItem,
            this.タグ再印刷RToolStripMenuItem,
            this.商品一覧印刷ToolStripMenuItem,
            this.toolStripSeparator4,
            this.オペレーターIDを管理OToolStripMenuItem,
            this.toolStripSeparator5,
            this.バージョン情報AToolStripMenuItem});
            this.機能ToolStripMenuItem.Name = "機能ToolStripMenuItem";
            this.機能ToolStripMenuItem.Size = new System.Drawing.Size(63, 22);
            this.機能ToolStripMenuItem.Text = "機能(&O)";
            // 
            // 売却ウィンドウSToolStripMenuItem
            // 
            this.売却ウィンドウSToolStripMenuItem.Name = "売却ウィンドウSToolStripMenuItem";
            this.売却ウィンドウSToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.売却ウィンドウSToolStripMenuItem.Text = "売却ウィンドウ (&S)";
            this.売却ウィンドウSToolStripMenuItem.Click += new System.EventHandler(this.売却ウィンドウSToolStripMenuItem_Click);
            // 
            // 監査ウィンドウToolStripMenuItem
            // 
            this.監査ウィンドウToolStripMenuItem.Name = "監査ウィンドウToolStripMenuItem";
            this.監査ウィンドウToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.監査ウィンドウToolStripMenuItem.Text = "監査ウィンドウ (&O)";
            this.監査ウィンドウToolStripMenuItem.Click += new System.EventHandler(this.監査ウィンドウToolStripMenuItem_Click);
            // 
            // 箱管理ToolStripMenuItem
            // 
            this.箱管理ToolStripMenuItem.Name = "箱管理ToolStripMenuItem";
            this.箱管理ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.箱管理ToolStripMenuItem.Text = "箱管理 (&B)";
            this.箱管理ToolStripMenuItem.Click += new System.EventHandler(this.箱管理ToolStripMenuItem_Click);
            // 
            // 福袋管理FToolStripMenuItem
            // 
            this.福袋管理FToolStripMenuItem.Name = "福袋管理FToolStripMenuItem";
            this.福袋管理FToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.福袋管理FToolStripMenuItem.Text = "福袋管理 (&F)";
            this.福袋管理FToolStripMenuItem.Click += new System.EventHandler(this.福袋管理FToolStripMenuItem_Click);
            // 
            // 返金返品ToolStripMenuItem
            // 
            this.返金返品ToolStripMenuItem.Name = "返金返品ToolStripMenuItem";
            this.返金返品ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.返金返品ToolStripMenuItem.Text = "返金・返品 (&R)";
            this.返金返品ToolStripMenuItem.Click += new System.EventHandler(this.返金返品ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // タグ自動印刷TToolStripMenuItem
            // 
            this.タグ自動印刷TToolStripMenuItem.Name = "タグ自動印刷TToolStripMenuItem";
            this.タグ自動印刷TToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.タグ自動印刷TToolStripMenuItem.Text = "タグ自動印刷 (&T)";
            this.タグ自動印刷TToolStripMenuItem.Click += new System.EventHandler(this.タグ自動印刷TToolStripMenuItem_Click);
            // 
            // タグ再印刷RToolStripMenuItem
            // 
            this.タグ再印刷RToolStripMenuItem.Name = "タグ再印刷RToolStripMenuItem";
            this.タグ再印刷RToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.タグ再印刷RToolStripMenuItem.Text = "タグ再印刷 (&R)";
            this.タグ再印刷RToolStripMenuItem.Click += new System.EventHandler(this.タグ再印刷RToolStripMenuItem_Click);
            // 
            // 商品一覧印刷ToolStripMenuItem
            // 
            this.商品一覧印刷ToolStripMenuItem.Name = "商品一覧印刷ToolStripMenuItem";
            this.商品一覧印刷ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.商品一覧印刷ToolStripMenuItem.Text = "商品一覧印刷";
            this.商品一覧印刷ToolStripMenuItem.Click += new System.EventHandler(this.受付票印刷ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(218, 6);
            // 
            // オペレーターIDを管理OToolStripMenuItem
            // 
            this.オペレーターIDを管理OToolStripMenuItem.Name = "オペレーターIDを管理OToolStripMenuItem";
            this.オペレーターIDを管理OToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.オペレーターIDを管理OToolStripMenuItem.Text = "オペレーターIDを管理 (&O)";
            this.オペレーターIDを管理OToolStripMenuItem.Click += new System.EventHandler(this.オペレーターIDを管理OToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(218, 6);
            // 
            // バージョン情報AToolStripMenuItem
            // 
            this.バージョン情報AToolStripMenuItem.Name = "バージョン情報AToolStripMenuItem";
            this.バージョン情報AToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.バージョン情報AToolStripMenuItem.Text = "バージョン情報 (&A)";
            // 
            // button_receipt
            // 
            this.button_receipt.Location = new System.Drawing.Point(12, 30);
            this.button_receipt.Name = "button_receipt";
            this.button_receipt.Size = new System.Drawing.Size(99, 23);
            this.button_receipt.TabIndex = 5;
            this.button_receipt.Text = "新Receipt (F3)";
            this.button_receipt.UseVisualStyleBackColor = true;
            this.button_receipt.Click += new System.EventHandler(this.button_receipt_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(215, 30);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 6;
            this.button_refresh.Text = "更新 (F5)";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // label_company
            // 
            this.label_company.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_company.AutoSize = true;
            this.label_company.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_company.Location = new System.Drawing.Point(480, 35);
            this.label_company.Name = "label_company";
            this.label_company.Size = new System.Drawing.Size(81, 12);
            this.label_company.TabIndex = 12;
            this.label_company.Text = "CompanyName";
            // 
            // button_tagprint
            // 
            this.button_tagprint.Location = new System.Drawing.Point(296, 30);
            this.button_tagprint.Name = "button_tagprint";
            this.button_tagprint.Size = new System.Drawing.Size(61, 23);
            this.button_tagprint.TabIndex = 13;
            this.button_tagprint.Text = "タグ印刷";
            this.button_tagprint.UseVisualStyleBackColor = true;
            this.button_tagprint.Click += new System.EventHandler(this.button_tagprint_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.button_webregist);
            this.splitContainer1.Panel1.Controls.Add(this.button_all);
            this.splitContainer1.Panel1.Controls.Add(this.label_company);
            this.splitContainer1.Panel1.Controls.Add(this.button_tagprint);
            this.splitContainer1.Panel1.Controls.Add(this.button_receipt);
            this.splitContainer1.Panel1.Controls.Add(this.button_refresh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(623, 327);
            this.splitContainer1.SplitterDistance = 59;
            this.splitContainer1.TabIndex = 14;
            // 
            // button_webregist
            // 
            this.button_webregist.Location = new System.Drawing.Point(117, 30);
            this.button_webregist.Name = "button_webregist";
            this.button_webregist.Size = new System.Drawing.Size(92, 23);
            this.button_webregist.TabIndex = 15;
            this.button_webregist.Text = "Web登録 (F4)";
            this.button_webregist.UseVisualStyleBackColor = true;
            this.button_webregist.Click += new System.EventHandler(this.button_webregist_Click);
            // 
            // button_all
            // 
            this.button_all.Location = new System.Drawing.Point(363, 30);
            this.button_all.Name = "button_all";
            this.button_all.Size = new System.Drawing.Size(75, 23);
            this.button_all.TabIndex = 14;
            this.button_all.Text = "全ての商品";
            this.button_all.UseVisualStyleBackColor = true;
            this.button_all.Click += new System.EventHandler(this.button_all_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_count,
            this.toolStripStatusLabel_sellcount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 242);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(623, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_count
            // 
            this.toolStripStatusLabel_count.AutoSize = false;
            this.toolStripStatusLabel_count.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_count.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_count.Name = "toolStripStatusLabel_count";
            this.toolStripStatusLabel_count.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel_count.Text = "商品数:";
            this.toolStripStatusLabel_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_sellcount
            // 
            this.toolStripStatusLabel_sellcount.AutoSize = false;
            this.toolStripStatusLabel_sellcount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_sellcount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_sellcount.Name = "toolStripStatusLabel_sellcount";
            this.toolStripStatusLabel_sellcount.Size = new System.Drawing.Size(160, 17);
            this.toolStripStatusLabel_sellcount.Text = "売上:";
            this.toolStripStatusLabel_sellcount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 各部門の返金額合算ToolStripMenuItem
            // 
            this.各部門の返金額合算ToolStripMenuItem.Name = "各部門の返金額合算ToolStripMenuItem";
            this.各部門の返金額合算ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.各部門の返金額合算ToolStripMenuItem.Text = "各部門の売上額合算 (&G)";
            this.各部門の返金額合算ToolStripMenuItem.Click += new System.EventHandler(this.各部門の返金額合算ToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(623, 239);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 327);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem データToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 機能ToolStripMenuItem;
        private System.Windows.Forms.Button button_receipt;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.ToolStripMenuItem 部門設定を変更ToolStripMenuItem;
        private System.Windows.Forms.Label label_company;
        private System.Windows.Forms.Button button_tagprint;
        private System.Windows.Forms.ToolStripMenuItem 新Receiptを追加FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最新の情報に更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 箱管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 箱に商品を追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem タグ印刷PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ページ設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ログアウトLToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ReceiptGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem タグ自動印刷TToolStripMenuItem;
        private System.Windows.Forms.Button button_all;
        private System.Windows.Forms.ToolStripMenuItem タグ再印刷RToolStripMenuItem;
        private System.Windows.Forms.Button button_webregist;
        private System.Windows.Forms.ToolStripMenuItem 商品一覧印刷ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem オペレーターIDを管理OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 売却ウィンドウSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 福袋管理FToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 監査ウィンドウToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_count;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_sellcount;
        private System.Windows.Forms.ToolStripMenuItem 返金返品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 各部門の返金額合算ToolStripMenuItem;

    }
}