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
        public void LoadBaseFileAndFillBaseView(ListView listView, string fileName)
        {
            if (File.Exists(fileName))
            {
                var keyTexts = new ListView.ListViewItemCollection(listView);
                using (TextReader textReader = new StreamReader(fileName, Encoding.UTF8))
                {
                    string line;
                    while ((line = textReader.ReadLine()) != null)
                    {
                        if (!ResourceLineValidator.IsValidLine(line))
                        {
                            continue;
                        }

                        var keyAndText = line.Split('=');
                        keyTexts.Add(keyAndText[0], keyAndText[1], 0);
                    }
                }
            }
        }
    }
}
