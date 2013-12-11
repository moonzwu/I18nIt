using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace I18nIt
{
    public class FileMenu
    {
        public void LoadResourceFileAndFillView(ListView listView, string fileName)
        {
            if (File.Exists(fileName))
            {
                listView.Items.Clear();
                ReadAndFill(listView, fileName);
            }
        }

        private static void ReadAndFill(ListView listView, string fileName)
        {
            var keyTexts = new ListView.ListViewItemCollection(listView);
            var stringResourceLoader = new StringResourceLoader();
            if (stringResourceLoader.LoadFile(fileName))
            {
                foreach ( var keyvalue in stringResourceLoader.ResourceStringsDictionary )
                {
                    keyTexts.Add(keyvalue.Key, keyvalue.Value, 0);
                }
            }
        }
    }
}
