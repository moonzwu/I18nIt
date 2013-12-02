using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace I18nIt
{
    public class StringResourceLoader
    {
        private Dictionary<string, string> _resourceMap = new Dictionary<string, string>();
 
        public static StringResouceType DecideResourceType(string file)
        {
            var extension = Path.GetExtension(file);
            if (!File.Exists(file) || extension == null) return StringResouceType.Unknown;
            if (extension.Equals(".properties", StringComparison.InvariantCultureIgnoreCase))
            {
                return StringResouceType.JavaStyle;
            }

            if (extension.Equals(".mpx", StringComparison.InvariantCultureIgnoreCase))
            {
                return StringResouceType.MPStyle;
            }
            return StringResouceType.Unknown;
        }
    }
}
