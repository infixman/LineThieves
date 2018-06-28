namespace LineThieves
{
    partial class LineThieves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineThieves));
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.dg_SearchResult = new System.Windows.Forms.DataGridView();
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_SelectSetOk = new System.Windows.Forms.Button();
            this.btn_SelectAllSet = new System.Windows.Forms.Button();
            this.lb_TotalCount = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txt_Page = new System.Windows.Forms.TextBox();
            this.lb_PageTitle = new System.Windows.Forms.Label();
            this.btn_PageNext = new System.Windows.Forms.Button();
            this.btn_PageBack = new System.Windows.Forms.Button();
            this.btn_PageToEnd = new System.Windows.Forms.Button();
            this.btn_PageToBegin = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btn_AddPicture = new System.Windows.Forms.Button();
            this.lb_TotleStickerCount = new System.Windows.Forms.Label();
            this.txt_SetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SetTitle = new System.Windows.Forms.TextBox();
            this.lb_Title = new System.Windows.Forms.Label();
            this.btn_ConvertSet = new System.Windows.Forms.Button();
            this.btn_SelectAllSticker = new System.Windows.Forms.Button();
            this.dg_PickSticker = new System.Windows.Forms.DataGridView();
            this.dg_PickSticker_Col_PicPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_PickSticker_Col_Pic = new System.Windows.Forms.DataGridViewImageColumn();
            this.dg_PickSticker_Col_Emoji = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_PickSticker_Col_Pick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_UserId = new System.Windows.Forms.TextBox();
            this.txt_BotName = new System.Windows.Forms.TextBox();
            this.txt_BotKey = new System.Windows.Forms.TextBox();
            this.lb_BotName = new System.Windows.Forms.Label();
            this.lb_UserId = new System.Windows.Forms.Label();
            this.lb_BotKey = new System.Windows.Forms.Label();
            this.btn_ClearSearch = new System.Windows.Forms.Button();
            this.btn_ClearSticker = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_SearchResult)).BeginInit();
            this.tab_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PickSticker)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Search
            // 
            this.txt_Search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txt_Search.Location = new System.Drawing.Point(5, 3);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(225, 20);
            this.txt_Search.TabIndex = 0;
            this.txt_Search.Enter += new System.EventHandler(this.txt_Search_Enter);
            this.txt_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Search_KeyPress);
            this.txt_Search.Leave += new System.EventHandler(this.txt_Search_Leave);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(236, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 10;
            this.btn_Search.Text = "搜尋";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dg_SearchResult
            // 
            this.dg_SearchResult.AllowUserToAddRows = false;
            this.dg_SearchResult.AllowUserToDeleteRows = false;
            this.dg_SearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_SearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_SearchResult.Location = new System.Drawing.Point(0, 0);
            this.dg_SearchResult.Name = "dg_SearchResult";
            this.dg_SearchResult.ReadOnly = true;
            this.dg_SearchResult.Size = new System.Drawing.Size(1106, 712);
            this.dg_SearchResult.TabIndex = 999;
            this.dg_SearchResult.TabStop = false;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabPage1);
            this.tab_Main.Controls.Add(this.tabPage2);
            this.tab_Main.Controls.Add(this.tabPage3);
            this.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Main.Location = new System.Drawing.Point(0, 0);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(1120, 821);
            this.tab_Main.TabIndex = 999;
            this.tab_Main.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1112, 795);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "搜尋";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_ClearSearch);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectSetOk);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectAllSet);
            this.splitContainer1.Panel1.Controls.Add(this.lb_TotalCount);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Search);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Search);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1106, 789);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // btn_SelectSetOk
            // 
            this.btn_SelectSetOk.Location = new System.Drawing.Point(544, 3);
            this.btn_SelectSetOk.Name = "btn_SelectSetOk";
            this.btn_SelectSetOk.Size = new System.Drawing.Size(70, 23);
            this.btn_SelectSetOk.TabIndex = 30;
            this.btn_SelectSetOk.Text = "選好了";
            this.btn_SelectSetOk.UseVisualStyleBackColor = true;
            this.btn_SelectSetOk.Click += new System.EventHandler(this.btn_SelectSetOk_Click);
            // 
            // btn_SelectAllSet
            // 
            this.btn_SelectAllSet.Location = new System.Drawing.Point(385, 3);
            this.btn_SelectAllSet.Name = "btn_SelectAllSet";
            this.btn_SelectAllSet.Size = new System.Drawing.Size(153, 23);
            this.btn_SelectAllSet.TabIndex = 20;
            this.btn_SelectAllSet.Text = "我全都要/我全都不要";
            this.btn_SelectAllSet.UseVisualStyleBackColor = true;
            this.btn_SelectAllSet.Click += new System.EventHandler(this.btn_SelectAllSet_Click);
            // 
            // lb_TotalCount
            // 
            this.lb_TotalCount.AutoSize = true;
            this.lb_TotalCount.Location = new System.Drawing.Point(323, 8);
            this.lb_TotalCount.Name = "lb_TotalCount";
            this.lb_TotalCount.Size = new System.Drawing.Size(37, 13);
            this.lb_TotalCount.TabIndex = 3;
            this.lb_TotalCount.Text = "共?筆";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dg_SearchResult);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txt_Page);
            this.splitContainer2.Panel2.Controls.Add(this.lb_PageTitle);
            this.splitContainer2.Panel2.Controls.Add(this.btn_PageNext);
            this.splitContainer2.Panel2.Controls.Add(this.btn_PageBack);
            this.splitContainer2.Panel2.Controls.Add(this.btn_PageToEnd);
            this.splitContainer2.Panel2.Controls.Add(this.btn_PageToBegin);
            this.splitContainer2.Size = new System.Drawing.Size(1106, 755);
            this.splitContainer2.SplitterDistance = 712;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // txt_Page
            // 
            this.txt_Page.Enabled = false;
            this.txt_Page.Location = new System.Drawing.Point(112, 11);
            this.txt_Page.Name = "txt_Page";
            this.txt_Page.Size = new System.Drawing.Size(100, 20);
            this.txt_Page.TabIndex = 999;
            this.txt_Page.TabStop = false;
            this.txt_Page.Text = "?/?";
            this.txt_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_PageTitle
            // 
            this.lb_PageTitle.AutoSize = true;
            this.lb_PageTitle.Location = new System.Drawing.Point(7, 14);
            this.lb_PageTitle.Name = "lb_PageTitle";
            this.lb_PageTitle.Size = new System.Drawing.Size(31, 13);
            this.lb_PageTitle.TabIndex = 3;
            this.lb_PageTitle.Text = "頁數";
            // 
            // btn_PageNext
            // 
            this.btn_PageNext.Location = new System.Drawing.Point(218, 9);
            this.btn_PageNext.Name = "btn_PageNext";
            this.btn_PageNext.Size = new System.Drawing.Size(28, 23);
            this.btn_PageNext.TabIndex = 35;
            this.btn_PageNext.Text = ">";
            this.btn_PageNext.UseVisualStyleBackColor = true;
            this.btn_PageNext.Click += new System.EventHandler(this.btn_PageNext_Click);
            // 
            // btn_PageBack
            // 
            this.btn_PageBack.Location = new System.Drawing.Point(78, 9);
            this.btn_PageBack.Name = "btn_PageBack";
            this.btn_PageBack.Size = new System.Drawing.Size(28, 23);
            this.btn_PageBack.TabIndex = 33;
            this.btn_PageBack.Text = "<";
            this.btn_PageBack.UseVisualStyleBackColor = true;
            this.btn_PageBack.Click += new System.EventHandler(this.btn_PageBack_Click);
            // 
            // btn_PageToEnd
            // 
            this.btn_PageToEnd.Location = new System.Drawing.Point(252, 9);
            this.btn_PageToEnd.Name = "btn_PageToEnd";
            this.btn_PageToEnd.Size = new System.Drawing.Size(28, 23);
            this.btn_PageToEnd.TabIndex = 37;
            this.btn_PageToEnd.Text = ">|";
            this.btn_PageToEnd.UseVisualStyleBackColor = true;
            this.btn_PageToEnd.Click += new System.EventHandler(this.btn_PageToEnd_Click);
            // 
            // btn_PageToBegin
            // 
            this.btn_PageToBegin.Location = new System.Drawing.Point(44, 9);
            this.btn_PageToBegin.Name = "btn_PageToBegin";
            this.btn_PageToBegin.Size = new System.Drawing.Size(28, 23);
            this.btn_PageToBegin.TabIndex = 31;
            this.btn_PageToBegin.Text = "|<";
            this.btn_PageToBegin.UseVisualStyleBackColor = true;
            this.btn_PageToBegin.Click += new System.EventHandler(this.btn_PageToBegin_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 795);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "編輯";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btn_ClearSticker);
            this.splitContainer3.Panel1.Controls.Add(this.btn_AddPicture);
            this.splitContainer3.Panel1.Controls.Add(this.lb_TotleStickerCount);
            this.splitContainer3.Panel1.Controls.Add(this.txt_SetName);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.txt_SetTitle);
            this.splitContainer3.Panel1.Controls.Add(this.lb_Title);
            this.splitContainer3.Panel1.Controls.Add(this.btn_ConvertSet);
            this.splitContainer3.Panel1.Controls.Add(this.btn_SelectAllSticker);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dg_PickSticker);
            this.splitContainer3.Size = new System.Drawing.Size(1106, 789);
            this.splitContainer3.SplitterDistance = 30;
            this.splitContainer3.TabIndex = 1;
            this.splitContainer3.TabStop = false;
            // 
            // btn_AddPicture
            // 
            this.btn_AddPicture.Location = new System.Drawing.Point(605, 3);
            this.btn_AddPicture.Name = "btn_AddPicture";
            this.btn_AddPicture.Size = new System.Drawing.Size(98, 23);
            this.btn_AddPicture.TabIndex = 55;
            this.btn_AddPicture.Text = "我要自己加圖";
            this.btn_AddPicture.UseVisualStyleBackColor = true;
            this.btn_AddPicture.Click += new System.EventHandler(this.btn_AddPicture_Click);
            // 
            // lb_TotleStickerCount
            // 
            this.lb_TotleStickerCount.AutoSize = true;
            this.lb_TotleStickerCount.Location = new System.Drawing.Point(865, 8);
            this.lb_TotleStickerCount.Name = "lb_TotleStickerCount";
            this.lb_TotleStickerCount.Size = new System.Drawing.Size(49, 13);
            this.lb_TotleStickerCount.TabIndex = 6;
            this.lb_TotleStickerCount.Text = "共選?張";
            // 
            // txt_SetName
            // 
            this.txt_SetName.Location = new System.Drawing.Point(82, 3);
            this.txt_SetName.Name = "txt_SetName";
            this.txt_SetName.Size = new System.Drawing.Size(219, 20);
            this.txt_SetName.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "貼圖包ID";
            // 
            // txt_SetTitle
            // 
            this.txt_SetTitle.Location = new System.Drawing.Point(380, 3);
            this.txt_SetTitle.Name = "txt_SetTitle";
            this.txt_SetTitle.Size = new System.Drawing.Size(219, 20);
            this.txt_SetTitle.TabIndex = 50;
            // 
            // lb_Title
            // 
            this.lb_Title.AutoSize = true;
            this.lb_Title.Location = new System.Drawing.Point(307, 8);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(67, 13);
            this.lb_Title.TabIndex = 2;
            this.lb_Title.Text = "貼圖包名稱";
            // 
            // btn_ConvertSet
            // 
            this.btn_ConvertSet.Location = new System.Drawing.Point(943, 3);
            this.btn_ConvertSet.Name = "btn_ConvertSet";
            this.btn_ConvertSet.Size = new System.Drawing.Size(75, 23);
            this.btn_ConvertSet.TabIndex = 70;
            this.btn_ConvertSet.Text = "開始轉換";
            this.btn_ConvertSet.UseVisualStyleBackColor = true;
            this.btn_ConvertSet.Click += new System.EventHandler(this.btn_ConvertSet_Click);
            // 
            // btn_SelectAllSticker
            // 
            this.btn_SelectAllSticker.Location = new System.Drawing.Point(709, 3);
            this.btn_SelectAllSticker.Name = "btn_SelectAllSticker";
            this.btn_SelectAllSticker.Size = new System.Drawing.Size(150, 23);
            this.btn_SelectAllSticker.TabIndex = 60;
            this.btn_SelectAllSticker.Text = "我全都要/我全都不要";
            this.btn_SelectAllSticker.UseVisualStyleBackColor = true;
            this.btn_SelectAllSticker.Click += new System.EventHandler(this.btn_SelectAllSticker_Click);
            // 
            // dg_PickSticker
            // 
            this.dg_PickSticker.AllowUserToAddRows = false;
            this.dg_PickSticker.AllowUserToDeleteRows = false;
            this.dg_PickSticker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_PickSticker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg_PickSticker_Col_PicPath,
            this.dg_PickSticker_Col_Pic,
            this.dg_PickSticker_Col_Emoji,
            this.dg_PickSticker_Col_Pick});
            this.dg_PickSticker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_PickSticker.Location = new System.Drawing.Point(0, 0);
            this.dg_PickSticker.Name = "dg_PickSticker";
            this.dg_PickSticker.Size = new System.Drawing.Size(1106, 755);
            this.dg_PickSticker.TabIndex = 999;
            this.dg_PickSticker.TabStop = false;
            this.dg_PickSticker.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_PickSticker_CellClick);
            this.dg_PickSticker.CurrentCellDirtyStateChanged += new System.EventHandler(this.dg_PickSticker_CurrentCellDirtyStateChanged);
            // 
            // dg_PickSticker_Col_PicPath
            // 
            this.dg_PickSticker_Col_PicPath.HeaderText = "PicPath";
            this.dg_PickSticker_Col_PicPath.Name = "dg_PickSticker_Col_PicPath";
            this.dg_PickSticker_Col_PicPath.Visible = false;
            // 
            // dg_PickSticker_Col_Pic
            // 
            this.dg_PickSticker_Col_Pic.HeaderText = "Sticker";
            this.dg_PickSticker_Col_Pic.Name = "dg_PickSticker_Col_Pic";
            // 
            // dg_PickSticker_Col_Emoji
            // 
            this.dg_PickSticker_Col_Emoji.HeaderText = "Emoji";
            this.dg_PickSticker_Col_Emoji.Name = "dg_PickSticker_Col_Emoji";
            this.dg_PickSticker_Col_Emoji.ReadOnly = true;
            this.dg_PickSticker_Col_Emoji.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_PickSticker_Col_Emoji.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dg_PickSticker_Col_Pick
            // 
            this.dg_PickSticker_Col_Pick.HeaderText = "要這張";
            this.dg_PickSticker_Col_Pick.Name = "dg_PickSticker_Col_Pick";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_UserId);
            this.tabPage3.Controls.Add(this.txt_BotName);
            this.tabPage3.Controls.Add(this.txt_BotKey);
            this.tabPage3.Controls.Add(this.lb_BotName);
            this.tabPage3.Controls.Add(this.lb_UserId);
            this.tabPage3.Controls.Add(this.lb_BotKey);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1112, 795);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TelegramBot設定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_UserId
            // 
            this.txt_UserId.Location = new System.Drawing.Point(191, 62);
            this.txt_UserId.Name = "txt_UserId";
            this.txt_UserId.Size = new System.Drawing.Size(219, 20);
            this.txt_UserId.TabIndex = 100;
            this.txt_UserId.Leave += new System.EventHandler(this.txt_UserId_Leave);
            // 
            // txt_BotName
            // 
            this.txt_BotName.Location = new System.Drawing.Point(123, 36);
            this.txt_BotName.Name = "txt_BotName";
            this.txt_BotName.Size = new System.Drawing.Size(287, 20);
            this.txt_BotName.TabIndex = 90;
            this.txt_BotName.Leave += new System.EventHandler(this.txt_BotName_Leave);
            // 
            // txt_BotKey
            // 
            this.txt_BotKey.Location = new System.Drawing.Point(123, 10);
            this.txt_BotKey.Name = "txt_BotKey";
            this.txt_BotKey.Size = new System.Drawing.Size(287, 20);
            this.txt_BotKey.TabIndex = 80;
            this.txt_BotKey.UseSystemPasswordChar = true;
            this.txt_BotKey.Leave += new System.EventHandler(this.txt_BotKey_Leave);
            // 
            // lb_BotName
            // 
            this.lb_BotName.AutoSize = true;
            this.lb_BotName.Location = new System.Drawing.Point(8, 39);
            this.lb_BotName.Name = "lb_BotName";
            this.lb_BotName.Size = new System.Drawing.Size(101, 13);
            this.lb_BotName.TabIndex = 2;
            this.lb_BotName.Text = "Telegram Bot Name";
            // 
            // lb_UserId
            // 
            this.lb_UserId.AutoSize = true;
            this.lb_UserId.Location = new System.Drawing.Point(8, 65);
            this.lb_UserId.Name = "lb_UserId";
            this.lb_UserId.Size = new System.Drawing.Size(177, 13);
            this.lb_UserId.TabIndex = 1;
            this.lb_UserId.Text = "Telegram Sticker Set Owner User Id";
            // 
            // lb_BotKey
            // 
            this.lb_BotKey.AutoSize = true;
            this.lb_BotKey.Location = new System.Drawing.Point(8, 13);
            this.lb_BotKey.Name = "lb_BotKey";
            this.lb_BotKey.Size = new System.Drawing.Size(109, 13);
            this.lb_BotKey.TabIndex = 0;
            this.lb_BotKey.Text = "Telegram Bot Api Key";
            // 
            // btn_ClearSearch
            // 
            this.btn_ClearSearch.Location = new System.Drawing.Point(620, 3);
            this.btn_ClearSearch.Name = "btn_ClearSearch";
            this.btn_ClearSearch.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearSearch.TabIndex = 35;
            this.btn_ClearSearch.Text = "清空";
            this.btn_ClearSearch.UseVisualStyleBackColor = true;
            this.btn_ClearSearch.Click += new System.EventHandler(this.btn_ClearSearch_Click);
            // 
            // btn_ClearSticker
            // 
            this.btn_ClearSticker.Location = new System.Drawing.Point(1024, 3);
            this.btn_ClearSticker.Name = "btn_ClearSticker";
            this.btn_ClearSticker.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearSticker.TabIndex = 80;
            this.btn_ClearSticker.Text = "清空";
            this.btn_ClearSticker.UseVisualStyleBackColor = true;
            this.btn_ClearSticker.Click += new System.EventHandler(this.btn_ClearSticker_Click);
            // 
            // LineThieves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 821);
            this.Controls.Add(this.tab_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LineThieves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LineThieves";
            this.Load += new System.EventHandler(this.LineThieves_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_SearchResult)).EndInit();
            this.tab_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_PickSticker)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridView dg_SearchResult;
        private System.Windows.Forms.TabControl tab_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dg_PickSticker;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btn_SelectAllSticker;
        private System.Windows.Forms.Button btn_ConvertSet;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.TextBox txt_SetTitle;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lb_BotName;
        private System.Windows.Forms.Label lb_UserId;
        private System.Windows.Forms.Label lb_BotKey;
        private System.Windows.Forms.TextBox txt_UserId;
        private System.Windows.Forms.TextBox txt_BotName;
        private System.Windows.Forms.TextBox txt_BotKey;
        private System.Windows.Forms.Button btn_PageNext;
        private System.Windows.Forms.Button btn_PageBack;
        private System.Windows.Forms.Button btn_PageToEnd;
        private System.Windows.Forms.Button btn_PageToBegin;
        private System.Windows.Forms.Label lb_PageTitle;
        private System.Windows.Forms.TextBox txt_Page;
        private System.Windows.Forms.Label lb_TotalCount;
        private System.Windows.Forms.Button btn_SelectAllSet;
        private System.Windows.Forms.Button btn_SelectSetOk;
        private System.Windows.Forms.TextBox txt_SetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_TotleStickerCount;
        private System.Windows.Forms.Button btn_AddPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_PickSticker_Col_PicPath;
        private System.Windows.Forms.DataGridViewImageColumn dg_PickSticker_Col_Pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_PickSticker_Col_Emoji;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dg_PickSticker_Col_Pick;
        private System.Windows.Forms.Button btn_ClearSearch;
        private System.Windows.Forms.Button btn_ClearSticker;
    }
}

