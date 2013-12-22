using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I18nIt
{
    public class ChineseValidater : BaseValidater
    {
        public List<string> CheckDelimiter(IDictionary<string, string> sourceDictionary)
        {
            var errorBracketPair = base.CheckBracketPair(sourceDictionary);
            var errorWhitespace = (from keyval in sourceDictionary 
                                where keyval.Value.Contains(" ") select keyval.Key).ToList();
            return errorWhitespace.Union(errorBracketPair).ToList();
        }
    }
}
