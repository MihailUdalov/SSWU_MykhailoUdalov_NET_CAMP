using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuHelper.ShowMenu();

            Console.WriteLine("Read any key to close programm...");
            Console.ReadKey();
        }
    }
}
