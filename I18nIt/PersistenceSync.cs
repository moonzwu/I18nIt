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
        private ToolStripStatusLabel _label;

        public PersistenceSync()
        {
            var timer = new Timer(15000);
            timer.Elapsed += new ElapsedEventHandler(Sync);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Sync(object source, ElapsedEventArgs e)
        {
            SaveAll();
            if (_label != null)
            {
                _label.Text = String.Format("File has been saved at {0}", DateTime.Now.ToLocalTime());
            }
        }

        public void BindToLabel(ToolStripStatusLabel label)
        {
            _label = label;
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
                }                
            }
        }
    }
}
