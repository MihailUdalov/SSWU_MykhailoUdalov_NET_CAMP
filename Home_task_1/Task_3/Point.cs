namespace Task_4
{
    internal class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y},Z:{Z}";
        }
    }
}
