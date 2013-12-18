using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        [TestMethod]
        public void Should_get_mp_resource_when_given_a_mpx_file()
        {
            const string mpResource = "resource/mpresource.mpx";
            var stringResourceLoader = new StringResourceLoader();
            var result = stringResourceLoader.LoadFile(mpResource);
            Assert.IsTrue(result);
            Assert.AreEqual(1, stringResourceLoader.ResourceStringsDictionary.Count);
            Assert.AreEqual("Enum.843e5d2b2f3941d882c6a5f4834e19a3", stringResourceLoader.ResourceStringsDictionary.Keys.First());
        }

        [TestMethod]
        public void Should_save_the_changed_text_to_java_resource_file()
        {
            var path = CopyToTempFolder("resource/teststringfiles.properties");
            var stringResourceLoader = new StringResourceLoader();
            stringResourceLoader.LoadFile(path);
            stringResourceLoader.ResourceStringsDictionary["name"] = "新名字";
            stringResourceLoader.Save();

            var newStringResourceLoader = new StringResourceLoader();
            newStringResourceLoader.LoadFile(path);
            Assert.AreEqual("新名字", newStringResourceLoader.ResourceStringsDictionary["name"]);
        }

        [TestMethod]
        public void Should_save_the_changed_text_to_mp_resource_file()
        {
            var path = CopyToTempFolder("resource/mpresource.mpx");
            var stringResourceLoader = new StringResourceLoader();
            stringResourceLoader.LoadFile(path);
            stringResourceLoader.ResourceStringsDictionary["Enum.843e5d2b2f3941d882c6a5f4834e19a3"] = "new text";
            stringResourceLoader.Save();

            var newStringResourceLoader = new StringResourceLoader();
            newStringResourceLoader.LoadFile(path);
            Assert.AreEqual("new text", newStringResourceLoader.ResourceStringsDictionary["Enum.843e5d2b2f3941d882c6a5f4834e19a3"]);
        }

        private String CopyToTempFolder(string fileName)
        {
            var tempPath = Path.GetTempPath();
            var placeHolder = Guid.NewGuid().ToString();
            var tempFileName = tempPath + placeHolder + Path.GetFileName(fileName);
            File.Copy(fileName, tempFileName);
            return tempFileName;
        }

        private string CreateATempFile(string name)
        {
            var fileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + name);
            using (new FileStream(fileName, FileMode.CreateNew)) { }
            return fileName;
        }
    }
}
