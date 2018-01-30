using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Core
{
    public class Triangle : Polygon
    {
        public Triangle(List<Vertex> tops) : base(tops)
        {
        }

        public override Vertex GetCentroidForTops()
        {
            double x = 0.0;
            double y = 0.0;
            foreach(Vertex top in Tops)
            {
                x += top.X;
                y += top.Y;
            }
            return new Vertex(x / 3, y / 3);
        }

        public override double GetSquare()
        {
            double res = 1.0;
            double halfOfPerimeter = GetPerimeter() / 2;
            for(int i = 0; i < 2; i++)
            {
                res = res * (halfOfPerimeter - Geometry.GetEuclidianDistance(Tops[i], Tops[i + 1])); 
            }
            res = res * (halfOfPerimeter - Geometry.GetEuclidianDistance(Tops[0], Tops[Tops.Count - 1]));
            return Math.Sqrt(res * halfOfPerimeter);
        }
    }
}
