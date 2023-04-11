using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_1
{
    public sealed class Simulator
    {
        private static Simulator simulator;

        private static WaterTower waterTower;
        private static List<User> users;
        private static Pump pump;


        private Simulator()
        {
            users = new List<User>();
        }

        public void StartSimulator()
        {
            AddUser();

            InitPump();

            InitWaterTower();

            waterTower.Work();

            Console.ReadKey();
            Console.WriteLine("Press any key to stop Water Tower");

            waterTower.Stop();

            Console.WriteLine("Press any key to close the app..");
            Console.ReadKey();
        }

        private static void AddUser()
        {
            double consumptionWater = ReadDoubleValue("Write user's water consumption: ");
            Console.Write("\nWrite user name: ");
            string name = Console.ReadLine();

            User user = new User(name, consumptionWater);

            user.GetsWaterChanged += GetsWaterChanged;
            users.Add(user);
        }

        private static void GetsWaterChanged(object sender, bool getsWater)
        {
            //TODO: Add to WaterTower
        }


        private static void InitPump()
        {
            double pumpingSpeed = ReadDoubleValue("Write pump pumping speed: ");
            Console.Write("\nWrite pump name: ");
            string name = Console.ReadLine();

            pump = new Pump(name, pumpingSpeed);
        }

        private static void InitWaterTower()
        {
            double maxVolume = ReadDoubleValue("Write water tower maximum volume: ");
            double feedRate = ReadDoubleValue("Write water tower feed rate: ");
            Console.Write("\nWrite water tower name: ");
            string name = Console.ReadLine();

            waterTower = new WaterTower(name, maxVolume, feedRate, pump);

            waterTower.StateChanged += ShowStatus;
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
