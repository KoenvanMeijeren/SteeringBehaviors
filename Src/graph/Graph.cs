using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Src.util;

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

        private void ClearAll()
        {
            foreach (Vertex vertex in Vertices)
            {
                vertex?.Reset();
            }
        }

        public ShortestPathResult GetShortestPath(Vertex startVertex, Vertex targetVertex)
        {
            if (startVertex == null || targetVertex == null)
            {
                return null;
            }

            ClearAll();
            Stack<Vertex> path = new Stack<Vertex>();
            VertexPriorityQueue openList = new VertexPriorityQueue();
            List<Vertex> closedList = new List<Vertex>();
            Vertex current = startVertex;

            openList.Enqueue(startVertex, 0);

            while (openList.Count != 0 && !closedList.Exists(vertex => vertex == targetVertex))
            {
                current = openList.Dequeue();
                closedList.Add(current);
                IEnumerable<Vertex> adjacentVertexes = GetAdjacentVertexes(current);

                foreach (Vertex vertex in adjacentVertexes
                             .Where(vertex => !closedList.Contains(vertex))
                             .Where(vertex => !openList.Contains(vertex)))
                {
                    vertex.Parent = current;
                    
                    double edgeHCost = CalculateManhattanDistance(vertex, targetVertex);
                    double parentEdgeHCost = CalculateManhattanDistance(vertex.Parent, targetVertex);
                    
                    vertex.DistanceFromTarget = (int) edgeHCost;
                    int distanceFromParent = (int) parentEdgeHCost;

                    vertex.Cost = distanceFromParent + vertex.Parent.Cost;
                    openList.Enqueue(vertex, vertex.Cost + vertex.DistanceFromTarget);
                }
            }

            if (!closedList.Exists(vertex => vertex == targetVertex))
            {
                return null;
            }

            Vertex temp = closedList.FirstOrDefault(vertex => vertex == current);
            temp = temp?.Parent;
            if (temp == null)
            {
                return null;
            }

            while (temp != startVertex && temp != null)
            {
                path.Push(temp);
                temp = temp.Parent;
            }

            return new ShortestPathResult(path, closedList);
        }

        /// <summary>
        /// Guess cost of traversing to target with the Manhattan Distance.
        /// </summary>
        private static double CalculateManhattanDistance(Vertex vertex, Vertex targetVertex)
        {
            double hX = Math.Abs(targetVertex.Position.X - vertex.Position.X) / 16;
            double hY = Math.Abs(targetVertex.Position.Y - vertex.Position.Y) / 16;
            
            return hX + hY;
        }

        public Vertex GetVertex(int row, int column)
        {
            return IsPositionWithInBounds(row, column, Vertices) ? Vertices[row, column] : null;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int row = 0; row < Vertices.GetLength(0); row++)
            {
                string delimiter = "";
                for (int column = 0; column < Vertices.GetLength(1); column++)
                {
                    string appendString = "{(0,0)}";
                    Vertex vertex = Vertices[row, column];
                    if (vertex != null)
                    {
                        appendString = vertex.ToString();
                    }

                    stringBuilder.Append(delimiter);
                    stringBuilder.Append(appendString);
                    delimiter = ",";
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private static IEnumerable<Vertex> GetAdjacentVertexes(Vertex vertex)
        {
            return vertex.Edges.Select(edge => edge.DestinationVertex).ToList();
        }

        private static bool IsPositionWithInBounds(int row, int column, Vertex[,] vertices)
        {
            if (row < 0 || row >= vertices.GetLength(0))
            {
                return false;
            }

            return column >= 0 && column < vertices.GetLength(1);
        }
    }

    public class ShortestPathResult
    {
        public readonly Stack<Vertex> Path;
        public readonly List<Vertex> SearchedVertices;

        public ShortestPathResult(Stack<Vertex> path, List<Vertex> searchedVertices)
        {
            Path = path;
            SearchedVertices = searchedVertices;
        }
    }
}
