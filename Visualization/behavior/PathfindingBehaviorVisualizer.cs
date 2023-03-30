using Src.behavior;
using Src.entity;
using Src.graph;
using Src.util;
using System.Drawing;
using System.Linq;

namespace SteeringCS.behavior
{
    public class PathfindingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly PathfindingBehavior _steeringBehavior;
        private static readonly Color s_pathRenderColor = Color.DarkBlue, s_searchedVertexRenderColor = Color.Red;

        public PathfindingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new PathfindingBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override bool ShouldAvoidObstacles()
        {
            return _steeringBehavior.ShouldAvoidObstacles();
        }

        public override void Render(Graphics graphic)
        {
            if (_steeringBehavior.Path == null)
            {
                return;
            }

            const int VertexSize = 4;
            Pen penForPathVertex = new Pen(s_pathRenderColor, 4);
            Pen penForSearchedVertex = new Pen(s_searchedVertexRenderColor, 4);
            Pen penEdge = new Pen(s_pathRenderColor);
            Rectangle rectangle = new Rectangle(0, 0, VertexSize, VertexSize);

            Vertex prevVertex = null;

            foreach (Vector vector in _steeringBehavior.SearchedVertices.Select(vertex => vertex.Position))
            {
                Vector updatedVector = vector - (VertexSize / 2);
                rectangle.X = (int)updatedVector.X;
                rectangle.Y = (int)updatedVector.Y;
                graphic.DrawEllipse(penForSearchedVertex, rectangle);
            }

            foreach (Vertex vertex in _steeringBehavior.Path)
            {
                Vector vector = vertex.Position - (VertexSize / 2);
                rectangle.X = (int)vector.X;
                rectangle.Y = (int)vector.Y;
                graphic.DrawEllipse(penForPathVertex, rectangle);

                if (prevVertex != null)
                {
                    graphic.DrawLine(penEdge, (int)prevVertex.Position.X, (int)prevVertex.Position.Y, (int)vertex.Position.X, (int)vertex.Position.Y);
                }

                prevVertex = vertex;
            }
        }

        public override void RenderVelocity(Graphics graphic)
        {
            Vector position = _steeringBehavior.GetEntityPosition();

            RenderVelocity(graphic, position, _steeringBehavior.GetEntityVelocity());
            RenderVelocityText(graphic, position, _steeringBehavior.GetEntityVelocity());
        }
    }
}
