using System;
using System.Collections.Generic;
using System.Linq;
// Сумарний бал -80
namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = @"Welcome to the Hotel California
                        Such a lovely place (Such a lovely place)
                        Such a lovely face
                        Plenty of room at the Hotel California
                        Any time of year (Any time of year)
                        You can find it here";

            Console.WriteLine($"Original text: {text}");

            Console.WriteLine("\nUnique words:");
            Console.WriteLine($"{string.Join(", ", GetUniqueWords(text))}");


            Console.ReadKey();
        }

        public static string[] GetUniqueWords(string text)
        {
            IEnumerable<string> Range(string array)
            {
                string[] separators = new string[] { " ", ".", ",", "!", "?", "\r", "\n", ")", "(" };
                 // в linq є окремий метод для унікальних елементів)
                 //Distinct
                var uniqeWords = array.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .GroupBy(x => x)
                    .Where(x=> x.Count() == 1)
                    .Select(x => x.Key); 

                foreach (string word in uniqeWords)
                    yield return word;
                yield break;
            }

            return Range(text).ToArray();
        }
    }
}
