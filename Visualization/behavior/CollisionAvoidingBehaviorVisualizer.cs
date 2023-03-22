using System;
using Src.behavior;
using Src.entity;
using Src.util;
using System.Drawing;

namespace SteeringCS.behavior
{
    public class CollisionAvoidingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly CollisionAvoidingBehavior _steeringBehavior;
        private static readonly Color s_positionAheadRenderColor = Color.DeepPink;
        private static readonly Color s_positionAheadHalfRenderColor = Color.Pink;
        private static readonly Color s_threateningObjectRenderColor = Color.DarkGreen;
        private static readonly Color s_avoidancePositionRenderColor = Color.Aqua;
        public CollisionAvoidingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new CollisionAvoidingBehavior(movingEntity);
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
            Vector position = _steeringBehavior.GetEntityPosition();

            const int CenterRadius = 2, CenterSize = CenterRadius * 2;
            Pen penPositionAhead = new Pen(s_positionAheadRenderColor, 2);
            Pen penPositionAheadHalf = new Pen(s_positionAheadHalfRenderColor, 2);
            Pen penThreateningObject = new Pen(s_threateningObjectRenderColor, 2);
            Pen penAvoidancePosition = new Pen(s_avoidancePositionRenderColor, 2);

            Point positionPoint = new Point((int)position.X, (int)position.Y);

            foreach ((Vector positionAhead, Vector positionAheadHalf) in _steeringBehavior.AheadPositions)
            {
                Point positionAheadPoint = new Point((int)positionAhead.X, (int)positionAhead.Y);
                Point positionAheadHalfPoint = new Point((int)positionAheadHalf.X, (int)positionAheadHalf.Y);

                graphic.DrawLine(penPositionAhead, positionPoint, positionAheadPoint);
                graphic.DrawLine(penPositionAheadHalf, positionPoint, positionAheadHalfPoint);
            }

            Vector positionAfterAvoidance = _steeringBehavior.AvoidancePosition;
            if (positionAfterAvoidance != null && !positionAfterAvoidance.IsEmpty())
            {
                Point positionAfterAvoidancePoint = new Point((int)positionAfterAvoidance.X, (int)positionAfterAvoidance.Y);
                graphic.DrawLine(penAvoidancePosition, positionPoint, positionAfterAvoidancePoint);
            }

            foreach ((_, Vector mostThreateningObject) in _steeringBehavior.MostThreateningObjects)
            {
                graphic.DrawEllipse(penThreateningObject, new Rectangle((int)mostThreateningObject.X, (int)mostThreateningObject.Y, CenterSize, CenterSize));
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
