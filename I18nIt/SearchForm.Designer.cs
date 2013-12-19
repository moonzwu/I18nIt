namespace I18nIt
{
    partial class SearchForm
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
            this.tbxKeywords = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCanncel = new System.Windows.Forms.Button();
            this.ckbInRight = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key word:";
            // 
            // tbxKeywords
            // 
            this.tbxKeywords.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbxKeywords.Location = new System.Drawing.Point(107, 23);
            this.tbxKeywords.Name = "tbxKeywords";
            this.tbxKeywords.Size = new System.Drawing.Size(316, 25);
            this.tbxKeywords.TabIndex = 1;
            this.tbxKeywords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxKeywords_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(107, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCanncel
            // 
            this.btnCanncel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCanncel.Location = new System.Drawing.Point(255, 111);
            this.btnCanncel.Name = "btnCanncel";
            this.btnCanncel.Size = new System.Drawing.Size(93, 23);
            this.btnCanncel.TabIndex = 3;
            this.btnCanncel.Text = "Canncel";
            this.btnCanncel.UseVisualStyleBackColor = true;
            this.btnCanncel.Click += new System.EventHandler(this.btnCanncel_Click);
            // 
            // ckbInRight
            // 
            this.ckbInRight.AutoSize = true;
            this.ckbInRight.Location = new System.Drawing.Point(107, 64);
            this.ckbInRight.Name = "ckbInRight";
            this.ckbInRight.Size = new System.Drawing.Size(165, 19);
            this.ckbInRight.TabIndex = 4;
            this.ckbInRight.Text = "In Translate File";
            this.ckbInRight.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 142);
            this.Controls.Add(this.ckbInRight);
            this.Controls.Add(this.btnCanncel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxKeywords);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Searching";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxKeywords;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCanncel;
        private System.Windows.Forms.CheckBox ckbInRight;
    }
}