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
            int[] array1 = { 5, 2, 9, 1, 7 };
            QuickSort<int>.Sort(array1,PivotChoice.FirstElement);
            Console.WriteLine("Sorted array with first element as pivot:");
            PrintArray(array1);

            int[] array2 = { 5, 2, 9, 1, 7 };
            QuickSort<int>.Sort(array2, PivotChoice.RandomElement);
            Console.WriteLine("Sorted array with random element as pivot:");
            PrintArray(array2);

            int[] array3 = { 5, 2, 9, 1, 7 };
            QuickSort<int>.Sort(array3, PivotChoice.Median);
            Console.WriteLine("Sorted array with median as pivot:");
            PrintArray(array3);

            Console.ReadKey();
        }


        static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
