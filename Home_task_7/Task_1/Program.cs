using System;
using System.Threading;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelCrossRoad crossRoad = new ParallelCrossRoad();
            RoadManager roadManager = new RoadManager(crossRoad);
            roadManager.Work();
            while (true)
            {
                Console.WriteLine($"Current traffic lights colors");
                Console.WriteLine(roadManager);
                Thread.Sleep(2500);
            }

        }
    }
}
