using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task_1
{
    internal class WaterTower
    {
        private Timer timer;
        private List<User> users;
        private Pump pump;

        public double MaxVolume { get; set; }
        public double FeedRate { get; set; }
        public string Name { get; private set; }
        public double CurrentVolume { get; private set; }
        public bool IsPumpOn { get; private set; }


        public event EventHandler<string> StateChanged;


        public WaterTower(string name, double maxVolume, double feedRate, Pump pump)
        {
            Name = name;
            MaxVolume = maxVolume;
            FeedRate = feedRate;
            this.pump = pump;
            users = new List<User>();

            IsPumpOn = false;
            CurrentVolume = 0;

        }

        protected void OnStateChanged(string state)
        {
            //TODO: invoke when any waterTower prop changed
        }

        private void CheckState()
        {
            //TODO: check state for tick 
        }

        private void WaterFeed(User user)
        {
            //TODO: water feed to tower users
        }

        private string PumpingWater()
        {
            //TODO: check pump state and from that make a decision
            throw new NotImplementedException();
        }
        private void Tick(object sender, ElapsedEventArgs e)
        {
            //TODO: work waterTower, check state water tower, and start to water feed users
        }

        public void Stop()
        {
            //TODO: stop water tower work
        }

        public void Work()
        {
            //TODO: start water tower work, start timer for check state each tick
        }

        public void AddUser(User user)
        {
            //TODO: add new user
        }

        public void RemoveUser(User user)
        {
            //TODO: remove old user
        }

        public void ChangePump(Pump pump)
        {
            //TODO: change current pump
        }

        public override string ToString()
        {
            return $"Name: {Name}\nMaxVolume: {MaxVolume}\nCurrentVolume: {CurrentVolume}\nFeedRate: {FeedRate}\nPump: {pump}\n" +
                $"Users: {string.Join("\n", users.Select(us => us.ToString()))}";
        }
    }
}
