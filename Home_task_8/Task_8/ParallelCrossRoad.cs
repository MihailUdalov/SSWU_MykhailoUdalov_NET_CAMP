using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    internal class ParallelCrossRoad : ISchemeCrossRoads
    {
        private string name;
        private Road northSouth;
        private Road southNorth;
        private Road eastWest;
        private Road westEast;

        public ParallelCrossRoad(string name, Road northSouth, Road southNorth, Road eastWest, Road westEast)
        {
            this.name = name;
            this.northSouth = northSouth;
            this.southNorth = southNorth;
            this.eastWest = eastWest;
            this.westEast = westEast;
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
        public void AddTrafficLightInLine(string roadName, int line, TrafficLight trafficLight)
        {
            List<Road> roads = new List<Road> { northSouth, southNorth, westEast, eastWest };
            roads.First(r => r.Name == roadName).AssignTrafficLight(line, trafficLight);
        }

        public override string ToString()
        {
            return $"{name} \n{northSouth}\n{southNorth}\n{eastWest}\n{westEast}";
        }

    }
}
