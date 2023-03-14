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

            for (int row = 0; row < graph.Vertices.GetLength(0); row++)
            {
                for (int column = 0; column < graph.Vertices.GetLength(1); column++)
                {
                    if (graph.Vertices[row, column] == null)
                    {
                        continue;
                    }

                    VectorImmutable vector = graph.Vertices[row, column].Position - (VertexSize / 2);
                    rectangle.X = (int)vector.X;
                    rectangle.Y = (int)vector.Y;
                    graphic.DrawEllipse(penVertex, rectangle);

                    foreach (Edge edge in graph.Vertices[row, column].Edges)
                    {
                        graphic.DrawLine(penEdge, (int)edge.OwnerVertex.Position.X, (int)edge.OwnerVertex.Position.Y, (int)edge.DestinationVertex.Position.X, (int)edge.DestinationVertex.Position.Y);
                    }
                }
            }
        }
    }
}
