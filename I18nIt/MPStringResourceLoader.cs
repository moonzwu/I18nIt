using System.Xml;

namespace I18nIt
{
    public class MPStringResourceLoader : StringResourceLoader
    {
        private readonly string _fileName;
        private readonly XmlDocument _xmlDocument;

        public string Language
        {
            set
            {
                var languageNode = _xmlDocument.SelectSingleNode("//LanguagePack");
                if (languageNode != null)
                {
                    var idAttr = languageNode.Attributes["ID"];
                    idAttr.Value = value;
                    var defaultAttr = languageNode.Attributes["IsDefault"];
                    defaultAttr.Value = "false";
                    _xmlDocument.Save(_fileName);
                }
            }

            get
            {
                var languageNode = _xmlDocument.SelectSingleNode("//LanguagePack");
                if (languageNode != null)
                {
                    var idAttr = languageNode.Attributes["ID"];
                    return idAttr.Value;
                }
                return "";
            }
        }

        public MPStringResourceLoader(string fileName)
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(fileName);
            _fileName = fileName;
        }
    }
}
