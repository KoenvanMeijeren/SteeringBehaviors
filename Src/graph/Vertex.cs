using System;
using System.Collections.Generic;
using System.Text;
using Src.util;

namespace Src.graph
{
    public class Vertex
    {
        private const float DefaultCost = 1,
            DefaultWeight = 1,
            UninitializedDistanceToTarget = -1;

        public readonly Vector Position;
        public readonly LinkedList<Edge> Edges;
        public Vertex Previous { get; set; }
        public float Cost { get; set; }
        public float DistanceToTarget { get; set; }
        public float Weight { get; }
        public float FinalCost
        {
            get
            {
                if (DistanceToTarget != UninitializedDistanceToTarget && Cost != UninitializedDistanceToTarget)
                {
                    return DistanceToTarget + Cost;
                }

                return UninitializedDistanceToTarget;
            }
        }

        public Vertex(int x, int y, float weight = DefaultWeight)
        {
            Previous = null;
            Edges = new LinkedList<Edge>();
            Position = new Vector(x, y);
            DistanceToTarget = UninitializedDistanceToTarget;
            Cost = DefaultCost;
            Weight = weight;
        }

        public void Reset()
        {
            Previous = null;
            DistanceToTarget = UninitializedDistanceToTarget;
            Cost = DefaultCost;
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
                stringBuilder.Append($"d={Weight}");
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
            return Math.Abs(Weight) > 0;
        }
    }
}
