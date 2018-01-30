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
            double coef = 6 * GetSquare() / 2;
            for (int i = 0; i < Tops.Count - 1; i++)
            {
                x += (Tops[i].X + Tops[i + 1].X) * (Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y);
                y += (Tops[i].Y + Tops[i + 1].Y) * (Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y);
            }
            return new Vertex(x / coef, y / coef);
        }

        public Vertex GetCentroidForFrame()
        {
            var perimeter = GetPerimeter();
            double length = 0.0;
            var vectorMiddle = new Vertex(0, 0);
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
            var square = GetSquare();
            long x, y;
            x = y = 0;
            foreach(Triangle triangle in Triangles)
            {
                var triangleCentroid = triangle.GetCentroidForTops();
                var tiangleSquare = triangle.GetSquare();
                x += (long)(triangleCentroid.X * tiangleSquare);
                y += (long)(triangleCentroid.Y * tiangleSquare);
            }
            return new Vertex(x / square, y / square);
        }
        #endregion

        public virtual double GetSquare()
        {
            double square = 0.0;
            for (int i = 0; i < Tops.Count - 1; i++)
                square += Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y;
            square += Tops[_countOfTopsForTriangulation - 1].X * Tops[0].Y - Tops[0].X * Tops[_countOfTopsForTriangulation - 1].Y;
            return square;
        }

        public double GetPerimeter()
        {
            double result = 0.0;
            for (int i = 0; i <= Tops.Count - 2; i++)
                result += Geometry.GetEuclidianDistance(Tops[i], Tops[i + 1]);
            result += Geometry.GetEuclidianDistance(Tops[0], Tops[_countOfTopsForTriangulation - 1]);
            return result;
        }

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
