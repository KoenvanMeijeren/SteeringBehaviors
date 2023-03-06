using System.Drawing;
using Src.graph;
using Src.util;

namespace SteeringCS.graph
{
    public static class GraphVisualizer
    {
        private static readonly Color s_renderColor = Color.IndianRed;

        public static void Render(Graphics graphic, Graph graph)
        {
            const int VertexSize = 1;
            Pen penVertex = new Pen(s_renderColor, 4);
            Pen penEdge = new Pen(s_renderColor);
            Rectangle rectangle = new Rectangle(0, 0, VertexSize, VertexSize);


            for (int x = 0; x < graph.Vertices.GetLength(0); x++)
            {
                for (int y = 0; y < graph.Vertices.GetLength(1); y++)
                {
                    if (graph.Vertices[x, y] == null)
                    {
                        continue;
                    }

                    VectorImmutable vector = graph.Vertices[x, y].Position - (VertexSize / 2);
                    rectangle.X = (int)vector.X;
                    rectangle.Y = (int)vector.Y;
                    graphic.DrawEllipse(penVertex, rectangle);

                    foreach (Edge edge in graph.Vertices[x, y].Edges)
                    {
                        graphic.DrawLine(penEdge, (int)edge.OwnerVertex.Position.X, (int)edge.OwnerVertex.Position.Y, (int)edge.DestinationVertex.Position.X, (int)edge.DestinationVertex.Position.Y);
                    }
                }
            }
        }
    }
}
