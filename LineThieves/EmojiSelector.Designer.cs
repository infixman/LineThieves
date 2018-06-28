namespace LineThieves
{
    partial class EmojiSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmojiSelector));
            this.cb_EmojiType = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lb_EmojiType = new System.Windows.Forms.Label();
            this.pnl_EmojiList = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_EmojiType
            // 
            this.cb_EmojiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_EmojiType.FormattingEnabled = true;
            this.cb_EmojiType.Location = new System.Drawing.Point(53, 8);
            this.cb_EmojiType.Name = "cb_EmojiType";
            this.cb_EmojiType.Size = new System.Drawing.Size(172, 21);
            this.cb_EmojiType.TabIndex = 0;
            this.cb_EmojiType.SelectedIndexChanged += new System.EventHandler(this.cb_EmojiType_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lb_EmojiType);
            this.splitContainer1.Panel1.Controls.Add(this.cb_EmojiType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnl_EmojiList);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 442);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 1;
            // 
            // lb_EmojiType
            // 
            this.lb_EmojiType.AutoSize = true;
            this.lb_EmojiType.Location = new System.Drawing.Point(12, 11);
            this.lb_EmojiType.Name = "lb_EmojiType";
            this.lb_EmojiType.Size = new System.Drawing.Size(31, 13);
            this.lb_EmojiType.TabIndex = 1;
            this.lb_EmojiType.Text = "類型";
            // 
            // pnl_EmojiList
            // 
            this.pnl_EmojiList.AutoScroll = true;
            this.pnl_EmojiList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_EmojiList.Location = new System.Drawing.Point(0, 0);
            this.pnl_EmojiList.Name = "pnl_EmojiList";
            this.pnl_EmojiList.Size = new System.Drawing.Size(1072, 400);
            this.pnl_EmojiList.TabIndex = 0;
            // 
            // EmojiSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 442);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmojiSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LineThieves";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmojiSelector_FormClosing);
            this.Load += new System.EventHandler(this.EmojiSelector_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_EmojiType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lb_EmojiType;
        private System.Windows.Forms.Panel pnl_EmojiList;
    }
}