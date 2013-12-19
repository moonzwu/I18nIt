using System;
using System.Text;
using System.Collections.Generic;
using I18nIt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace I18nItTest
{
    [TestClass]
    public class ChineseValidaterTest
    {
        [TestMethod]
        public void Should_report_error_when_has_whitespace_in_chinese_sentence()
        {
            IDictionary<string, string> sourDictionary = new Dictionary<string, string>();
            sourDictionary["name"] = "名字";
            sourDictionary["address"] = "家 庭地址";
            var chineseValidater = new ChineseValidater();
            var result = chineseValidater.CheckDelimiter(sourDictionary);
            Assert.AreEqual(1, result.Count);
        }
    }
}
