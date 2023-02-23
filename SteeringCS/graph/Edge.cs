using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.graph
{
    public class Edge
    {
        public Vertex OwnerVertex;
        public Vertex DestinationVertex;

        public Edge(Vertex ownerVertex, Vertex destinationVertex)
        {
            OwnerVertex = ownerVertex;
            DestinationVertex = destinationVertex;
        }
    }
}
