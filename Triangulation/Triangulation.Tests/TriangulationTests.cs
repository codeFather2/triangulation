using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangulation.Core;

namespace Triangulation.Tests
{
    [TestClass]
    public class TriangulationTests
    {
        [TestMethod]
        public void Can_Tiangulate_Square()
        {
            Polygon square = new Polygon(new List<Vertex>
            {
                new Vertex(0, 0),
                new Vertex(0, 2),
                new Vertex(2, 2),
                new Vertex(2, 0)
            });                     
            Triangulator triangulator = new Triangulator(square);
            square = triangulator.Triangulate();
            var centroid = square.GetCentroidForBody();
            centroid = square.GetCentroidForFrame();
            centroid = square.GetCentroidForTops();
            Assert.AreEqual(2, square.Triangles.Count);
        }
    }
}
