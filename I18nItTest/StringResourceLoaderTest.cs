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
            Assert.AreEqual(StringResourceType.JavaStyle, resouceType1);

            var mpFile = CreateATempFile(mpResource);
            var resouceType2 = StringResourceLoader.DecideResourceType(mpFile);
            Assert.AreEqual(StringResourceType.MPStyle, resouceType2);

            var otherFile = CreateATempFile(otherResource);
            var resouceType3 = StringResourceLoader.DecideResourceType(otherFile);
            Assert.AreEqual(StringResourceType.Unknown, resouceType3);
        }

        [TestMethod]
        public void Should_get_mp_resource_when_given_a_mpx_file()
        {
            const string mpResource = "resource/mpresource.mpx";
            var stringResourceLoader = new StringResourceLoader();
            var result = stringResourceLoader.LoadFile(mpResource);
            Assert.IsTrue(result);
            Assert.AreEqual(1, stringResourceLoader.ResourceStringsDictionary.Count);
            Assert.AreEqual("Enum.843e5d2b2f3941d882c6a5f4834e19a3$HostName", stringResourceLoader.ResourceStringsDictionary.Keys.First());
        }

        [TestMethod]
        public void Should_get_resx_resource_when_given_a_dotnet_resource_file()
        {
            const string resxResource = "resource/Resource.resx";
            var stringResourceLoader = new StringResourceLoader();
            bool result = stringResourceLoader.LoadFile(resxResource);
            Assert.IsTrue(result);
            Assert.AreEqual(7, stringResourceLoader.ResourceStringsDictionary.Count);
        }

        [TestMethod]
        public void Should_save_the_changed_text_to_resx_file()
        {
            var path = CopyToTempFolder("resource/Resource.resx");
            var stringResourceLoader = new StringResourceLoader();
            stringResourceLoader.LoadFile(path);
            const string testString = "It is a new active";
            stringResourceLoader.ResourceStringsDictionary["Active"] = testString;
            stringResourceLoader.Save();


            var newStringResourceLoader = new StringResourceLoader();
            newStringResourceLoader.LoadFile(path);
            Assert.AreEqual(testString, newStringResourceLoader.ResourceStringsDictionary["Active"]);
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
            stringResourceLoader.ResourceStringsDictionary["Enum.843e5d2b2f3941d882c6a5f4834e19a3$HostName"] = "new text";
            stringResourceLoader.Save();

            var newStringResourceLoader = new StringResourceLoader();
            newStringResourceLoader.LoadFile(path);
            Assert.AreEqual("new text", newStringResourceLoader.ResourceStringsDictionary["Enum.843e5d2b2f3941d882c6a5f4834e19a3$HostName"]);
        }

        [TestMethod]
        public void Should_save_add_a_new_element_to_mp_resource_file()
        {
            var path = CopyToTempFolder("resource/mpresource.mpx");
            var stringResourceLoader = new StringResourceLoader();
            stringResourceLoader.LoadFile(path);
            stringResourceLoader.ResourceStringsDictionary["newElementId$subId"] = "new text";
            stringResourceLoader.Save();

            var newStringResourceLoader = new StringResourceLoader();
            newStringResourceLoader.LoadFile(path);
            Assert.AreEqual(2, newStringResourceLoader.ResourceStringsDictionary.Keys.Count);
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
