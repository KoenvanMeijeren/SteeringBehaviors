using Src.behavior;
using Src.entity;
using Src.graph;
using Src.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SteeringCS.behavior
{
    public class PathfindingBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        public PathfindingBehavior PathfindingBehavior { get; private set; }
        private static readonly Color s_renderColor = Color.Orange;

        public PathfindingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            PathfindingBehavior = new PathfindingBehavior(movingEntity);
        }

        public Vector Calculate()
        {
            return PathfindingBehavior.Calculate();
        }

        public void Render(Graphics graphic)
        {
            if (PathfindingBehavior.Path == null)
            {
                return;
            }

            const int VertexSize = 4;
            Pen penVertex = new Pen(s_renderColor, 4);
            Pen penEdge = new Pen(s_renderColor);
            Rectangle rectangle = new Rectangle(0, 0, VertexSize, VertexSize);

            Vertex prevVertex = null;

            foreach (Vertex vertex in PathfindingBehavior.Path)
            {
                VectorImmutable vector = vertex.Position - (VertexSize / 2);
                rectangle.X = (int)vector.X;
                rectangle.Y = (int)vector.Y;
                graphic.DrawEllipse(penVertex, rectangle);

                if (prevVertex != null)
                {
                    graphic.DrawLine(penEdge, (int)prevVertex.Position.X, (int)prevVertex.Position.Y, (int)vertex.Position.X, (int)vertex.Position.Y);
                }

                prevVertex = vertex;
            }
        }
    }
}
