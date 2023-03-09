using Src.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Src.graph
{
    public class Graph
    {
        public readonly Vertex[,] Vertices;

        public Graph(Vertex[,] vertices)
        {
            Vertices = vertices;
            InitializeEdges();
        }

        private void InitializeEdges()
        {
            for (int x = 0; x < Vertices.GetLength(0); x++)
            {
                for (int y = 0; y < Vertices.GetLength(1); y++)
                {
                    if (Vertices[x, y] != null)
                    {
                        CreateEdgesWithSurroundingVertices(x, y);
                    }
                }
            }
        }

        private void CreateEdgesWithSurroundingVertices(int vertexX, int vertexY)
        {
            Vertex vertexCurrent = Vertices[vertexX, vertexY];

            Vertex vertexNorth = GetVertex(vertexX, vertexY - 1);
            Vertex vertexNorthEast = GetVertex(vertexX + 1, vertexY - 1);
            Vertex vertexEast = GetVertex(vertexX + 1, vertexY);
            Vertex vertexSouthEast = GetVertex(vertexX + 1, vertexY + 1);
            Vertex vertexSouth = GetVertex(vertexX, vertexY + 1);
            Vertex vertexSouthWest = GetVertex(vertexX - 1, vertexY + 1);
            Vertex vertexWest = GetVertex(vertexX - 1, vertexY);
            Vertex vertexNorthWest = GetVertex(vertexX - 1, vertexY - 1);

            if (vertexNorth != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorth);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexNorthEast != null && vertexNorth != null && vertexEast != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorthEast);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexEast != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexEast);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexSouthEast != null && vertexSouth != null && vertexEast != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexSouthEast);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexSouth != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexSouth);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexSouthWest != null && vertexSouth != null && vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexSouthWest);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexWest);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexNorthWest != null && vertexNorth != null && vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorthWest);
                vertexCurrent.AddEdge(edge);
            }
        }

        public Stack<Vertex> getShortestPath(Vertex startVertex, Vertex targetVertex)
        {
            if (startVertex == null || targetVertex == null)
            {
                return null;
            }

            Stack<Vertex> path = new Stack<Vertex>();
            VertexPriorityQueue OpenList = new VertexPriorityQueue();
            List<Vertex> ClosedList = new List<Vertex>();
            List<Vertex> adjacencies;
            Vertex current = startVertex;

            OpenList.Enqueue(startVertex, 0);

            while (OpenList.Count != 0 && !ClosedList.Exists(x => x == targetVertex))
            {
                current = OpenList.Dequeue();
                ClosedList.Add(current);
                adjacencies = getAdjacentVertexes(current);

                foreach (Vertex vertex in adjacencies)
                {
                    if (!ClosedList.Contains(vertex))
                    {
                        bool isFound = false;

                        if (!OpenList.Contains(vertex))
                        {
                            vertex.Parent = current;
                            vertex.DistanceFromTarget = (int)(Math.Abs(vertex.Position.X - targetVertex.Position.X) + Math.Abs(vertex.Position.Y - targetVertex.Position.Y));
                            int distanceFromParent = (int)(Math.Abs(vertex.Position.X - vertex.Parent.Position.X) + Math.Abs(vertex.Position.Y - vertex.Parent.Position.Y));


                            vertex.Cost = (distanceFromParent * 2) + vertex.Parent.Cost;
                            OpenList.Enqueue(vertex, vertex.Cost + vertex.DistanceFromTarget);
                        }
                    }
                }
            }

            if (!ClosedList.Exists(x => x == targetVertex))
            {
                return null;
            }

            Vertex temp = ClosedList[ClosedList.IndexOf(current)];

            if (temp == null)
            {
                return null;
            }

            while (temp != startVertex && temp != null)
            {
                path.Push(temp);
                temp = temp.Parent;
            }

            return path;
        }

        public Vertex GetVertex(int vertexX, int vertexY)
        {
            if (vertexX < 0 || vertexY < 0)
            {
                return null;
            }

            if (vertexX >= Vertices.GetLength(0) || vertexY >= Vertices.GetLength(1))
            {
                return null;
            }

            return Vertices[vertexX, vertexY];
        }

        public List<Vertex> getAdjacentVertexes(Vertex vertex)
        {
            List<Vertex> AdjacentVertexes = new List<Vertex>();

            foreach (Edge edge in vertex.Edges)
            {
                AdjacentVertexes.Add(edge.DestinationVertex);
            }

            return AdjacentVertexes;
        }
    }
}
