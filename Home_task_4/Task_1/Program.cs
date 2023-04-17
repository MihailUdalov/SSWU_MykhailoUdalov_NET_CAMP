using System;

namespace Task_1
{
    internal class Program
    {
        static void Main()
        {
            string[] text = new string[] {"Here is an example text that needs to be formatted into a collection of... strings (you can use ",
                "an array for... storage). The text contains sentences that are not necessarily located in a single",
                "string. Sentences can end with a period, comma, exclamation mark, or question mark. It ",
             "should be assumed that (these punctuation marks cannot be inside sentences). (Sentences ",
            "may contain text inside round brackets).",};

            string[] input = new TextHandler().SearchStrings(text);

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to close programm...");

            Console.ReadKey();
        }
    }
}
