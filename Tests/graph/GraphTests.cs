using System;
using NUnit.Framework;
using Src.graph;

namespace Tests.graph
{
    public class GraphTests
    {
        [Test]
        public void Create_01_NullGraph_Ok()
        {
            // Arrange

            // Act
            Graph graph = GraphBuilder.CreateNullGraph();

            // Assert
            string[] resultLines = graph.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Assert.AreEqual(7, resultLines.Length);
            Assert.AreEqual("(0,0),(0,0),(0,0),(0,0),(0,0),(0,0)", resultLines[0]);
            Assert.AreEqual("(0,0),(1,1) (1) [ ],(0,0),(0,0),(0,0),(0,0)", resultLines[1]);
            Assert.AreEqual("(0,0),(0,0),(0,0),(0,0),(0,0),(0,0)", resultLines[2]);
            Assert.AreEqual("(0,0),(0,0),(0,0),(3,3) (2) [ ],(0,0),(0,0)", resultLines[3]);
            Assert.AreEqual("(0,0),(0,0),(0,0),(0,0),(4,4) (1) [ ],(0,0)", resultLines[4]);
            Assert.AreEqual("(0,0),(0,0),(0,0),(0,0),(0,0),(5,5) (1) [ ]", resultLines[5]);
        }
    }
}
