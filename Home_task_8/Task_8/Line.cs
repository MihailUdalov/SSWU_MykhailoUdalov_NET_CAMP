using System;

namespace Task_1
{
    internal class Line
    {
        public string Name { get; private set; }
        public TrafficLight TrafficLight { get; private set; }
        public double Width { get; private set; }

        public event Action<Line> LineChanged;

        public Line(string name,TrafficLight trafficLight = null, double width = 2.5d)
        {
            Name = name;
            Width = width;
            if (trafficLight != null)
            {
                TrafficLight = trafficLight;
                TrafficLight.StateChanged += TrafficLight_StateChanged;
            }
            
        }

        private void TrafficLight_StateChanged(TrafficLight obj)
        {
            //TODO: Something when traffic light change state(color).User notification
            LineChanged.Invoke(this);
        }

        public void Start()
        {
            TrafficLight.Start();
        }
        public void Stop()
        {
            TrafficLight.Stop();
        }
        public override string ToString()
        {
            return $"Number:{Name} TrafficLight: {TrafficLight}";
        }
    }
}
