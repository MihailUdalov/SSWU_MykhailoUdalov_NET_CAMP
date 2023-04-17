using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_2
{
    internal class TextHandler
    {
        public static List<string> CheckEmails(string[] words)
        {
            List<string> correctEmails = new List<string>();
            List<string> wordsContainsAT = new List<string>();

            foreach (string word in words)
            {
                bool validEmail = IsValidEmail(word);
                if (validEmail)
                {
                    correctEmails.Add(word);
                }

                if (!validEmail && word.Contains("@"))
                {
                    wordsContainsAT.Add(word);
                }

            }

            List<string> result = new List<string>();
            result.Add("Correct Emails:");
            result.AddRange(correctEmails);

            result.Add("Words Contains @:");
            result.AddRange(wordsContainsAT);

            return result;
        }

        public static List<string> CheckEmailsWithRegex(string[] words)
        {
            List<string> correctEmails = new List<string>();
            List<string> wordsContainsAT = new List<string>();

            foreach (var word in words)
            {
                bool validEmail = IsValidEmailWithRegex(word);
                if (validEmail)
                {
                    correctEmails.Add(word);
                }

                if (!validEmail && word.Contains("@"))
                {
                    wordsContainsAT.Add(word);
                }
            }

            List<string> result = new List<string>();
            result.Add("Correct Emails:");
            result.AddRange(correctEmails);

            result.Add("Words Contains @:");
            result.AddRange(wordsContainsAT);

            return result;
        }

        public static string[] CreateWordsArray(string text)
        {
            string[] words = text.Split(new string[] {" ","..."}, StringSplitOptions.RemoveEmptyEntries);
            words.Select(w => w.Trim());
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Last() == '.' || words[i].Last() == ',' || words[i].Last() == '!' || words[i].Last() == '?')
                {
                    words[i] = words[i].Remove(words[i].Length - 1);
                }
            }
            
            return words;
        }
        private static bool IsValidEmailWithRegex(string email)
        {
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]{2,5}){1,2}$");

            return emailRegex.Match(email).Value != "";
        }

        private static bool IsValidEmail(string email)
        {
            char[] posibleSymbols = { '!', '#', '$', '%', '&', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.' };


            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            if (string.IsNullOrEmpty(parts.First()) || string.IsNullOrEmpty(parts.Last()))
            {
                return false;
            }
            if (parts.First().EndsWith(".") || parts.First().StartsWith(".") || parts.First().Contains(".."))
            {
                return false;
            }
            if (!parts.Last().Contains(".") || parts.Last().StartsWith(".") || parts.Last().EndsWith(".") || parts.Last().StartsWith("-") || parts.Last().EndsWith("-"))
            {
                return false;
            }

            bool isValid = parts.First().Any(c => !char.IsLetterOrDigit(c) && !posibleSymbols.Contains(c));

            if (isValid)
                return false;


            isValid = parts.Last().Split('.')
            .All(part => part.Length >= 2 && part.All(c => char.IsLetterOrDigit(c) || c == '-' || c == ')' || c == '('));

            if (!isValid)
                return false;

            return true;

        }
    }

}
