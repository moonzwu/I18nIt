using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace I18nIt
{
    public partial class MainForm : Form
    {
        private const int FixPading = 5;
        private string _baseFileName = "";
        private PersistenceSync _sync;
        private string _translateFileName = "";

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
                _baseFileName = openFileDialog.FileName;
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

            _sync = new PersistenceSync();
        }

        private void miOpenTranslateFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fm = new FileMenu();
                fm.LoadResourceFileAndFillView(lvTranslateList, openFileDialog.FileName);
                _translateFileName = openFileDialog.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sync.SaveAll();
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
                    ListViewItem selectedItem = listViewItems[0];
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

        private void lvBaseList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            UpdateToCache(sender, e, _baseFileName);
        }

        private void lvTranslateList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            UpdateToCache(sender, e, _translateFileName);
        }

        private static void UpdateToCache(object sender, LabelEditEventArgs e, string fileName)
        {
            StringResourceCache stringResourceCache = StringResourceCache.GetInstance();
            var listView = (ListView) sender;
            stringResourceCache.Update(fileName, listView.FocusedItem.Name, e.Label);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sync.SaveAll();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _sync.SaveAll();
            lvBaseList.Items.Clear();
            lvTranslateList.Items.Clear();
            StringResourceCache.GetInstance().Clear();
        }

        private void updateToolStripTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = _sync.StatusLabel;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            DialogResult dialogResult = searchForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(searchForm.SearchKeyword)) return;

                SearchKeyword(searchForm.SearchKeyword,
                    searchForm.IsSearchingInTranslateFile ? lvTranslateList : lvBaseList);
            }
        }

        private static void SearchKeyword(string keyword, ListView targetList)
        {
            foreach (
                ListViewItem item in targetList.Items.Cast<ListViewItem>().Where(item => item.Text.Contains(keyword)))
            {
                item.BackColor = Color.Aquamarine;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                findToolStripMenuItem_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                ResetBackColor(lvBaseList);
                ResetBackColor(lvTranslateList);
            }
        }

        private static void ResetBackColor(ListView targetList)
        {
            foreach (ListViewItem item in targetList.Items)
            {
                item.BackColor = targetList.BackColor;
            }
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stringResourceLoader =
                StringResourceCache.GetInstance().GetResourceLoader(_translateFileName);
            if (_translateFileName.ToLower().Contains("chinese"))
            {
                var chineseValidater = new ChineseValidater();
                var errorList = chineseValidater.CheckDelimiter(stringResourceLoader.ResourceStringsDictionary);
                foreach (
                    var item in
                        lvTranslateList.Items.Cast<ListViewItem>().Where(item => errorList.Contains(item.Name)))
                {
                    item.BackColor = Color.Red;
                }
            }
        }

        private void checkUpcaselowcaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckSentenceOnLanguage(_translateFileName, lvTranslateList);
            CheckSentenceOnLanguage(_baseFileName, lvBaseList);
        }

        private void CheckSentenceOnLanguage(string fileName, ListView viewList)
        {
            var stringResourceLoader =
                StringResourceCache.GetInstance().GetResourceLoader(fileName);
            var baseValidater = new BaseValidater();
            var errorList = baseValidater.CheckSentence(stringResourceLoader.ResourceStringsDictionary);
            foreach (
                var item in viewList.Items.Cast<ListViewItem>().Where(item => errorList.Contains(item.Name)))
            {
                item.BackColor = Color.Red;
            }
        }
    }
}