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
            int[] arrayA = new int[] { 1, 2, 5, 7, 8, 35 };
            int[] arrayB = new int[] { 99, 34, 22, 11, 33 };

            Console.WriteLine(string.Join(" ", ConcatAndSort(arrayA, arrayB).First()));
            //Console.WriteLine(string.Join(" ", SecondConcatAndSort(arrayA, arrayB)));
            Console.ReadKey();

        }

        static IEnumerable<int[]> ConcatAndSort(params int[][] arrays)
        {// не правильна ідеологія застосування yield.
            // Select і ToArray() тут лишні
            yield return arrays.SelectMany(ar => ar).Select(v => v)
                    .OrderByDescending(v => v).ToArray();
            yield break;
        }

        //Second method
        //static int[] SecondConcatAndSort(params int[][] arrays)
        //{
        //    IEnumerable<int> Range(IEnumerable<int> array)
        //    {
        //        for (int i = 0; i < array.Count(); i++)
        //            yield return array.ElementAt(i);
        //        yield break;
        //    }

        //    return Range(arrays.SelectMany(ar => ar).Select(v => v))
        //            .OrderByDescending(v => v).ToArray();
        //}
    }
}
