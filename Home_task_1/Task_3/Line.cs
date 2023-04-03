namespace Task_4
{
    internal class Line
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }

        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public override string ToString()
        {
            return $"Start Point: {StartPoint}, End Point: {EndPoint}";
        }
    }
}
