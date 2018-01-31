﻿using System;

namespace Triangulation.Core
{
    public class Vertex : IComparable, ICloneable
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(object obj)
        {
            var tolerance = 0.001;
            if (!(obj is Vertex compareTo))
                return 1;
            bool biggerByY = Y > compareTo.Y;
            bool biggerByX = Math.Abs(Y - compareTo.Y) < tolerance && X > compareTo.X;
            bool isEqual = Math.Abs(Y - compareTo.Y) < tolerance && Math.Abs(X - compareTo.X) < tolerance;
            if (isEqual)
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
