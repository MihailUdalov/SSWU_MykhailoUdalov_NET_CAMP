using System;
using Task_1;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = ReadIntegerValue("Write matrix width: "),
                height = ReadIntegerValue("Write matrix height: ");

            Matrix matrix = new Matrix(width, height);
            matrix.Init(Direction.Right);
            PrintMatrix(matrix);

            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static int ReadIntegerValue(string message, int minValue = 0, int maxValue = int.MaxValue)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || value < minValue || value > maxValue);

            return value;
        }


        static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    Console.Write($"{matrix.Cells[i, j].Value} \t ");
                }
                Console.WriteLine();
            }
        }
    }
}
