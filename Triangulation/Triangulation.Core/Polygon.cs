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
        private int _currentIndex;
        private int _countOfTops;

        public Polygon(List<Vertex> tops)
        {
            Tops = tops;
            _countOfTops = tops.Count;
            _currentIndex = 0;
        } 
        
        public void Reverse()
        {
            Tops.Reverse();
        }

        public virtual Vertex GetCentroid()
        {
            double x = 0;
            double y = 0;
            double coef = 6 * GetSquare();
            for (int i = 0; i < _countOfTops - 1; i++)
            {
                x += (Tops[i].X + Tops[i + 1].X) * (Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y);
                y += (Tops[i].Y + Tops[i + 1].Y) * (Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y);
            }
            x += Tops[_countOfTops - 1].X * Tops[0].X *
                (Tops[_countOfTops - 1].X * Tops[0].Y - Tops[0].X * Tops[_countOfTops - 1].Y);
            y += Tops[_countOfTops - 1].Y * Tops[0].Y *
               (Tops[_countOfTops - 1].X * Tops[0].Y - Tops[0].X * Tops[_countOfTops - 1].Y);
            return new Vertex(x / coef, y / coef);
        }

        public virtual double GetSquare()
        {
            double square = 0.0;
            for (int i = 0; i < _countOfTops - 1; i++)
                square += Tops[i].X * Tops[i + 1].Y - Tops[i + 1].X * Tops[i].Y;
            square += Tops[_countOfTops - 1].X * Tops[0].Y - Tops[0].X * Tops[_countOfTops - 1].Y;
            return square / 2;
        }

        public Vertex GetCurrentTop()
        {
            if (_currentIndex == _countOfTops)
            {
                _currentIndex = 0;
                return Tops[_countOfTops - 1];
            }
            return Tops[_currentIndex];
        }

        public Vertex GetNextTop()
        {
            if (_currentIndex == _countOfTops - 1)
                return Tops[0];
            return Tops[_currentIndex + 1];
        }

        public Vertex GetPreviousTop()
        {
            if (_currentIndex == 0)
                return Tops[_countOfTops - 1];
            return Tops[_currentIndex - 1];
        }

        public void RemoveCurrentTop()
        {
            Tops.RemoveAt(_currentIndex);
            _countOfTops--;
            _currentIndex = _currentIndex == 0 ? _currentIndex : _currentIndex - 1;
        }

        public bool HasTriangles()
        {
            _currentIndex++;
            return _countOfTops > 2;
        }

        public int CurrentIndex()
        {
            return _currentIndex;
        }
    }
}
