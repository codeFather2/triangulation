using System;

namespace Triangulation.Core
{
    public struct Vertex : IComparable, ICloneable, IEquatable<Vertex>
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Vertex other)
        { 
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        public int CompareTo(object obj)
        {
            if (!(obj is Vertex compareTo))
                return 1;
            bool biggerByY = Y > compareTo.Y;
            bool biggerByX = X > compareTo.X;
            if (Equals(compareTo))
            {
                return 0;
            }
            if (biggerByY || biggerByX)
            {
                return 1;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }

        public object Clone()
        {
            return new Vertex(X, Y);
        }
    }
}
