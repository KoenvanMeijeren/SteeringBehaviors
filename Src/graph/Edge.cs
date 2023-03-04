namespace Src.graph
{
    public class Edge
    {
        public readonly Vertex OwnerVertex;
        public readonly Vertex DestinationVertex;

        public Edge(Vertex ownerVertex, Vertex destinationVertex)
        {
            OwnerVertex = ownerVertex;
            DestinationVertex = destinationVertex;
        }
    }
}
