using System.Collections.Generic;

namespace Task_1
{
    internal class Road
    {
        public string Name { get; private set; }
        public List<Line> Lines { get; private set; }
        public TrafficLight TrafficLight { get; private set; }

        public Road(string name, TrafficLight trafficLight, int countLines)
        {
            Name = name;
            TrafficLight = trafficLight;
            TrafficLight.StateChanged += TrafficLight_StateChanged;
            InitLine(countLines);
            foreach (var line in Lines)
            {
                line.LineChanged += Line_LineChanged;
            }
        }
        private void InitLine(int Count)
        {
            Lines = new List<Line>();
            for (int i = 0; i < Count; i++)
            {
                Lines.Add(new Line(i.ToString()));
            }
        }

        private void Line_LineChanged(Line obj)
        {
            //TODO: Something when line change.User notification
        }
        private void TrafficLight_StateChanged(TrafficLight obj)
        {
            //TODO: Something when traffic light change state(color).User notification
        }

        public void Start(TrafficLightState trafficLightState = TrafficLightState.Red)
        {
            TrafficLight.Start(trafficLightState);
            foreach (var line in Lines)
            {
                if (line.TrafficLight != null)
                    line.Start();
            }
        }

        public void Stop()
        {
            TrafficLight.Stop();
            foreach (var line in Lines)
            {
                if (line.TrafficLight != null)
                    line.Stop();
            }
        }

        public void AssignTrafficLight(int currentLine, TrafficLight trafficLight)
        {
            if (Lines.Count < currentLine && currentLine > -1)
                Lines[currentLine] = new Line(currentLine.ToString(), trafficLight);
        }

        public override string ToString()
        {
            string lineNotification = "";
            foreach (var line in Lines)
            {
                if (line.TrafficLight != null)
                    lineNotification += line.ToString();
                else
                    lineNotification += $"Number: {line.Name} TrafficLight: {TrafficLight}";

                lineNotification += "\n";
            }
            return $"RoadName: {Name} TrafficLight: {TrafficLight}\nLine:\n{lineNotification}";
        }
    }
}
