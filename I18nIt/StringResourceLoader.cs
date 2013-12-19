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
        private string _loadedFile;

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
            _loadedFile = file;
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
                var subkey = stringNode.Attributes["SubElementID"];
                var text = stringNode.FirstChild;
                if (text != null) {  
                    ResourceStringsDictionary.Add(
                        subkey != null ? key.Value + "$" + subkey.Value : key.Value,
                        text.InnerText);
                }
            }
            return true;
        }

        public void Save()
        {
            var type = DecideResourceType(_loadedFile);
            switch (type)
            {
                case StringResouceType.JavaStyle:
                     SaveJavaResource(_loadedFile);
                    break;
                case StringResouceType.MPStyle:
                     SaveMpResource(_loadedFile);
                    break;
            }
        }

        private void SaveMpResource(string loadedFile)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(loadedFile);
            DeleteIfExists(loadedFile);
            foreach (var resource in _resourceStringsDictionary)
            {
                var keys = resource.Key.Split('$');
                var queryString = keys.Length > 1 
                    ? String.Format("//DisplayString[@ElementID='{0}'][@SubElementID='{1}']/Name", keys[0], keys[1]) 
                    : String.Format("//DisplayString[@ElementID='{0}']/Name", resource.Key);

                var targetNode = xmlDocument.SelectSingleNode(queryString);
                if (targetNode != null)
                {
                    targetNode.InnerText = resource.Value;
                }
            }

            xmlDocument.Save(loadedFile);
        }

        private void SaveJavaResource(string loadedFile)
        {
            DeleteIfExists(loadedFile);

            using (var stringWriter = new StreamWriter(loadedFile, true, Encoding.UTF8))
            {
                foreach (var resource in _resourceStringsDictionary)
                {
                    stringWriter.WriteLine(@"{0}={1}", resource.Key, resource.Value);
                }
            }
        }

        private static void DeleteIfExists(string loadedFile)
        {
            var fileInfo = new FileInfo(loadedFile);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}
