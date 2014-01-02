<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
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

<<<<<<< HEAD
        public List<string> CheckSentence(IDictionary<string, string> sourceDictionary)
        {
            return (from keyval in sourceDictionary 
                where !CheckWord(keyval) select keyval.Key).ToList();
        }

        public List<string> CheckNewItems(IDictionary<string, string> baseDictionary,
            IDictionary<string, string> translatedDictionary)
        {
            return (from keyvalue in baseDictionary 
                    where !translatedDictionary.ContainsKey(keyvalue.Key) 
                    select keyvalue.Key)
                    .ToList();
        }

        private static bool CheckWord(KeyValuePair<string, string> keyval)
        {
            var value = keyval.Value;
            if (!String.IsNullOrEmpty(value))
            {
                var words = value.Split(' ');
                return !(from word in words
                    where !word.Equals("of") && !word.Equals("to")
                    let titleCase =
                        System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(word.ToLower())
                    where !titleCase.Equals(word)
                    select word).Any();
            }

            return true;
=======
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
>>>>>>> 069b630bf56cecca78e774995feaa66eba697f75
        }
    }
}