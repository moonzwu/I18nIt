using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace I18nIt
{
    public partial class CloneForm : Form
    {
        public string TranslateFileName
        {
            get;
            private set;
        }

        public CloneForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TranslateFileName = tbxFileName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCanncel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CloneForm_Load(object sender, EventArgs e)
        {

        }
    }
}
