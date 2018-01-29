using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Core
{
    public class Point
    {
        public string Name { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y, string name)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
