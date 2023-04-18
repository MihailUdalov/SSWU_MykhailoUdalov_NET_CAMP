using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garden firstGarden = new Garden();
            firstGarden.AddTree(3, 1);
            firstGarden.AddTree(2, 1);
            firstGarden.AddTree(0, 3);
            firstGarden.AddTree(0, 0);
            firstGarden.AddTree(4, 4);
            firstGarden.AddTree(3, 3);
            Console.WriteLine("Fence length for garden1: " + firstGarden.GetFenceLength());

            Garden secondGarden = new Garden();
            secondGarden.AddTree(0, 0);
            secondGarden.AddTree(0, 2);
            secondGarden.AddTree(2, 0);
            secondGarden.AddTree(2, 1);
            secondGarden.AddTree(1, 2);
            Console.WriteLine("Fence length for garden2: " + secondGarden.GetFenceLength());

            if (firstGarden < secondGarden)
            {
                Console.WriteLine("Garden1 has a smaller fence.");
            }
            else if (firstGarden > secondGarden)
            {
                Console.WriteLine("Garden2 has a smaller fence.");
            }
            else
            {
                Console.WriteLine("The gardens have the same fence length.");
            }

            Console.WriteLine("Press any key to close programm...");
            Console.ReadKey();
        }
    }
}
