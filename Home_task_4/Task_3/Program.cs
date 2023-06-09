﻿using System;
using System.IO;

namespace Task_3
{
    internal class Program
    {// дата на виведенні мала містити назву місяця
        static void Main(string[] args)
        {// не пояснені чарівні константи
            Console.SetWindowSize(200, 40);

            string[] text = File.ReadAllLines("Data.txt");

            ElectricityUsageAccounting electricityUsageAccounting = new ElectricityUsageAccounting(text);
            string report = electricityUsageAccounting.GetReport();
            Console.WriteLine(report);

            Console.WriteLine();

            report = electricityUsageAccounting.GetReport(1);
            Console.WriteLine(report);

            Console.WriteLine();

            report = electricityUsageAccounting.GetOwnerLastNameWithBiggestDebt();
            Console.WriteLine(report);

            Console.WriteLine();

            report = electricityUsageAccounting.GetNumberAppartmentNoElectricityUsed();
            Console.WriteLine(report);


            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
