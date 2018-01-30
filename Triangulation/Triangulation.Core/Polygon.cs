using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Core
{
    public class Polygon
    {
        public List<Vertex> Tops { get; private set; }
        private int _currentIndex;
        private int _countOfTops;

        public Polygon(List<Vertex> tops)
        {
            Tops = tops;
            _countOfTops = tops.Count;
            _currentIndex = 0;
        }

        public override string ToString()
        {
            string res = string.Empty;
            foreach (var point in Tops)
            {
                res += $"[{point.X},{point.Y}], ";
            }
            return res;
        }

        public Vertex GetCurrentTop()
        {
            if (_currentIndex == _countOfTops - 1)
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
