using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace I18nIt
{
    public class PersistenceSync
    {
        public PersistenceSync()
        {
            var timer = new Timer(15000);
            timer.Elapsed += new ElapsedEventHandler(Sync);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Sync(object source, ElapsedEventArgs e)
        {
            var cache = StringResourceCache.GetInstance();
            var allKeys = cache.GetAllKeys();
            foreach (var loader in allKeys.Select(cache.GetResourceLoader))
            {
                loader.Save();
            }
        }
    }
}
