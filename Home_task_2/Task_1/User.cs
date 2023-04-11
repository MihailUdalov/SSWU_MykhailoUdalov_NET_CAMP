using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class User
    {
        private const int defaultConsumptionWater = 1;
        public string Name { get; set; }
        public double ConsumptionWater { get; private set; }
        public double CurrentConsumptionWater { get; private set; }
        public bool GetsWater { get; set; }

        public event EventHandler<string> GetsWaterChanged;

        public User(string name, double consumptionWater, bool getsWater = false)
        {
            GetsWater = getsWater;
            Name = name;
            ConsumptionWater = consumptionWater;
        }

        public void GetWater(WaterTower waterTower, double currentConsumptionWater = defaultConsumptionWater)
        {
            CurrentConsumptionWater = currentConsumptionWater;
            waterTower.AddUser(this);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Consumption Water: {ConsumptionWater}";
        }
    }
}
