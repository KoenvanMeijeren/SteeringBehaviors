using Src.util;
using System.Collections.Generic;

namespace SteeringCS.graph
{
    public class Vertex
    {
        public readonly VectorImmutable Position;
        public readonly LinkedList<Edge> Edges;

        public Vertex(int x, int y)
        {
            Edges = new LinkedList<Edge>();
            Position = new VectorImmutable(x, y);
        }

        public void AddEdge(Edge edge)
        {
            Edges.AddLast(edge);
        }
    }
}
