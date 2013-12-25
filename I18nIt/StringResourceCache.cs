using System;
using System.Collections.Generic;

namespace I18nIt
{
    public class StringResourceCache
    {
        private static IDictionary<String, StringResourceLoader> cache = new Dictionary<String, StringResourceLoader>();
        private static readonly StringResourceCache Self = new StringResourceCache();

        public static StringResourceCache GetInstance()
        {
            return Self;
        }

        public void SetResourceLoader(String key, StringResourceLoader stringResourceLoader)
        {
            cache[key] = stringResourceLoader;
        }

        public StringResourceLoader GetResourceLoader(string key)
        {
            return cache.ContainsKey(key) ? cache[key] : null;
        }

        public ICollection<string> GetAllKeys()
        {
            return cache.Keys;
        } 

        public void Update(string key, string stringkey, string stringVal)
        {
            lock (cache)
            {
                if (cache.ContainsKey(key))
                {
                    cache[key].ResourceStringsDictionary[stringkey] = stringVal;
                }    
            }
        }

        public bool Check(string key, string stringkey)
        {
            lock (cache)
            {
                return cache.ContainsKey(key) && cache[key].ResourceStringsDictionary.ContainsKey(stringkey);
            }
        }

        public void Clear()
        {
            lock (cache)
            {
                cache.Clear();
            }
        }
    }
}
