using System.Collections.Generic;

namespace Task_1
{
    internal class CrossRoadManager
    {
        private List<ISchemeCrossRoads> schemeCrossRoads;

        public CrossRoadManager(List<ISchemeCrossRoads> schemeCrossRoads)
        {
            this.schemeCrossRoads = new List<ISchemeCrossRoads>();
            schemeCrossRoads.AddRange(schemeCrossRoads);
        }

        public CrossRoadManager(ISchemeCrossRoads schemeCrossRoads)
        {
            this.schemeCrossRoads = new List<ISchemeCrossRoads>();
            AddScheme(schemeCrossRoads);
        }

        public void AddScheme(ISchemeCrossRoads schemeCrossRoads)
        {
            this.schemeCrossRoads.Add(schemeCrossRoads);
        }

        public void Work()
        {
            foreach (var schemeCrossRoad in schemeCrossRoads)
            {
                schemeCrossRoad.Start();
            }
        }

        public void Stop()
        {
            foreach (var schemeCrossRoad in schemeCrossRoads)
            {
                schemeCrossRoad.Stop();
            }
        }

        public override string ToString()
        {
            return $"{string.Join("\n", schemeCrossRoads)}";
        }
    }
}
