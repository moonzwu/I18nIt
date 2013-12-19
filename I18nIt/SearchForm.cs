using System;
using System.Windows.Forms;

namespace I18nIt
{
    public partial class SearchForm : Form
    {
        public string SearchKeyword
        {
            get;
            private set;
        }

        public bool IsSearchingInTranslateFile
        {
            get;
            private set;
        }

        public SearchForm()
        {
            IsSearchingInTranslateFile = false;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchKeyword = tbxKeywords.Text;
            IsSearchingInTranslateFile = ckbInRight.Checked;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCanncel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbxKeywords_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            ckbInRight.Checked = IsSearchingInTranslateFile;
        }

        private void SearchForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCanncel_Click(sender, e);
            }
        }
    }
}
