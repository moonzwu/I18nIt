namespace I18nIt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenBaseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenTranslateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miCloneFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpcaselowcaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.lvBaseList = new System.Windows.Forms.ListView();
            this.lvTranslateList = new System.Windows.Forms.ListView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripId = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateToolStripTimer = new System.Windows.Forms.Timer(this.components);
            this.cmsPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menubar.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cmsPopup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menubar
            // 
            this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.validationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menubar.Location = new System.Drawing.Point(0, 0);
            this.menubar.Name = "menubar";
            this.menubar.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menubar.Size = new System.Drawing.Size(1125, 28);
            this.menubar.TabIndex = 0;
            this.menubar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenBaseFile,
            this.miOpenTranslateFile,
            this.toolStripSeparator2,
            this.miCloneFile,
            this.toolStripSeparator3,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miOpenBaseFile
            // 
            this.miOpenBaseFile.Name = "miOpenBaseFile";
            this.miOpenBaseFile.Size = new System.Drawing.Size(227, 24);
            this.miOpenBaseFile.Text = "Open Base File";
            this.miOpenBaseFile.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // miOpenTranslateFile
            // 
            this.miOpenTranslateFile.Name = "miOpenTranslateFile";
            this.miOpenTranslateFile.Size = new System.Drawing.Size(227, 24);
            this.miOpenTranslateFile.Text = "Open Translated File";
            this.miOpenTranslateFile.Click += new System.EventHandler(this.miOpenTranslateFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(224, 6);
            // 
            // miCloneFile
            // 
            this.miCloneFile.Name = "miCloneFile";
            this.miCloneFile.Size = new System.Drawing.Size(227, 24);
            this.miCloneFile.Text = "Clone Base File";
            this.miCloneFile.Click += new System.EventHandler(this.miCloneFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 24);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.findToolStripMenuItem.Text = "Search";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // validationToolStripMenuItem
            // 
            this.validationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.checkUpcaselowcaseToolStripMenuItem,
            this.checkNewToolStripMenuItem});
            this.validationToolStripMenuItem.Name = "validationToolStripMenuItem";
            this.validationToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.validationToolStripMenuItem.Text = "Validation";
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.checkToolStripMenuItem.Text = "Check delimiter";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // checkUpcaselowcaseToolStripMenuItem
            // 
            this.checkUpcaselowcaseToolStripMenuItem.Name = "checkUpcaselowcaseToolStripMenuItem";
            this.checkUpcaselowcaseToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.checkUpcaselowcaseToolStripMenuItem.Text = "Check upcase/lowcase";
            this.checkUpcaselowcaseToolStripMenuItem.Click += new System.EventHandler(this.checkUpcaselowcaseToolStripMenuItem_Click);
            // 
            // checkNewToolStripMenuItem
            // 
            this.checkNewToolStripMenuItem.Name = "checkNewToolStripMenuItem";
            this.checkNewToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.checkNewToolStripMenuItem.Text = "Check new items";
            this.checkNewToolStripMenuItem.Click += new System.EventHandler(this.checkNewToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 28);
            this.scContent.Margin = new System.Windows.Forms.Padding(4);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.lvBaseList);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.lvTranslateList);
            this.scContent.Size = new System.Drawing.Size(1125, 589);
            this.scContent.SplitterDistance = 371;
            this.scContent.SplitterWidth = 5;
            this.scContent.TabIndex = 1;
            this.scContent.Paint += new System.Windows.Forms.PaintEventHandler(this.scContent_Paint);
            // 
            // lvBaseList
            // 
            this.lvBaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBaseList.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvBaseList.FullRowSelect = true;
            this.lvBaseList.GridLines = true;
            this.lvBaseList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvBaseList.HideSelection = false;
            this.lvBaseList.LabelEdit = true;
            this.lvBaseList.Location = new System.Drawing.Point(0, 0);
            this.lvBaseList.Margin = new System.Windows.Forms.Padding(4);
            this.lvBaseList.Name = "lvBaseList";
            this.lvBaseList.Size = new System.Drawing.Size(371, 589);
            this.lvBaseList.TabIndex = 0;
            this.lvBaseList.UseCompatibleStateImageBehavior = false;
            this.lvBaseList.View = System.Windows.Forms.View.Details;
            this.lvBaseList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvBaseList_AfterLabelEdit);
            this.lvBaseList.SelectedIndexChanged += new System.EventHandler(this.lvBaseList_SelectedIndexChanged);
            this.lvBaseList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvBaseList_MouseDoubleClick);
            this.lvBaseList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvBaseList_MouseDown);
            // 
            // lvTranslateList
            // 
            this.lvTranslateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTranslateList.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvTranslateList.FullRowSelect = true;
            this.lvTranslateList.GridLines = true;
            this.lvTranslateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvTranslateList.HideSelection = false;
            this.lvTranslateList.LabelEdit = true;
            this.lvTranslateList.Location = new System.Drawing.Point(0, 0);
            this.lvTranslateList.Margin = new System.Windows.Forms.Padding(4);
            this.lvTranslateList.Name = "lvTranslateList";
            this.lvTranslateList.Size = new System.Drawing.Size(749, 589);
            this.lvTranslateList.TabIndex = 1;
            this.lvTranslateList.UseCompatibleStateImageBehavior = false;
            this.lvTranslateList.View = System.Windows.Forms.View.Details;
            this.lvTranslateList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvTranslateList_AfterLabelEdit);
            this.lvTranslateList.SelectedIndexChanged += new System.EventHandler(this.lvTranslateList_SelectedIndexChanged);
            this.lvTranslateList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTranslateList_MouseDoubleClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripId});
            this.statusStrip.Location = new System.Drawing.Point(0, 617);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1125, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "status";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripId
            // 
            this.toolStripId.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripId.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripId.Name = "toolStripId";
            this.toolStripId.Size = new System.Drawing.Size(4, 17);
            this.toolStripId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updateToolStripTimer
            // 
            this.updateToolStripTimer.Enabled = true;
            this.updateToolStripTimer.Interval = 1500;
            this.updateToolStripTimer.Tick += new System.EventHandler(this.updateToolStripTimer_Tick);
            // 
            // cmsPopup
            // 
            this.cmsPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToToolStripMenuItem,
            this.removeThisToolStripMenuItem});
            this.cmsPopup.Name = "cmsPopup";
            this.cmsPopup.Size = new System.Drawing.Size(223, 52);
            // 
            // addToToolStripMenuItem
            // 
            this.addToToolStripMenuItem.Name = "addToToolStripMenuItem";
            this.addToToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.addToToolStripMenuItem.Text = "Add to translate file";
            this.addToToolStripMenuItem.Click += new System.EventHandler(this.addToToolStripMenuItem_Click);
            // 
            // removeThisToolStripMenuItem
            // 
            this.removeThisToolStripMenuItem.Name = "removeThisToolStripMenuItem";
            this.removeThisToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.removeThisToolStripMenuItem.Text = "Remove this";
            this.removeThisToolStripMenuItem.Click += new System.EventHandler(this.removeThisToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 639);
            this.Controls.Add(this.scContent);
            this.Controls.Add(this.menubar);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menubar;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "I18nIt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menubar.ResumeLayout(false);
            this.menubar.PerformLayout();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cmsPopup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menubar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miOpenBaseFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUpcaselowcaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem miOpenTranslateFile;
        private System.Windows.Forms.ListView lvBaseList;
        private System.Windows.Forms.ListView lvTranslateList;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Timer updateToolStripTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripId;
        private System.Windows.Forms.ContextMenuStrip cmsPopup;
        private System.Windows.Forms.ToolStripMenuItem addToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCloneFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

