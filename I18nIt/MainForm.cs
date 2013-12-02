using System;
using System.Windows.Forms;

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
                fm.LoadResourceFileAndFillView(lvBaseList, openFileDialog.FileName);
            }
        }

        private void scContent_Paint(object sender, PaintEventArgs e)
        {
            lvBaseList.Columns[0].Width = lvBaseList.Width - FixPading;
            lvTranslateList.Columns[0].Width = lvTranslateList.Width - FixPading;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var ch = new ColumnHeader("Base String") {Width = lvBaseList.Width - FixPading};
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
                fm.LoadResourceFileAndFillView(lvTranslateList, openFileDialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lvBaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBaseList.Focused)
            {
                CascadingSelected(lvBaseList, lvTranslateList);
            }
        }

        private void lvTranslateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTranslateList.Focused)
            {
                CascadingSelected(lvTranslateList, lvBaseList);
            }
        }

        private void lvBaseList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditText(lvBaseList);
        }

        private void lvTranslateList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditText(lvTranslateList);
        }

        private static void CascadingSelected(ListView baseList, ListView translateList)
        {
            ListView.SelectedListViewItemCollection selectedItems = baseList.SelectedItems;
            if (selectedItems.Count != 0)
            {
                string name = selectedItems[0].Name;
                ListViewItem[] listViewItems = translateList.Items.Find(name, true);
                if (listViewItems.Length > 0)
                {
                    translateList.SelectedItems.Clear();
                    var selectedItem = listViewItems[0];
                    selectedItem.Selected = true;
                    selectedItem.EnsureVisible();
                }
            }
        }

        private static void EditText(ListView lv)
        {
            lv.LabelEdit = true;
            ListViewItem selectedItem = lv.SelectedItems[0];
            selectedItem.BeginEdit();
        }
    }
}