using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write your text:");
            string text = Console.ReadLine();

            Console.Write("Write your substring in text:");
            string substring = Console.ReadLine();

            // Task a
            Console.WriteLine("Task A");

            int? index = TextHandler.FindOccurrence(text, substring);
            if (index != null)
                Console.WriteLine("The index of second occurrence of the substring '{0}': {1} \n", substring, index);
            else
                Console.WriteLine("No entry");

            // Task b
            Console.WriteLine("Task B");

            Console.WriteLine("Number of words starting with a capital letter: {0}", TextHandler.CountBigLetter(text));

            // Task c
            Console.WriteLine("Task C");

            Console.Write("Write a replacement for a word with repeated letters:");
            string replacementText = Console.ReadLine();

            Console.WriteLine("Text with replaced words: {0}", TextHandler.ReplaceWords(text, replacementText));

            Console.WriteLine("Press any button to close program");
            Console.ReadKey();
        }

        

    }
}
