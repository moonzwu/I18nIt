using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace I18nIt
{
    public class PersistenceSync
    {
        public string StatusLabel { get; private set; }

        public PersistenceSync()
        {
            var timer = new Timer(30000);
            timer.Elapsed += Sync;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Sync(object source, ElapsedEventArgs e)
        {
            SaveAll();
            
        }

        public void SaveAll()
        {
            lock (this)
            {
                var cache = StringResourceCache.GetInstance();
                var allKeys = cache.GetAllKeys();
                foreach (var loader in allKeys.Select(cache.GetResourceLoader))
                {
                    loader.Save();
                    StatusLabel = String.Format("File has been saved at {0}", DateTime.Now.ToLocalTime());
                }
            }
        }
    }
}