using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace I18nIt
{
    public partial class MainForm : Form
    {
        private const int FixPading = 5;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fm = new FileMenu();
                fm.LoadBaseFileAndFillBaseView(lvBaseList, openFileDialog.FileName);
            }
        }

        private void scContent_Paint(object sender, PaintEventArgs e)
        {
            lvBaseList.Columns[0].Width = lvBaseList.Width - FixPading;
            lvTranslateList.Columns[0].Width = lvTranslateList.Width - FixPading;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var ch = new ColumnHeader("Base String") { Width = lvBaseList.Width - FixPading };
            lvBaseList.Columns.Add(ch);
            var ch2 = new ColumnHeader("Translate String") {Width = lvTranslateList.Width - FixPading};
            lvTranslateList.Columns.Add(ch2);
        }

        private void miOpenTranslateFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fm = new FileMenu();
                fm.LoadBaseFileAndFillBaseView(lvTranslateList, openFileDialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
