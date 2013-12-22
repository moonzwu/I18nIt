using System.Collections.Generic;
using System.Linq;

namespace I18nIt
{
    public class BaseValidater
    {
        public List<string> CheckBracketPair(IDictionary<string, string> sourceDictionary)
        {
            var errorStrings = (from keyval in sourceDictionary 
                let leftBracketCount = keyval.Value.Count(x => x == '(') 
                let rightBracketCount = keyval.Value.Count(x => x == ')') 
                where leftBracketCount != rightBracketCount select keyval.Key).ToList();
            return errorStrings;
        }

        public List<string> CheckSentence(IDictionary<string, string> souDictionary)
        {
            return (from keyval in souDictionary 
                where !CheckWord(keyval) select keyval.Key).ToList();
        }

        private static bool CheckWord(KeyValuePair<string, string> keyval)
        {
            var words = keyval.Value.Split(' ');
            return !(from word in words 
                     where !word.Equals("of") && !word.Equals("to") 
                     let titleCase = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()) 
                     where !titleCase.Equals(word) select word).Any();
        }
    }
}