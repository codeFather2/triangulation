using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Core
{
    public class Polygon
    {
        public List<Point> Points { get; private set; }

        public Polygon(List<Point> points)
        {
            Points = points;
        }
    }
}
