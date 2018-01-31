using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Core
{
    public class Polygon
    {
        public List<Vertex> Tops { get;set; }
        public List<Triangle> Triangles { get; set; }
        private List<Vertex> _topsForTriangulating;
        private int _currentIndex;
        private int _countOfTopsForTriangulation;

        public Polygon(List<Vertex> tops)
        {
            Tops = tops;
            _topsForTriangulating = new List<Vertex>(tops);
            Triangles = new List<Triangle>();
            _countOfTopsForTriangulation = tops.Count;
            _currentIndex = 0;
        } 
        
        public void Reverse()
        {
            Tops.Reverse();
            _topsForTriangulating.Reverse();
        }

        #region Centroids
        public virtual Vertex GetCentroidForTops()
        {
            double x = 0;
            double y = 0;
            for (int i = 0; i <= Tops.Count - 1; i++)
            {
                x += Tops[i].X;
                y += Tops[i].Y;
            }
            return new Vertex(x / Tops.Count, y / Tops.Count);
        }

        public Vertex GetCentroidForFrame()
        {
            if(Tops.Count < 3)
                return new Vertex(0, 0);
            var perimeter = GetPerimeter();
            double length;
            Vertex vectorMiddle;
            double resultX = 0.0;
            double resultY = 0.0;
            for (int i = 0; i < Tops.Count - 1; i++)
            {
                length = Geometry.GetEuclidianDistance(Tops[i], Tops[i + 1]);
                vectorMiddle = Geometry.GetMiddleBetween(Tops[i], Tops[i + 1]);
                resultX += vectorMiddle.X * length;
                resultY += vectorMiddle.Y * length;
            }
            length = Geometry.GetEuclidianDistance(Tops[0], Tops[Tops.Count - 1]);
            vectorMiddle = Geometry.GetMiddleBetween(Tops[0], Tops[Tops.Count - 1]);
            resultX += vectorMiddle.X * length;
            resultY += vectorMiddle.Y * length;

            return new Vertex(resultX / perimeter, resultY / perimeter);
        }

        public Vertex GetCentroidForBody()
        {
            if (Tops.Count < 3)
                return new Vertex(0, 0);
            var square = GetSquare();
            double x, y;
            x = y = 0;
            foreach(Triangle triangle in Triangles)
            {
                var triangleCentroid = triangle.GetCentroidForTops();
                var tiangleSquare = triangle.GetSquare();
                x += (triangleCentroid.X * tiangleSquare);
                y += (triangleCentroid.Y * tiangleSquare);
            }
            return new Vertex(x / square, y / square);
        }
        #endregion

        public virtual double GetSquare()
        {
            if (Tops.Count <= 2)
                return 0;
            double square = 0.0;
            for (int i = 0; i < Tops.Count - 1; i++)
                square += Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y;
            square += Tops[Tops.Count - 1].X * Tops[0].Y - Tops[0].X * Tops[Tops.Count - 1].Y;
            return square / 2;
        }

        public double GetPerimeter()
        {
            if (Tops.Count < 2)
                return 0;
            double result = 0.0;
            for (int i = 0; i <= Tops.Count - 2; i++)
                result += Geometry.GetEuclidianDistance(Tops[i], Tops[i + 1]);
            result += Geometry.GetEuclidianDistance(Tops[0], Tops[_countOfTopsForTriangulation - 1]);
            return result;
        }
        
        #region MoveByTops

        public Vertex GetCurrentTop()
        {
            if (_currentIndex == _countOfTopsForTriangulation)
            {
                _currentIndex = 0;
                return _topsForTriangulating[_countOfTopsForTriangulation - 1];
            }
            return _topsForTriangulating[_currentIndex];
        }

        public Vertex GetNextTop()
        {
            if (_currentIndex == _countOfTopsForTriangulation - 1)
                return _topsForTriangulating[0];
            return _topsForTriangulating[_currentIndex + 1];
        }

        public Vertex GetPreviousTop()
        {
            if (_currentIndex == 0)
                return _topsForTriangulating[_countOfTopsForTriangulation - 1];
            return _topsForTriangulating[_currentIndex - 1];
        }

        public void RemoveCurrentTop()
        {
            _topsForTriangulating.RemoveAt(_currentIndex);
            _countOfTopsForTriangulation--;
            _currentIndex = _currentIndex == 0 ? _currentIndex : _currentIndex - 1;
        }
        #endregion

        public bool HasTriangles()
        {
            _currentIndex++;
            return _countOfTopsForTriangulation > 2;
        }

        public int CurrentIndex()
        {
            return _currentIndex;
        }
    }
}
