using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2
{
    static class TextHandler
    {
        public static int? FindOccurrence(string text, string substring)
        {
            int firstIndex = text.IndexOf(substring);
            if (firstIndex >= 0)
            {
                firstIndex = text.IndexOf(substring, firstIndex + 1);
                if (firstIndex == -1)
                    return null;
                return firstIndex;
            }
            return null;
        }

        public static int CountBigLetter(string text)
        {
            return text.Split().Count(word => char.IsUpper(word[0]));
        }

        public static string ReplaceWords(string text, string replacement)
        {// помилка в регулярці
            Regex regex = new Regex(@"\b\w*(\w)\1\w*\b");
            return regex.Replace(text, replacement);
        }
    }
}
