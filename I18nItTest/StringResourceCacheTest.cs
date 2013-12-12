using System;
using System.Text;
using System.Collections.Generic;
using I18nIt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace I18nItTest
{
    [TestClass]
    public class StringResourceCacheTest
    {
        [TestMethod]
        public void Should_update_the_string_value_when_the_given_resource_in_cache()
        {
            var stringResourceLoader = new StringResourceLoader();
            stringResourceLoader.LoadFile("resource/teststringfiles.properties");
            var stringResourceCache = StringResourceCache.getInstance();
            var key = new Guid().ToString();
            stringResourceCache.SetResourceLoader(key, stringResourceLoader);
            var resourceLoader = stringResourceCache.GetResourceLoader(key);
            var originalData = resourceLoader.ResourceStringsDictionary["name"];
            stringResourceCache.Update(key, "name", "李四");
            var newData = resourceLoader.ResourceStringsDictionary["name"];
            Assert.AreNotEqual(originalData, newData);
        }
    }
}
