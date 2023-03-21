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
        private static readonly Color s_renderColor = Color.DeepPink;
        private static readonly Color s_secondaryRenderColor = Color.Pink;
        private static readonly Color s_successRenderColor = Color.DarkGreen;
        private static readonly Color s_dangerRenderColor = Color.DarkRed;
        public CollisionAvoidingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new CollisionAvoidingBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            Vector position = _steeringBehavior.GetEntityPosition();
            RenderVelocity(graphic, position, _steeringBehavior.GetEntityVelocity());

            const int CenterRadius = 2, CenterSize = CenterRadius * 2;
            Pen pen = new Pen(s_renderColor, 2);
            Pen penSecondary = new Pen(s_secondaryRenderColor, 2);
            Pen penSuccess = new Pen(s_successRenderColor, 2);
            Pen penDanger = new Pen(s_dangerRenderColor, 2);

            Point positionPoint = new Point((int)position.X, (int)position.Y);

            foreach ((Vector positionAhead, Vector positionAheadHalf) in _steeringBehavior.AheadPositions)
            {
                Point positionAheadPoint = new Point((int)positionAhead.X, (int)positionAhead.Y);
                Point positionAheadHalfPoint = new Point((int)positionAheadHalf.X, (int)positionAheadHalf.Y);

                graphic.DrawLine(pen, positionPoint, positionAheadPoint);
                graphic.DrawLine(penSecondary, positionPoint, positionAheadHalfPoint);
            }

            Vector positionAfterAvoidance = _steeringBehavior.AvoidancePosition;
            if (positionAfterAvoidance != null && !positionAfterAvoidance.IsEmpty())
            {
                Point positionAfterAvoidancePoint = new Point((int)positionAfterAvoidance.X, (int)positionAfterAvoidance.Y);
                graphic.DrawLine(penDanger, positionPoint, positionAfterAvoidancePoint);
            }

            foreach ((_, Vector mostThreateningObject) in _steeringBehavior.MostThreateningObjects)
            {
                graphic.DrawEllipse(penSuccess, new Rectangle((int)mostThreateningObject.X, (int)mostThreateningObject.Y, CenterSize, CenterSize));
            }
        }
    }
}
