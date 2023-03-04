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
                vertexWest.AddEdge(edge);
            }

            if (vertexNorthWest != null && vertexNorth != null && vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorthWest);
                vertexCurrent.AddEdge(edge);
            }
        }

        private Vertex GetVertex(int vertexX, int vertexY)
        {
            if (vertexX < 0 || vertexY < 0)
            {
                return null;
            }

            if (vertexX >= Vertices.GetLength(0) || vertexY >= Vertices.GetLength(1))
            {
                return null;
            }

            return Vertices[vertexX, vertexY]; ;
        }
    }
}
