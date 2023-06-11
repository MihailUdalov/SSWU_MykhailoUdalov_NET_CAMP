using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            string filename = "input.txt";

            GenerateRandomNumbers(filename, 100, 1, 1000);

            MergeSort mergeSort = new MergeSort();

            mergeSort.Sort(filename);
        }

        static void GenerateRandomNumbers(string filename, int count, int minValue, int maxValue)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(minValue, maxValue + 1);
                    writer.WriteLine(number);
                }
            }
        }
    }
}
