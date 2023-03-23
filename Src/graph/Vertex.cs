using System;
using System.Collections.Generic;
using System.Text;
using Src.util;

namespace Src.graph
{
    public class Vertex
    {
        private const float defaultCost = 0;

        public readonly Vector Position;
        public readonly LinkedList<Edge> Edges;

        public Vertex Parent { get; set; }
        public float Cost { get; set; }
        public int DistanceFromTarget { get; set; }

        public Vertex(int x, int y, float cost = defaultCost)
        {
            Edges = new LinkedList<Edge>();
            Position = new Vector(x, y);
            Cost = cost;
        }

        public void AddEdge(Edge edge)
        {
            Edges.AddLast(edge);
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Vertex to its string representation.
        ///    <para>Output will be like : name (distance) [ adj1 (cost) adj2 (cost) .. ]</para>
        ///    <para>Adjacency are ordered ascending by name. If no distance is
        ///    calculated yet, the distance and the parenthesis are omitted.</para>
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns> 
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
            return Math.Abs(Cost - defaultCost) > 0;
        }
    }
}
