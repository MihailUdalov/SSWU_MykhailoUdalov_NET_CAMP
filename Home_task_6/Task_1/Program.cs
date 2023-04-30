using System;
using System.Collections.Generic;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = {
             {1,2,3,4},
             {5,6,7,8},
             {9,10,11,12},
             {13,14,15,16}
            };
            SquareMatrix matrix = new SquareMatrix(arr);

            foreach (int value in matrix)
            {
                Console.Write(value + " ");
            }

            Console.ReadKey();
        }


    }
}
