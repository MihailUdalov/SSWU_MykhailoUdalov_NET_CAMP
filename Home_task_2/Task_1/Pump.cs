using System;

namespace Task_1
{
    public class Pump
    {
        public string Name { get; private set; }
        public double PumpingSpeed { get; private set; }

        public Pump(string name, double pumpingSpeed)
        {
            Name = name;
            PumpingSpeed = pumpingSpeed;
        }

        public double Pumping()
        {
            //TODO: return pumpingSpeed 
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Name {Name},PumpingSpeed {PumpingSpeed}";
        }
    }
}
