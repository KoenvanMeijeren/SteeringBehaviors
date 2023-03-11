using Src.behavior;
using Src.entity;
using Src.graph;
using Src.util;
using System.Drawing;

namespace SteeringCS.behavior
{
    public class PathfindingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public PathfindingBehavior SteeringBehavior;
        private static readonly Color s_renderColor = Color.Orange;

        public PathfindingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new PathfindingBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return SteeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, SteeringBehavior.GetEntityPosition(), SteeringBehavior.GetEntityTargetPosition());

            if (SteeringBehavior.Path == null)
            {
                return;
            }

            const int VertexSize = 4;
            Pen penVertex = new Pen(s_renderColor, 4);
            Pen penEdge = new Pen(s_renderColor);
            Rectangle rectangle = new Rectangle(0, 0, VertexSize, VertexSize);

            Vertex prevVertex = null;

            foreach (Vertex vertex in SteeringBehavior.Path)
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
