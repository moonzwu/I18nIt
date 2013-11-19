using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace I18nIt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadBaseFileAndFillBaseView(lvBaseList, openFileDialog.FileName);
            }
        }

        private static void LoadBaseFileAndFillBaseView(ListView listView, string fileName)
        {
            if (File.Exists(fileName))
            {
                var keyTexts = new ListView.ListViewItemCollection(listView);
                TextReader textReader = new StreamReader(fileName, Encoding.UTF8);
                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    var keyAndText = line.Split('=');
                    keyTexts.Add(keyAndText[0], keyAndText[1], 0);
                }
            }
        }
    }
}
