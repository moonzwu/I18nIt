using System;
using System.IO;
using I18nIt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace I18nItTest
{
    [TestClass]
    public class StringResourceLoaderTest
    {
        [TestMethod]
        public void Should_get_correct_resource_type_when_given_a_file_path()
        {
            const string javaResource = "com_lenovo_plugin_app.properties";
            var mpResource = "English.LanguagePack.Fragment.mpx";
            var otherResource = "abcd.xxx";

            var javaFile = CreateATempFile(javaResource);
            var resouceType1 = StringResourceLoader.DecideResourceType(javaFile);
            Assert.AreEqual(StringResouceType.JavaStyle, resouceType1);

            var mpFile = CreateATempFile(mpResource);
            var resouceType2 = StringResourceLoader.DecideResourceType(mpFile);
            Assert.AreEqual(StringResouceType.MPStyle, resouceType2);

            var otherFile = CreateATempFile(otherResource);
            var resouceType3 = StringResourceLoader.DecideResourceType(otherFile);
            Assert.AreEqual(StringResouceType.Unknown, resouceType3);
        }

        private string CreateATempFile(string name)
        {
            var fileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + name);
            using (new FileStream(fileName, FileMode.CreateNew)) { }
            return fileName;
        }
    }
}
