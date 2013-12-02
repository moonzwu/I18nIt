using System;
using System.Linq;
using I18nIt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace I18nItTest
{
    [TestClass]
    public class ResourceLineValidatorTest
    {
        [TestMethod]
        public void should_filter_out_the_invalid_line_by_match_template()
        {
            var lines = new string[] { "#abcd", "", System.Environment.NewLine, "abcded", "abcd=efgh" };
            var result = "";
            foreach (var line in lines.Where(ResourceLineValidator.IsValidLine))
            {
                result = line;
            }

            Assert.AreEqual("abcd=efgh", result);
        }
    }
}
