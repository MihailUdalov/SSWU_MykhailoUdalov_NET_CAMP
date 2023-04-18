using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    internal class FencePlanner
    {
        //JarvisAlgorithm
        public static List<Point> GetFenchPoint(List<Point> points)
        {
            if (points.Count <= 2)
                throw new ArgumentException();

            if (points.Count == 3)
                return points;

            List<Point> fencePoints = new List<Point>();

            Point leftMostPoint = points.Aggregate((minPoint, point) =>
             point.Y < minPoint.Y || (point.Y == minPoint.Y && point.X < minPoint.X) ? point : minPoint);


            Point currentPoint = leftMostPoint;

            do
            {
                fencePoints.Add(currentPoint);

                Point nextPoint = points[0];
                for (int i = 1; i < points.Count; i++)
                {
                    if (nextPoint == currentPoint || CrossProduct(currentPoint, nextPoint, points[i]) == -1)
                    {
                        nextPoint = points[i];
                    }
                }

                currentPoint = nextPoint;
            } while (currentPoint != leftMostPoint);

            return fencePoints;
        }

        private static double CrossProduct(Point currentPoint, Point nextPoint, Point checkingPoint)
        {


            double crossProduct = (nextPoint.Y - currentPoint.Y) * (checkingPoint.X - nextPoint.X) - (nextPoint.X - currentPoint.X) * (checkingPoint.Y - nextPoint.Y);

            return (crossProduct > 0) ? 1 : -1;
        }
    }
}
