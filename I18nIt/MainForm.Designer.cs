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
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenBaseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenTranslateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpcaselowcaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkGrammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.lvBaseList = new System.Windows.Forms.ListView();
            this.lvTranslateList = new System.Windows.Forms.ListView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateToolStripTimer = new System.Windows.Forms.Timer(this.components);
            this.menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scContent)).BeginInit();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.miOpenBaseFile.Size = new System.Drawing.Size(217, 24);
            this.miOpenBaseFile.Text = "Open Base File";
            this.miOpenBaseFile.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // miOpenTranslateFile
            // 
            this.miOpenTranslateFile.Name = "miOpenTranslateFile";
            this.miOpenTranslateFile.Size = new System.Drawing.Size(217, 24);
            this.miOpenTranslateFile.Text = "Open Translate File";
            this.miOpenTranslateFile.Click += new System.EventHandler(this.miOpenTranslateFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 24);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
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
            this.checkGrammarToolStripMenuItem});
            this.validationToolStripMenuItem.Name = "validationToolStripMenuItem";
            this.validationToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.validationToolStripMenuItem.Text = "Validation";
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.checkToolStripMenuItem.Text = "Check delimiter";
            // 
            // checkUpcaselowcaseToolStripMenuItem
            // 
            this.checkUpcaselowcaseToolStripMenuItem.Name = "checkUpcaselowcaseToolStripMenuItem";
            this.checkUpcaselowcaseToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.checkUpcaselowcaseToolStripMenuItem.Text = "Check upcase/lowcase";
            // 
            // checkGrammarToolStripMenuItem
            // 
            this.checkGrammarToolStripMenuItem.Name = "checkGrammarToolStripMenuItem";
            this.checkGrammarToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.checkGrammarToolStripMenuItem.Text = "Check grammar";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.manToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // manToolStripMenuItem
            // 
            this.manToolStripMenuItem.Name = "manToolStripMenuItem";
            this.manToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.manToolStripMenuItem.Text = "manual";
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
            this.scContent.SplitterDistance = 374;
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
            this.lvBaseList.Size = new System.Drawing.Size(374, 589);
            this.lvBaseList.TabIndex = 0;
            this.lvBaseList.UseCompatibleStateImageBehavior = false;
            this.lvBaseList.View = System.Windows.Forms.View.Details;
            this.lvBaseList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvBaseList_AfterLabelEdit);
            this.lvBaseList.SelectedIndexChanged += new System.EventHandler(this.lvBaseList_SelectedIndexChanged);
            this.lvBaseList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvBaseList_MouseDoubleClick);
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
            this.lvTranslateList.Size = new System.Drawing.Size(746, 589);
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
            this.statusLabel});
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
            // updateToolStripTimer
            // 
            this.updateToolStripTimer.Enabled = true;
            this.updateToolStripTimer.Interval = 1500;
            this.updateToolStripTimer.Tick += new System.EventHandler(this.updateToolStripTimer_Tick);
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
            ((System.ComponentModel.ISupportInitialize)(this.scContent)).EndInit();
            this.scContent.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem checkGrammarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem miOpenTranslateFile;
        private System.Windows.Forms.ListView lvBaseList;
        private System.Windows.Forms.ListView lvTranslateList;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Timer updateToolStripTimer;
    }
}

