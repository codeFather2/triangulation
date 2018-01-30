using System;

namespace Triangulation.Core
{
    public static class Geometry
    {
        public static double GetRadialAngle(Vertex target, Vertex source)
        {
            double angle = Math.Acos((target.X - source.X) / GetEuclidianDistance(source, target));
            if (target.Y < source.Y)
            {
                angle = Math.PI * 2 - angle;
            }
            return angle;
        }

        public static double GetEuclidianDistance(Vertex source, Vertex target)
        {
            var distance = Math.Pow(source.X - target.X, 2) + Math.Pow(source.Y - target.Y, 2);
            return Math.Sqrt(distance);
        }

        public static Vertex GetMiddleBetween(Vertex pointA, Vertex PointB)
        {
            var x = pointA.X + PointB.X;
            var y = pointA.Y + PointB.Y;
            return new Vertex(x / 2, y / 2);
        }
    }
}
