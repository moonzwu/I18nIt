using System;
using System.Text.RegularExpressions;

namespace I18nIt
{
    public class ResourceLineValidator
    {
        private static readonly Regex TemplateRegex = new Regex("[^#].+={1}.+", RegexOptions.ExplicitCapture);

        public static bool IsValidLine(String text)
        {
            return TemplateRegex.IsMatch(text);
        }
    }
}