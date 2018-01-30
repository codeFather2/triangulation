using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triangulation.Core;

namespace Triangulation.UI
{
    public partial class MainForm : Form
    {
        private List<Vertex> _polygonTops;
        private List<Color> _colorsForTriangles;

        public MainForm()
        {
            InitializeComponent();
            _polygonTops = new List<Vertex>();
            _colorsForTriangles = new List<Color>
            {
                Color.Aqua,
                Color.Brown,
                Color.BlueViolet,
                Color.Yellow,
                Color.DarkBlue
            };
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PolygonPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var point = new Point(e.X, e.Y);
            var color = new SolidBrush(Color.Red);
            Graphics g = PolygonPanel.CreateGraphics();
            g.FillEllipse(color, point.X, point.Y, 7, 7);
            _polygonTops.Add(new Vertex(point.X, point.Y));
            Coordinates.Text += $"X: {e.X}, Y:{e.Y}\n";

        }

        private void TriangulateButton_Click(object sender, EventArgs e)
        {
            Graphics g = PolygonPanel.CreateGraphics();
            var polygon = new Polygon(_polygonTops);
            var triangulator = new Triangulator(polygon);
            List<Triangle> triangles = triangulator.Triangulate();
            int i = 0;
            foreach (var triangle in triangles)
            {
                int j = 0;
                var points = new PointF[3];
                foreach (Vertex top in triangle.Tops)
                {
                    points[j] = new PointF((float)top.X, (float)top.Y);
                    j++;
                }
                g.FillPolygon(new SolidBrush(_colorsForTriangles[i]), points);
                i++;
                i = i % 3 == 0 ? 0 : i;
                foreach (var point in points)
                {
                    g.FillEllipse(new SolidBrush(Color.Black), point.X, point.Y, 7, 7);
                }
            }
            _polygonTops = new List<Vertex>();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            PolygonPanel.Invalidate();
        }
    }
}
