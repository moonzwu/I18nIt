using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using I18nIt;

namespace I18nItTest
{
    [TestClass]
    public class FileMenuTest
    {
        [TestMethod]
        public void should_load_string_resource_file_and_file_to_list_view()
        {
            var mf = new FileMenu();
            var listView = new ListView();
            mf.LoadResourceFileAndFillView(listView, "resource/teststringfiles.properties");
            Assert.AreEqual(listView.Items.Count, 2);
            Assert.AreEqual(listView.Items[0].Text, "名字");
            Assert.AreEqual(listView.Items[1].Text, "年龄");
        }

        [TestMethod]
        public void should_clear_previous_load_text_before_load_a_new_file()
        {
            var mf = new FileMenu();
            var listView = new ListView();
            mf.LoadResourceFileAndFillView(listView, "resource/teststringfiles.properties");
            mf.LoadResourceFileAndFillView(listView, "resource/teststringfiles.properties");
            Assert.AreEqual(listView.Items.Count, 2);
        }
    }
}
