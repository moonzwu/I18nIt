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

        [TestMethod]
        public void Should_report_error_when_has_unmatched_bracket_in_sentence()
        {
            IDictionary<string, string> sourDictionary = new Dictionary<string, string>();
            sourDictionary["name"] = "名字";
            sourDictionary["address"] = "家庭(地址";
            var chineseValidater = new ChineseValidater();
            var result = chineseValidater.CheckBracketPair(sourDictionary);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]

        public void Should_report_error_when_sentence_has_lower_or_upper_case_error()
        {
            IDictionary<string, string> sourDictionary = new Dictionary<string, string>();
            sourDictionary["name"] = "tom jims";
            sourDictionary["address"] = "City of Chinese";
            sourDictionary["desc"] = "Blue line";
            sourDictionary["age"] = "Fouty fOur";
            var baseValidater = new BaseValidater();
            var result = baseValidater.CheckSentence(sourDictionary);
            Assert.AreEqual(3, result.Count);
        }

    }
}
