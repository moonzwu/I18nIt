using System;
using System.Collections.Generic;

namespace I18nIt
{
    public class StringResourceCache
    {
        private static IDictionary<String, StringResourceLoader> cache = new Dictionary<String, StringResourceLoader>();
        private static StringResourceCache _self = new StringResourceCache();

        public static StringResourceCache getInstance()
        {
            return _self;
        }

        public void SetResourceLoader(String key, StringResourceLoader stringResourceLoader)
        {
            if (!cache.ContainsKey(key))
            {
                cache[key] = stringResourceLoader;
            }
        }

        public StringResourceLoader GetResourceLoader(string key)
        {
            return cache.ContainsKey(key) ? cache[key] : null;
        }

        public void Update(string key, string stringkey, string stringVal)
        {
            if (cache.ContainsKey(key))
            {
                cache[key].ResourceStringsDictionary[stringkey] = stringVal;
            }
        }
    }
}
