using System;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
=======
using System.Linq;
using System.Security.AccessControl;
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
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

<<<<<<< HEAD
        public static StringResourceType DecideResourceType(string file)
        {
            var extension = Path.GetExtension(file);
            if (!File.Exists(file) || extension == null) return StringResourceType.Unknown;
            if (extension.Equals(".properties", StringComparison.InvariantCultureIgnoreCase))
            {
                return StringResourceType.JavaStyle;
=======
        public static StringResouceType DecideResourceType(string file)
        {
            var extension = Path.GetExtension(file);
            if (!File.Exists(file) || extension == null) return StringResouceType.Unknown;
            if (extension.Equals(".properties", StringComparison.InvariantCultureIgnoreCase))
            {
                return StringResouceType.JavaStyle;
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
            }

            if (extension.Equals(".mpx", StringComparison.InvariantCultureIgnoreCase))
            {
<<<<<<< HEAD
                return StringResourceType.MPStyle;
            }
            return StringResourceType.Unknown;
=======
                return StringResouceType.MPStyle;
            }
            return StringResouceType.Unknown;
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
        }

        public Boolean LoadFile(string file)
        {
            var type = DecideResourceType(file);
            _loadedFile = file;
            switch (type)
            {
<<<<<<< HEAD
                case StringResourceType.JavaStyle:
                    return LoadJavaResource(file);
                case StringResourceType.MPStyle:
=======
                case StringResouceType.JavaStyle:
                    return LoadJavaResource(file);
                case StringResouceType.MPStyle:
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
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

<<<<<<< HEAD
        protected bool LoadMpResource(string file)
=======
        private bool LoadMpResource(string file)
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
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
<<<<<<< HEAD
                case StringResourceType.JavaStyle:
                     SaveJavaResource(_loadedFile);
                    break;
                case StringResourceType.MPStyle:
=======
                case StringResouceType.JavaStyle:
                     SaveJavaResource(_loadedFile);
                    break;
                case StringResouceType.MPStyle:
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
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
                else
                {
                    AddNewDisplayStringElement(xmlDocument, keys, resource);
                }
            }

            xmlDocument.Save(loadedFile);
        }

        private static void AddNewDisplayStringElement(XmlDocument xmlDocument, IList<string> keys, KeyValuePair<string, string> resource)
        {
            var newDisplayString = xmlDocument.CreateNode(XmlNodeType.Element, "DisplayString", null);
            var elementId = xmlDocument.CreateAttribute("ElementID");
            elementId.Value = keys[0];
            if (newDisplayString.Attributes != null)
            {
                newDisplayString.Attributes.Append(elementId);
            }

            if (keys.Count > 1)
            {
                var subElement = xmlDocument.CreateAttribute("SubElementID");
                subElement.Value = keys[1];
                if (newDisplayString.Attributes != null)
                {
                    newDisplayString.Attributes.Append(subElement);
                }
            }

            var nameElement = xmlDocument.CreateNode(XmlNodeType.Element, "Name", null);
            nameElement.InnerText = resource.Value;
            newDisplayString.AppendChild(nameElement);
            var stringsElement = xmlDocument.SelectSingleNode("//DisplayStrings");
            if (stringsElement != null)
                stringsElement.AppendChild(newDisplayString);
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
