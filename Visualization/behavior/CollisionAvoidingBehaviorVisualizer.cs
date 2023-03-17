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
            Vector positionAhead = _steeringBehavior.AheadPosition;
            RenderVelocity(graphic, position, _steeringBehavior.GetEntityVelocity());
            if (positionAhead == null)
            {
                return;
            }

            Pen pen = new Pen(s_renderColor, 2);

            Point positionPoint = new Point((int)position.X, (int)position.Y);
            Point positionAheadPoint = new Point((int)positionAhead.X, (int)positionAhead.Y);

            graphic.DrawLine(pen, positionPoint, positionAheadPoint);
        }
    }
}
