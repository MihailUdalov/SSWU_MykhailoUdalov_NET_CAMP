using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "Here are some email addresses that are correct: john.doe@example.com, mary_smith@hotmail.co.uk, jennifer_brown@gmail.com. " +
                "\nHowever, these are not correct email addresses, but contain the \"@\" symbol: myemail@, example@.com.ua, email@dotcom.";

            string[] words = TextHandler.CreateWordsArray(sentence);

            List<string> emails = TextHandler.CheckEmails(words);

            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("\n\nAlgorytm with regex:");

            emails = TextHandler.CheckEmailsWithRegex(words);

            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Press any key to end program...");
            Console.ReadKey();

        }
    }
}
