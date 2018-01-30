using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Core
{
    public class Triangulator
    {
        public Vertex Centroid { get; private set; }
        private Polygon _polygon;


        public Triangulator(Polygon polygon)
        {
            _polygon = polygon;
        }

        public List<Triangle> Triangulate()
        {
            var triangles = new List<Triangle>();
            //SortTopsClockwize();
            if (_polygon.GetSquare() < 0)
                _polygon.Reverse();
            while(_polygon.HasTriangles())
            {
                var current = _polygon.GetCurrentTop();
                var next = _polygon.GetNextTop();
                var previous = _polygon.GetPreviousTop();
                var isOk = IsLeft(previous, current, next) && CanBuildTriangle(previous, current, next);
                if (isOk)
                {
                    triangles.Add(new Triangle(new List<Vertex>
                    {
                       current, next, previous 
                    }));
                    _polygon.RemoveCurrentTop();
                }
            }
            return triangles;
        }
        
        private void SortTopsClockwize()
        {
            Centroid = _polygon.GetCentroid();
            _polygon.Tops.Sort((top, nextTop) =>
                GetRadialAngle(top, Centroid).CompareTo(GetRadialAngle(nextTop, Centroid))
                );
        }

        private bool IsLeft(Vertex pointA, Vertex basePoint, Vertex pointB)
        {
            double aBaseX = pointA.X - basePoint.X;
            double aBaseY = pointA.Y - basePoint.Y;
            double bBaseX = pointB.X - basePoint.X;
            double bBaseY = pointB.Y - basePoint.Y;
            var res = aBaseX * bBaseY - bBaseX * aBaseY;
            return  res < 0;
        }

        private bool CanBuildTriangle(Vertex pointA, Vertex basePoint, Vertex pointB)
        {
            var tops = _polygon.Tops.Where(x => x != basePoint && x != pointA && x != pointB).ToList();
            for (int i = 0; i < tops.Count; i++)
                    if (IsPointInside(pointA, basePoint, pointB, tops[i]))
                        return false;
            return true;
        }

        private bool IsPointInside(Vertex a, Vertex b, Vertex c, Vertex p)
        {
            double ab = (a.X - p.X) * (b.Y - a.Y) - (b.X - a.X) * (a.Y - p.Y);
            double bc = (b.X - p.X) * (c.Y - b.Y) - (c.X - b.X) * (b.Y - p.Y);
            double ca = (c.X - p.X) * (a.Y - c.Y) - (a.X - c.X) * (c.Y - p.Y);

            return (ab >= 0 && bc >= 0 && ca >= 0) || (ab <= 0 && bc <= 0 && ca <= 0);
        }

        private double GetRadialAngle(Vertex target, Vertex source)
        {
            double angle = Math.Acos((target.X - source.X) / GetEuclidianDistance(source, target));
            if (target.Y < source.Y)
            {
                angle = Math.PI * 2 - angle;
            }
            return angle;
        }

        private double GetEuclidianDistance(Vertex source, Vertex target)
        {
            var distance = Math.Pow(source.X - target.X, 2) + Math.Pow(source.Y - target.Y, 2);
            return Math.Sqrt(distance);
        }
    }
}
