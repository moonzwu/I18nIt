using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I18nIt
{
    public class ChineseValidater
    {
        public List<string> CheckDelimiter(IDictionary<string, string> sourceDictionary)
        {
            var errorStrings = (from keyval in sourceDictionary where keyval.Value.Contains(" ") select keyval.Key).ToList();
            return errorStrings;
        } 
    }
}
