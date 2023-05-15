using System;
using System.Timers;

namespace Task_1
{
    internal class TrafficLight
    {
        protected TrafficLightState currentState;
        protected TrafficLightState previousState;
        protected Timer timer;

        protected int intervalForRedState;
        protected int intervalForYellowState;
        protected int intervalForGreenState;

        public event Action<TrafficLight> StateChanged;
        public TrafficLight(int intervalForRedState = 5000, int intervalForYellowState = 2500, int intervalForGreenState = 5000)
        {
            timer = new Timer();
            this.intervalForRedState = intervalForRedState;
            this.intervalForGreenState = intervalForGreenState;
            this.intervalForYellowState = intervalForYellowState;

            timer.Elapsed += ChangeState;
            currentState = TrafficLightState.Red;
            previousState = TrafficLightState.Yellow;
        }

        public virtual void Start(TrafficLightState startState = TrafficLightState.Red)
        {
            if (startState == TrafficLightState.Yellow)
            {
                new NotSupportedException();
                //Possible notification that it is impossible to start the traffic light
                return;
            }
            if (startState == TrafficLightState.Green)
                timer.Interval = intervalForGreenState;
            else
                timer.Interval = intervalForRedState;
            currentState = startState;
            timer.Start();
        }

        public virtual void Stop()
        {
            timer.Stop();
        }
        protected void OnStateChanged()
        {
            StateChanged?.Invoke(this);
        }

        public void ChangeState(object sender, ElapsedEventArgs e)
        {
            switch (currentState)
            {
                case TrafficLightState.Green:
                    previousState = TrafficLightState.Green;
                    currentState = TrafficLightState.Yellow;
                    timer.Interval = intervalForYellowState;
                    break;
                case TrafficLightState.Yellow:
                    if (previousState == TrafficLightState.Green)
                    {
                        currentState = TrafficLightState.Red;
                        timer.Interval = intervalForRedState;
                    }
                    else if (previousState == TrafficLightState.Red)
                    {
                        currentState = TrafficLightState.Green;
                        timer.Interval = intervalForGreenState;
                    }
                    previousState = TrafficLightState.Yellow;
                    break;
                case TrafficLightState.Red:
                    previousState = TrafficLightState.Red;
                    currentState = TrafficLightState.Yellow;
                    timer.Interval = intervalForYellowState;
                    break;
            }
            OnStateChanged();
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
