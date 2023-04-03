using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cube cube = new Cube(4);
            List<Line> lines = cube.CheckThroughHoles();
            ShowLines(lines);

            Console.WriteLine("Press any key to end program");
            Console.ReadKey();
        }

        private static void ShowLines(List<Line> lines)
        {
            if (lines.Count == 0)
                Console.WriteLine("There are no through holes in the cube");
            else
                Console.WriteLine(string.Join("\n", lines.Select(x => x.ToString())));
        }
    }
}
