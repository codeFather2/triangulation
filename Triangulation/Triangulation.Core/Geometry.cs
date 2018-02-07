using System;

namespace Triangulation.Core
{
    public static class Geometry
    {
        public static double GetEuclidianDistance(Vertex source, Vertex target)
        {
            var xDistance = source.X - target.X;
            var yDistance = source.Y - target.Y;
            var distance = (xDistance * xDistance) + (yDistance * yDistance);
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
