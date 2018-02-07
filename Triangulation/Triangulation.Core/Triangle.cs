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
    }
}
