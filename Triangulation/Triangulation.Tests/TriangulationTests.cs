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
                new Vertex(2, 0),
                new Vertex(2, 2),
                new Vertex(1, 0.7)
            });                     
            Triangulator triangulator = new Triangulator(square);
            List<Triangle> triangles = triangulator.Triangulate();
            Assert.AreEqual(2, triangles.Count);
        }
    }
}
