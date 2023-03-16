using System.Collections.Generic;
using Src.entity;
using Src.graph;
using Src.grid;

namespace Tests.graph
{
    public static class GraphBuilder
    {
        public static Graph CreateTrivialGraph()
        {
            Vertex[,] vertices = new Vertex[2, 2];
            vertices[1, 1] = new Vertex(1, 1, 1);

            return new Graph(vertices);
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

        public static Graph CreateUndirectedConnectedGraph()
        {
            Vertex[,] vertices = new Vertex[6, 6];

            Vertex vertex1 = new Vertex(1, 1, 1);
            vertices[1, 1] = vertex1;
            Vertex vertex3 = new Vertex(3, 3, 2);
            vertices[3, 3] = vertex3;
            Vertex vertex4 = new Vertex(4, 4, 1);
            vertices[4, 4] = vertex4;
            Vertex vertex5 = new Vertex(5, 5, 1);
            vertices[5, 5] = vertex5;
            vertex1.AddEdge(new Edge(vertex1, vertex3));
            vertex3.AddEdge(new Edge(vertex3, vertex1));
            vertex1.AddEdge(new Edge(vertex1, vertex4));
            vertex4.AddEdge(new Edge(vertex4, vertex1));
            vertex4.AddEdge(new Edge(vertex4, vertex5));
            vertex5.AddEdge(new Edge(vertex5, vertex4));
            vertex3.AddEdge(new Edge(vertex3, vertex5));
            vertex5.AddEdge(new Edge(vertex5, vertex3));

            return new Graph(vertices);
        }

        public static Graph CreateGridGraph(int width, int height, List<IMovingEntity> entities)
        {
            Grid grid = new Grid(width, height, entities, false);

            return grid.Graph;
        }
    }
}
