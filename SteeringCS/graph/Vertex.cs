using Src.util;
using System.Collections.Generic;

namespace SteeringCS.graph
{
    public class Vertex
    {
        public readonly Position Position;
        public readonly LinkedList<Edge> Edges;

        public Vertex(int x, int y)
        {
            Edges = new LinkedList<Edge>();
            Position = new Position(x, y);
        }

        public void AddEdge(Edge edge)
        {
            Edges.AddLast(edge);
        }
    }
}
