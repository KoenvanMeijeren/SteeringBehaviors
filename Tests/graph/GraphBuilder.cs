using Src.graph;

namespace Tests.graph
{
    public static class GraphBuilder
    {
        public static Vertex CreateTrivialGraph()
        {
            return new Vertex(1, 1);
        }

        public static Graph CreateNullGraph()
        {
            Vertex[,] vertices = new Vertex[6, 6];
            vertices[1, 1] = new Vertex(1, 1, 1);
            vertices[3, 3] = new Vertex(3, 3, 2);
            vertices[4, 4] = new Vertex(4, 4, 1);
            vertices[5, 5] = new Vertex(5, 5, 1);

            return new Graph(vertices);
        }
    }
}
