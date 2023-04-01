namespace Task_1
{
    internal class User
    {
        public string Name { get; set; }
        public double ConsumptionWater { get; set; }

        public User(string name,double consumptionWater)
        {
            Name = name;
            ConsumptionWater = consumptionWater;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Consumption Water: {ConsumptionWater}";
        }
    }
}
