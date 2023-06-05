using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cardNumber = "4003789100205381";

            CreditCard creditCard = CreditCard.Parse(cardNumber);

            Console.WriteLine(creditCard);

            Console.ReadKey();  
        }
    }
}
