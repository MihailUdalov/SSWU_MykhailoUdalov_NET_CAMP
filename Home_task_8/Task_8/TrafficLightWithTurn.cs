using System.Timers;
using Task_1;

namespace Task_1
{
    internal class TrafficLightWithTurn : TrafficLight
    {
        public TrafficLightState currentTurnState { get; private set; }

        private int intervalForRedTurnState;
        private int intervalForGreenTurnState;

        private Timer turnTimer;
        public TrafficLightWithTurn(int intervalForRedTurnState = 5000, int intervalForGreenTurnState = 5000) : base()
        {
            turnTimer = new Timer();
            this.intervalForRedTurnState = intervalForRedTurnState;
            this.intervalForGreenTurnState = intervalForGreenTurnState;

            turnTimer.Elapsed += ChangeTurnState;
            currentTurnState = TrafficLightState.Red;
        }

        public override void Start(TrafficLightState startState = TrafficLightState.Red)
        {
            base.Start(startState);
            currentState = startState;

            if (startState == TrafficLightState.Green)
                turnTimer.Interval = intervalForGreenTurnState;
            else
                turnTimer.Interval = intervalForRedTurnState;
            turnTimer.Start();
        }
        public override void Stop()
        {
            base.Stop();
            turnTimer.Stop();
        }
        public void ChangeTurnState(object sender, ElapsedEventArgs e)
        {
            switch (currentTurnState)
            {
                case TrafficLightState.Green:
                    currentTurnState = TrafficLightState.Red;
                    turnTimer.Interval = intervalForRedTurnState;
                    break;
                case TrafficLightState.Red:
                    currentTurnState = TrafficLightState.Red;
                    turnTimer.Interval = intervalForGreenTurnState;
                    break;
            }
            OnStateChanged();
        }


    }
}
