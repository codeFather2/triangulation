using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangulation.UI
{
    public partial class MainForm : Form
    {
        private List<PointF> _points;

        public MainForm()
        {
            InitializeComponent();
            _points = new List<PointF>();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PolygonPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var color = new SolidBrush(Color.Red);
            Graphics g = PolygonPanel.CreateGraphics();
            g.FillEllipse(color, e.X, e.Y, 7, 7);
            _points.Add(new Point(e.X, e.Y));
        }

        private void TriangulateButton_Click(object sender, EventArgs e)
        {
            Graphics g = PolygonPanel.CreateGraphics();
            g.FillPolygon(new SolidBrush(Color.Green), _points.ToArray());
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            PolygonPanel.Invalidate();
        }
    }
}
