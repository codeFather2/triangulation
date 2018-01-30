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
        private Polygon _polygon;


        public Triangulator(Polygon polygon)
        {
            _polygon = polygon;
        }

        public Polygon Triangulate()
        {            
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
                    _polygon.Triangles.Add(new Triangle(new List<Vertex>
                    {
                       current, next, previous 
                    }));
                    _polygon.RemoveCurrentTop();
                }
            }
            return _polygon;
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
    }
}
