using SteeringCS.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.graph
{
    public class Vertex
    {
        public Position Position;
        public LinkedList<Edge> Edges;

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
