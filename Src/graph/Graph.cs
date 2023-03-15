using Src.util;
using System;
using System.Collections.Generic;
using System.Linq;

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
            for (int row = 0; row < Vertices.GetLength(0); row++)
            {
                for (int column = 0; column < Vertices.GetLength(1); column++)
                {
                    if (Vertices[row, column] != null)
                    {
                        CreateEdgesWithSurroundingVertices(row, column);
                    }
                }
            }
        }

        private void CreateEdgesWithSurroundingVertices(int row, int column)
        {
            Vertex vertexCurrent = Vertices[row, column];

            Vertex vertexNorth = GetVertex(row, column - 1);
            Vertex vertexNorthEast = GetVertex(row + 1, column - 1);
            Vertex vertexEast = GetVertex(row + 1, column);
            Vertex vertexSouthEast = GetVertex(row + 1, column + 1);
            Vertex vertexSouth = GetVertex(row, column + 1);
            Vertex vertexSouthWest = GetVertex(row - 1, column + 1);
            Vertex vertexWest = GetVertex(row - 1, column);
            Vertex vertexNorthWest = GetVertex(row - 1, column - 1);

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

        public static Stack<Vertex> GetShortestPath(Vertex startVertex, Vertex targetVertex)
        {
            if (startVertex == null || targetVertex == null)
            {
                return null;
            }

            Stack<Vertex> path = new Stack<Vertex>();
            VertexPriorityQueue openList = new VertexPriorityQueue();
            List<Vertex> closedList = new List<Vertex>();
            Vertex current = startVertex;

            openList.Enqueue(startVertex, 0);

            while (openList.Count != 0 && !closedList.Exists(x => x == targetVertex))
            {
                current = openList.Dequeue();
                closedList.Add(current);
                IEnumerable<Vertex> adjacentVertexes = GetAdjacentVertexes(current);

                foreach (Vertex vertex in adjacentVertexes
                             .Where(vertex => !closedList.Contains(vertex))
                             .Where(vertex => !openList.Contains(vertex)))
                {
                    vertex.Parent = current;
                    vertex.DistanceFromTarget = (int)(Math.Abs(vertex.Position.X - targetVertex.Position.X) + Math.Abs(vertex.Position.Y - targetVertex.Position.Y));
                    int distanceFromParent = (int)(Math.Abs(vertex.Position.X - vertex.Parent.Position.X) + Math.Abs(vertex.Position.Y - vertex.Parent.Position.Y));

                    vertex.Cost = (distanceFromParent * 2) + vertex.Parent.Cost;
                    openList.Enqueue(vertex, vertex.Cost + vertex.DistanceFromTarget);
                }
            }

            if (!closedList.Exists(x => x == targetVertex))
            {
                return null;
            }

            Vertex temp = closedList[closedList.IndexOf(current)];

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

        private static IEnumerable<Vertex> GetAdjacentVertexes(Vertex vertex)
        {
            return vertex.Edges.Select(edge => edge.DestinationVertex).ToList();
        }
    }
}
