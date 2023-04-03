using System;
using System.Collections.Generic;

namespace Task_4
{
    internal class Cube
    {
        private enum Axis
        {
            X,
            Y,
            Z
        }

        public int Size { get; private set; }

        public Point[,,] Points { get; private set; }

        public Cube(int size)
        {
            Size = size;
            Points = new Point[size, size, size];
            Init();
            InitRandomHole();
        }

        private void Init()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int z = 0; z < Size; z++)
                    {
                        Points[x, y, z] = new Point(x, y, z);
                    }
                }
            }
        }

        private void InitRandomHole()
        {
            Random random = new Random();
            int holeCount = random.Next(Size);
            CreateHoles(holeCount, Axis.X);
            CreateHoles(holeCount, Axis.Y);
            CreateHoles(holeCount, Axis.Z);

        }

        private void CreateHoles(int holeCount, Axis axis)
        {
            Random random = new Random();
            for (int i = 0; i < holeCount; i++)
            {
                int x = random.Next(Size);
                int y = random.Next(Size);
                int z = random.Next(Size);

                switch (axis)
                {
                    case Axis.X:
                        Points[0, y, z] = null;
                        Points[Size - 1, y, z] = null;
                        break;

                    case Axis.Y:
                        Points[x, 0, z] = null;
                        Points[x, Size - 1, z] = null;
                        break;

                    case Axis.Z:
                        Points[x, y, 0] = null;
                        Points[x, y, Size - 1] = null;
                        break;

                    default:
                        throw new ArgumentException("Invalid axis specified");
                }
            }
        }

        public List<Line> CheckThroughHoles()
        {
            List<Line> lines = new List<Line>();

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int z = 0; z < Size; z++)
                    {
                        if (z == 0 && Points[x, y, z] == null && Points[x, y, Size - 1] == null)
                        {
                            lines.Add(new Line(new Point(x, y, 0), new Point(x, y, Size - 1)));
                        }

                        if (x == 0 && Points[x, y, z] == null && Points[Size - 1, y, z] == null)
                        {
                            lines.Add(new Line(new Point(0, y, z), new Point(Size - 1, y, z)));
                        }

                        if (y == 0 && Points[x, y, z] == null && Points[x, Size - 1, z] == null)
                        {
                            lines.Add(new Line(new Point(x, 0, z), new Point(x, Size - 1, z)));
                        }
                    }
                }
            }

            return lines;
        }
    }
}
