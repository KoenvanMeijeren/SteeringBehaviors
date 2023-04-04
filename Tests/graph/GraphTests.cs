using System;
using System.Collections.Generic;
using NUnit.Framework;
using Src.graph;
using Src.util;
using Tests.fixtures.world;

namespace Tests.graph
{
    public class GraphTests
    {
        [Test]
        public void Create_01_TrivialGraph_Ok()
        {
            // Arrange
            Graph graph = GraphBuilder.CreateTrivialGraph();

            // Act
            string[] resultLines = graph.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Assert
            Assert.AreEqual(3, resultLines.Length);
            Assert.AreEqual("{(0,0)},{(0,0)}", resultLines[0]);
            Assert.AreEqual("{(0,0)},{(1,1)d=1->[]}", resultLines[1]);
        }

        [Test]
        public void Create_02_NullGraph_Ok()
        {
            // Arrange
            Graph graph = GraphBuilder.CreateNullGraph();

            // Act
            string[] resultLines = graph.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Assert
            Assert.AreEqual(7, resultLines.Length);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[0]);
            Assert.AreEqual("{(0,0)},{(1,1)d=1->[]},{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[1]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[2]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(3,3)d=2->[]},{(0,0)},{(0,0)}", resultLines[3]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(4,4)d=1->[]},{(0,0)}", resultLines[4]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(5,5)d=1->[]}", resultLines[5]);
        }

        [Test]
        public void Create_03_UndirectedConnectedGraph_Ok()
        {
            // Arrange
            Graph graph = GraphBuilder.CreateUndirectedConnectedGraph();

            // Act
            string[] resultLines = graph.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Assert
            Assert.AreEqual(7, resultLines.Length);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[0]);
            Assert.AreEqual("{(0,0)},{(1,1)d=1->[(3,3),(4,4)]},{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[1]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[2]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(3,3)d=2->[(1,1),(5,5)]},{(0,0)},{(0,0)}", resultLines[3]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(4,4)d=1->[(1,1),(5,5)]},{(0,0)}", resultLines[4]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(0,0)},{(5,5)d=1->[(4,4),(3,3)]}", resultLines[5]);
        }

        [Test]
        public void Create_04_GridGraph_Ok()
        {
            // Arrange
            Graph graph = GraphBuilder.CreateGridGraph(100, 100);

            // Act
            string[] resultLines = graph.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Assert
            Assert.AreEqual(5, resultLines.Length);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[0]);
            Assert.AreEqual("{(0,0)},{(48,48)d=1->[(80,48),(80,80),(48,80)]},{(48,80)d=1->[(48,48),(80,48),(80,80)]},{(0,0)}", resultLines[1]);
            Assert.AreEqual("{(0,0)},{(80,48)d=1->[(80,80),(48,80),(48,48)]},{(80,80)d=1->[(80,48),(48,80),(48,48)]},{(0,0)}", resultLines[2]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[3]);
            Assert.AreEqual("", resultLines[4]);
        }

        [Test]
        public void Create_05_WorldGridGraph_Ok()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(50, 50);
            WorldTest world = new WorldTest(100, 100, seekingEntityPosition, targetEntityPosition);
            Graph graph = world.Grid.Graph;

            // Act
            string[] resultLines = graph.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            // Assert
            Assert.AreEqual(5, resultLines.Length);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[0]);
            Assert.AreEqual("{(0,0)},{(48,48)d=1->[(80,48),(80,80),(48,80)]},{(48,80)d=1->[(48,48),(80,48),(80,80)]},{(0,0)}", resultLines[1]);
            Assert.AreEqual("{(0,0)},{(80,48)d=1->[(80,80),(48,80),(48,48)]},{(80,80)d=1->[(80,48),(48,80),(48,48)]},{(0,0)}", resultLines[2]);
            Assert.AreEqual("{(0,0)},{(0,0)},{(0,0)},{(0,0)}", resultLines[3]);
            Assert.AreEqual("", resultLines[4]);
        }

        [Test]
        public void GetVertex_01_WorldGridGraph_Ok()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(50, 50);
            WorldTest world = new WorldTest(100, 100, seekingEntityPosition, targetEntityPosition);
            Graph graph = world.Grid.Graph;

            // Act
            Vertex vertex = graph.GetVertex(1, 1);

            // Assert
            Assert.AreEqual("{(48,48)d=1->[(80,48),(80,80),(48,80)]}", vertex.ToString());
        }

        [Test]
        public void GetVertex_02_WorldGridGraph_Ok_DoesNotThrowOnNull()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(50, 50);
            WorldTest world = new WorldTest(100, 100, seekingEntityPosition, targetEntityPosition);
            Graph graph = world.Grid.Graph;

            // Act
            Vertex vertex = graph.GetVertex(3, 1);

            // Assert
            Assert.IsNull(vertex);
        }

        [Test]
        public void GetVertex_03_WorldGridGraph_Ok_DoesNotThrowOnPositionsOutOfBound()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(50, 50);
            WorldTest world = new WorldTest(100, 100, seekingEntityPosition, targetEntityPosition);
            Graph graph = world.Grid.Graph;

            // Act
            Vertex vertex = graph.GetVertex(1000, 1);

            // Assert
            Assert.IsNull(vertex);
        }

        [Test]
        public void GetShortestPath_01_WorldGridGraph_Ok()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(75, 75);
            WorldTest world = new WorldTest(150, 150, seekingEntityPosition, targetEntityPosition);
            Graph graph = world.Grid.Graph;
            Vertex startVertex = graph.GetVertex(1, 1);
            Vertex targetVertex = graph.GetVertex(3, 3);

            // Act
            ShortestPathResult result = graph.GetShortestPath(startVertex, targetVertex);
            Stack<Vertex> pathVertices = result.Path;

            // Assert
            Assert.AreEqual(2, pathVertices.Count);
            Assert.AreEqual("(48,48)", startVertex.Position.ToString());
            Assert.AreEqual("(80,80)", pathVertices.Pop().Position.ToString());
            Assert.AreEqual("(112,112)", targetVertex.Position.ToString());
        }

        [Test]
        public void GetShortestPath_02_WorldGridGraph_Ok_DoesNotCrashOnEmptyInputVertex()
        {
            // Act
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(75, 75);
            WorldTest world = new WorldTest(150, 150, seekingEntityPosition, targetEntityPosition);
            Graph graph = world.Grid.Graph;
            ShortestPathResult result = graph.GetShortestPath(null, null);

            // Assert
            Assert.IsNull(result);
        }
    }
}
