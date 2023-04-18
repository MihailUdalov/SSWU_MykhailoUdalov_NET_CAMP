using System;
using System.Collections.Generic;

namespace Task_1
{
    internal class Garden
    {
        private List<Point> Trees;

        public Garden()
        {
            Trees = new List<Point>();
        }

        public void AddTree(double x, double y)
        {
            Trees.Add(new Point(x, y));
        }

        public double GetFenceLength()
        {
            List<Point> fencePoints = FencePlanner.GetFenchPoint(Trees);

            double fenceLenght = 0;
            for (int i = 0; i < fencePoints.Count; i++)
            {
                Point p1 = fencePoints[i];
                Point p2 = fencePoints[(i + 1) % fencePoints.Count];
                fenceLenght += Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            }

            return fenceLenght;
        }

        public static bool operator <(Garden g1, Garden g2)
        {
            return g1.GetFenceLength() < g2.GetFenceLength();
        }

        public static bool operator >(Garden g1, Garden g2)
        {
            return g1.GetFenceLength() > g2.GetFenceLength();
        }
    }
}
