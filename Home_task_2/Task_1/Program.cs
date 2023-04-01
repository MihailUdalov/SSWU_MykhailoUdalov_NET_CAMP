using System;


namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double consumptionWater = ReadDoubleValue("Write user's water consumption: ");
            Console.Write("\nWrite user name: ");
            string name = Console.ReadLine();

            User user = new User(name, consumptionWater);

            double maxVolume = ReadDoubleValue("Write water tower maximum volume: ");
            double feedRate = ReadDoubleValue("Write water tower feed rate: ");
            Console.Write("\nWrite water tower name: ");
            name = Console.ReadLine();


            double pumpingSpeed = ReadDoubleValue("Write pump pumping speed: ");
            Console.Write("\nWrite pump name: ");
            name = Console.ReadLine();

            WaterTower waterTower = new WaterTower(name, maxVolume, feedRate, new Pump(name, pumpingSpeed), user);

            waterTower.StateChanged += ShowStatus;
            waterTower.Work();

            Console.ReadKey();
            Console.WriteLine("Press any key to stop Water Tower");

            waterTower.Stop();

            Console.WriteLine("Press any key to close the app..");
            Console.ReadKey();
        }

        private static void ShowStatus(object sender, string status)
        {
            //TODO: Show water tower status 
        }

        private static double ReadDoubleValue(string message, double minValue = 1, double maxValue = double.MaxValue)
        {
            double value;
            do
            {
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out value) || value < minValue || value > maxValue);

            return value;
        }

    }
}
