using System;
using System.Threading;

namespace Task_1
{
    internal class Simulator
    {
        private static Simulator simulator;
        private CrossRoadManager crossRoadManager;
        private ParallelCrossRoad parallelCross;
        private Simulator()
        {
            InitParallelCrossRoad();
            crossRoadManager = new CrossRoadManager(parallelCross);
        }
        private void InitParallelCrossRoad()
        {
            Road northSouth = new Road("NorthSouth", new TrafficLight(), 2);
            Road southNorth = new Road("SouthNorth", new TrafficLight(), 2);
            Road eastWest = new Road("EastWest", new TrafficLight(), 2);
            Road westEast = new Road("WestEast", new TrafficLight(), 2);
            parallelCross = new ParallelCrossRoad("ParallelCross", northSouth, southNorth, eastWest, westEast);
        }

        public void Start()
        {
            crossRoadManager.Work();
            while (true)
            {
                Console.WriteLine(crossRoadManager);
                Thread.Sleep(1500);
            }
        }
        public static Simulator GetSimulator()
        {
            if (simulator == null)
            {
                simulator = new Simulator();
            }
            return simulator;
        }
    }
}
