using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace I18nIt
{
    public partial class CloneForm : Form
    {
        private string _baseFileName;

        public string TranslateFileName
        {
            get;
            private set;
        }


        public CloneForm(string baseFileName)
        {
            _baseFileName = baseFileName;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var selectedLanguage = ((KeyValuePair<string, string>) cbxLanguage.SelectedItem).Key;
            var directoryName = Path.GetDirectoryName(_baseFileName);
            TranslateFileName = Path.Combine(directoryName, tbxFileName.Text);
            File.Copy(_baseFileName, TranslateFileName);

            var resourceType = StringResourceLoader.DecideResourceType(TranslateFileName);
            if (resourceType == StringResourceType.MPStyle)
            {
                new MPStringResourceLoader(TranslateFileName)
                {
                    Language = selectedLanguage
                };
            }

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
            var cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var locales = new Dictionary<string, string>();
            foreach (var cultureInfo in cultureInfos.Where(cultureInfo => !locales.ContainsKey(cultureInfo.ThreeLetterWindowsLanguageName)))
            {
                locales.Add(cultureInfo.ThreeLetterWindowsLanguageName, cultureInfo.DisplayName);
            }
            cbxLanguage.DataSource = new BindingSource(locales, null);
            cbxLanguage.DisplayMember = "Value";
            cbxLanguage.ValueMember = "Key";
        }
    }
}
