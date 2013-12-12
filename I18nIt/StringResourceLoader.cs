using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Xml;

namespace I18nIt
{
    public class StringResourceLoader
    {
        private readonly Dictionary<string, string> _resourceStringsDictionary = new Dictionary<string, string>();
        private string _resourceFileName;

        public string ResourceFileName
        {
            get { return _resourceFileName; }
        }

        public Dictionary<string, string> ResourceStringsDictionary
        {
            get { return _resourceStringsDictionary; }
        }

        public static StringResouceType DecideResourceType(string file)
        {
            var extension = Path.GetExtension(file);
            if (!File.Exists(file) || extension == null) return StringResouceType.Unknown;
            if (extension.Equals(".properties", StringComparison.InvariantCultureIgnoreCase))
            {
                return StringResouceType.JavaStyle;
            }

            if (extension.Equals(".mpx", StringComparison.InvariantCultureIgnoreCase))
            {
                return StringResouceType.MPStyle;
            }
            return StringResouceType.Unknown;
        }

        public Boolean LoadFile(string file)
        {
            var type = DecideResourceType(file);
            _resourceFileName = file;
            switch (type)
            {
                case StringResouceType.JavaStyle:
                    return LoadJavaResource(file);
                case StringResouceType.MPStyle:
                    return LoadMpResource(file);
                default:
                    return false;
            }
        }

        private bool LoadJavaResource(string file)
        {
            using (TextReader textReader = new StreamReader(file, Encoding.UTF8))
            {
                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    if (!ResourceLineValidator.IsValidLine(line))
                    {
                        continue;
                    }

                    var keyAndText = line.Split('=');
                    _resourceStringsDictionary.Add(keyAndText[0], keyAndText[1]);
                }
                return true;
            }
        }

        private bool LoadMpResource(string file)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(file);
            var xmlNodeList = xmlDocument.SelectNodes("//DisplayString");
            if (xmlNodeList == null) return false;

            foreach (XmlNode stringNode in xmlNodeList)
            {
                if (stringNode.Attributes == null) continue;
                
                var key = stringNode.Attributes["ElementID"];
                var text = stringNode.SelectSingleNode("//Name");
                if (text != null) {  
                    ResourceStringsDictionary.Add(key.Value, text.InnerText);
                }
            }
            return true;
        }
    }
}
