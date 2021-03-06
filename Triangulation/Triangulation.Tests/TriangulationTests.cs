﻿using System;
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
                new Vertex(0, 2000),
                new Vertex(2000, 2000),
                new Vertex(2000, 0)
            });                     
            Triangulator triangulator = new Triangulator(square);

            square = triangulator.Triangulate();
            var centroidForBody = square.GetCentroidForBody();
            var centroidForFrame = square.GetCentroidForFrame();
            var centroidForTops = square.GetCentroidForTops();

            Assert.AreEqual(2, square.Triangles.Count);
            Assert.AreEqual(centroidForTops.CompareTo(centroidForFrame), 0);
            Assert.AreEqual(centroidForTops.CompareTo(centroidForBody), 0);
            Assert.AreEqual(centroidForBody.CompareTo(centroidForFrame), 0);
        }

        [TestMethod]
        public void Test_Less_Than_Two_Verticies()
        {
            Polygon line = new Polygon(new List<Vertex>
            {
                new Vertex(0, 1),
                new Vertex(15, 7)
            });
            Triangulator traingulator = new Triangulator(line);

            line = traingulator.Triangulate();

            Assert.AreEqual(0, line.Triangles.Count);
        }
    }
}
