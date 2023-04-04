using System;
using System.Collections.Generic;
using System.Text;
using Src.util;

namespace Src.graph
{
    public class Vertex
    {
        private const float DefaultCost = 0;

        public readonly Vector Position;
        public readonly LinkedList<Edge> Edges;
        public Vertex Parent { get; set; }
        public float Cost { get; set; }
        public int DistanceFromTarget { get; set; }

        public Vertex(int x, int y, float cost = DefaultCost)
        {
            Edges = new LinkedList<Edge>();
            Position = new Vector(x, y);
            Cost = cost;
        }

        public void Reset()
        {
            Parent = null;
            Cost = DefaultCost;
            DistanceFromTarget = 0;
        }
        
        public void AddEdge(Edge edge)
        {
            Edges.AddLast(edge);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{" + Position);
            if (HasCalculatedDistance())
            {
                stringBuilder.Append($"d={Cost}");
            }

            stringBuilder.Append("->[");
            string delimiter = "";
            foreach (Edge edge in Edges)
            {
                stringBuilder.Append(delimiter);
                stringBuilder.Append($"{edge}");
                delimiter = ",";
            }

            stringBuilder.Append("]");
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        private bool HasCalculatedDistance()
        {
            return Math.Abs(Cost - DefaultCost) > 0;
        }
    }
}
