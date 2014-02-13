using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using I18nIt.Properties;

namespace I18nIt
{
    public partial class MainForm : Form
    {
        private const int FixPading = 5;
        private string _baseFileName = "";
        private PersistenceSync _sync;
        private string _translatedFileName = "";

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
                _translatedFileName = openFileDialog.FileName;
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

        private void CascadingSelected(ListView baseList, ListView translateList)
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
                    toolStripId.Text = String.Format(" ID: {0}", name);
                }
            }
        }

        private static void EditText(ListView lv)
        {
            lv.LabelEdit = true;
            var selectedItem = lv.SelectedItems[0];
            selectedItem.BeginEdit();
        }

        private void lvBaseList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            UpdateToCache(sender, e, _baseFileName);
        }

        private void lvTranslateList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            UpdateToCache(sender, e, _translatedFileName);
        }

        private static void UpdateToCache(object sender, LabelEditEventArgs e, string fileName)
        {
            var stringResourceCache = StringResourceCache.GetInstance();
            var listView = (ListView) sender;
            stringResourceCache.Update(fileName, listView.FocusedItem.Name, 
                e.Label ?? listView.SelectedItems[0].Text);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sync.SaveAll();
            _baseFileName = "";
            _translatedFileName = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _sync.SaveAll();
            lvBaseList.Items.Clear();
            lvTranslateList.Items.Clear();
            StringResourceCache.GetInstance().Clear();
            _baseFileName = "";
            _translatedFileName = "";
        }

        private void updateToolStripTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = _sync.StatusLabel;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            var dialogResult = searchForm.ShowDialog();
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
                var item in targetList.Items.Cast<ListViewItem>().Where(item => item.Text.Contains(keyword)))
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
                StringResourceCache.GetInstance().GetResourceLoader(_translatedFileName);
            if (_translatedFileName.ToLower().Contains("chinese"))
            {
                var chineseValidater = new ChineseValidater();
                var errorList = chineseValidater.CheckDelimiter(stringResourceLoader.ResourceStringsDictionary);
                foreach (
                    var item in
                        lvTranslateList.Items.Cast<ListViewItem>().Where(item => errorList.Contains(item.Name)))
                {
                    item.BackColor = Color.Yellow;
                }
            }
        }

        private void checkUpcaselowcaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(_translatedFileName))
            {
                CheckSentenceOnLanguage(_translatedFileName, lvTranslateList);
            }

            if (!String.IsNullOrEmpty(_baseFileName))
            {
                CheckSentenceOnLanguage(_baseFileName, lvBaseList);
            }
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
                item.BackColor = Color.Yellow;
            }
        }

        private void lvBaseList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvBaseList.SelectedItems.Count > 0)
            {
                cmsPopup.Show(lvBaseList, new Point(e.X, e.Y));
            }
        }

        private void addToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_translatedFileName))
            {
                MessageBox.Show(Resources.Text_please_create_a_translate_file_first_);
                return;
            }

            var stringkey = lvBaseList.SelectedItems[0].Name;
            var text = lvBaseList.SelectedItems[0].Text;
            var stringResourceCache = StringResourceCache.GetInstance();
            var isExisted = stringResourceCache.Check(_translatedFileName, stringkey);
            if (isExisted)
            {
                MessageBox.Show(Resources.Text_the_item_has_existed_in_translate_file__could_not_be_created_);
                return;
            }

            var createdItem = lvTranslateList.Items.Add(stringkey, text, 0);
            createdItem.Selected = true;
            stringResourceCache.Update(_translatedFileName, stringkey, text);
        }

        private void removeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvBaseList.SelectedItems.Count > 0)
            {
                var removedItem = lvBaseList.SelectedItems[0];
                lvBaseList.Items.RemoveByKey(removedItem.Name);
                lvTranslateList.Items.RemoveByKey(removedItem.Name);
                var stringResourceCache = StringResourceCache.GetInstance();
                stringResourceCache.Remove(_baseFileName, removedItem.Name);
                stringResourceCache.Remove(_translatedFileName, removedItem.Name);
            }
        }

        private void miCloneFile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_baseFileName))
            {
                MessageBox.Show(Resources.Text_please_open_the_base_file_first_);
                return;
            }

            if (!String.IsNullOrEmpty(_translatedFileName))
            {
                MessageBox.Show(Resources.Text_Translate_file_has_existed__Can_t_clone_base_file_);
                return;
            }

            var cloneForm = new CloneForm(_baseFileName);
            if (cloneForm.ShowDialog() == DialogResult.OK)
            {
                _translatedFileName = cloneForm.TranslateFileName;
                new FileMenu().LoadResourceFileAndFillView(lvTranslateList, _translatedFileName);
            }
        }

        private void checkNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_baseFileName) || String.IsNullOrEmpty(_translatedFileName))
            {
                MessageBox.Show(Resources.Text_Please_open_the_base_file_and_translated_file_together_first_);
                return;
            }

            var cache = StringResourceCache.GetInstance();
            var baseLoader = cache.GetResourceLoader(_baseFileName);
            var translatedLoader = cache.GetResourceLoader(_translatedFileName);
            var baseValidater = new BaseValidater();
            var newItems = baseValidater.CheckNewItems(baseLoader.ResourceStringsDictionary,
                translatedLoader.ResourceStringsDictionary);
            foreach (
                var item in lvBaseList.Items.Cast<ListViewItem>().Where(item => newItems.Contains(item.Name)))
            {
                item.BackColor = Color.LightGreen;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }


        private void miExportExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_baseFileName) || string.IsNullOrEmpty(_translatedFileName))
            {
                MessageBox.Show(Resources.text_Please_open_the_base_file_and_translate_file_first);
                return;
            }

            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = saveFileDialog.FileName;
                var cache = StringResourceCache.GetInstance();
                var enDic = cache.GetResourceLoader(_baseFileName).ResourceStringsDictionary;
                var cnDic = cache.GetResourceLoader(_translatedFileName).ResourceStringsDictionary;
                var documentConverter = new DocumentConverter();
                var isSucceed = documentConverter.ExportToExcel(fileName, enDic, cnDic);
                MessageBox.Show(isSucceed ? Resources.Text_Export_succeed_ : Resources.Text_Export_failed_);
            }
        }
    }
}