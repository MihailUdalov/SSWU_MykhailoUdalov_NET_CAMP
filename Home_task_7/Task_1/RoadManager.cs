using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class RoadManager
    {
        private ISchemeCrossRoads schemeCrossRoads;

        public RoadManager(ISchemeCrossRoads schemeCrossRoads)
        {
            this.schemeCrossRoads = schemeCrossRoads;
        }

        public void Work()
        {
            schemeCrossRoads.Start();
        }

        public void Stop()
        {
            schemeCrossRoads.Stop();
        }

        public override string ToString()
        {
            return schemeCrossRoads.ToString();
        }
    }
}
