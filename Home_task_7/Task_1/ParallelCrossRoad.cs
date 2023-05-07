namespace Task_1
{
    internal class ParallelCrossRoad : ISchemeCrossRoads
    {
        private TrafficLight northSouth;
        private TrafficLight southNorth;
        private TrafficLight eastWest;
        private TrafficLight westEast;

        public ParallelCrossRoad(int interval = 5000)
        {
            northSouth = new TrafficLight(interval);
            southNorth = new TrafficLight(interval);
            eastWest = new TrafficLight(interval);
            westEast = new TrafficLight(interval);
        }

        public void Start()
        {
            northSouth.Start();
            southNorth.Start();
            eastWest.Start(TrafficLightState.Green);
            westEast.Start(TrafficLightState.Green);
        }

        public void Stop()
        {
            northSouth.Stop();
            southNorth.Stop();
            eastWest.Stop();
            westEast.Stop();
        }

        public override string ToString()
        {
            return "northSouth\t\t  southNorth\t\t eastWest\t\t westEast \n" +
                $"{northSouth}\t\t\t  {southNorth}\t\t\t {eastWest}\t\t\t {westEast}";
        }

    }
}
