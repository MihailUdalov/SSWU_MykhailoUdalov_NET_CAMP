namespace Task_1
{
    internal class Point
    {
        public Direction Direction { get;set; }
        public int Value { get; private set; }

        public Point(Direction direction,int value)
        {
            Direction = direction;
            Value = value;
        }
    }
}
