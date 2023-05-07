using System.Timers;

namespace Task_1
{
    internal class TrafficLight
    {
        public TrafficLightState currentState { get; private set; }
        private TrafficLightState previousState;
        private Timer timer;


        public TrafficLight(int interval = 5000)
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += ChangeState;
            currentState = TrafficLightState.Red;
            previousState = TrafficLightState.Yellow;
        }

        public void Start(TrafficLightState startState = TrafficLightState.Red)
        {
            currentState = startState;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }


        public void ChangeState(object sender, ElapsedEventArgs e)
        {
            switch (currentState)
            {
                case TrafficLightState.Green:
                    previousState = TrafficLightState.Green;
                    currentState = TrafficLightState.Yellow;
                    break;
                case TrafficLightState.Yellow:
                    if (previousState == TrafficLightState.Green)
                    {
                        currentState = TrafficLightState.Red;
                    }
                    else if (previousState == TrafficLightState.Red)
                    {
                        currentState = TrafficLightState.Green;
                    }
                    previousState = TrafficLightState.Yellow;
                    break;
                case TrafficLightState.Red:
                    previousState = TrafficLightState.Red;
                    currentState = TrafficLightState.Yellow;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{currentState}";
        }

    }
    public enum TrafficLightState
    {
        Green,
        Yellow,
        Red
    }

}
