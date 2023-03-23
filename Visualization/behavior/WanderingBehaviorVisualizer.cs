using Src.util;
using System.Drawing;
using Src.behavior;
using Src.entity;

namespace SteeringCS.behavior
{
    public class WanderingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly WanderingBehavior _steeringBehavior;

        public WanderingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new WanderingBehavior(movingEntity);
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
            Vector targetCircle = _steeringBehavior.TargetCircle;
            Vector selectedPoint = _steeringBehavior.SelectedPoint;
            if (targetCircle == null)
            {
                return;
            }

            const int CenterRadius = 2, CenterSize = CenterRadius * 2;
            double outerLeftCorner = targetCircle.X - WanderingBehavior.CircleRadius;
            double outerRightCorner = targetCircle.Y - WanderingBehavior.CircleRadius;
            double centerLeftCorner = targetCircle.X - CenterRadius;
            double centerRightCorner = targetCircle.Y - CenterRadius;
            double selectedLeftCorner = selectedPoint.X - CenterRadius;
            double selectedRightCorner = selectedPoint.Y - CenterRadius;

            Pen outerCirclePen = new Pen(Color.Red, 2);
            Pen selectedPointPen = new Pen(Color.DarkGreen, 2);
            graphic.DrawEllipse(outerCirclePen, new Rectangle((int)outerLeftCorner, (int)outerRightCorner, WanderingBehavior.CircleSize, WanderingBehavior.CircleSize));
            graphic.DrawEllipse(selectedPointPen, new Rectangle((int)centerLeftCorner, (int)centerRightCorner, CenterSize, CenterSize));
            graphic.DrawEllipse(selectedPointPen, new Rectangle((int)selectedLeftCorner, (int)selectedRightCorner, CenterSize, CenterSize));
        }

        public override void RenderVelocity(Graphics graphic)
        {
            Vector position = _steeringBehavior.GetEntityPosition();

            RenderVelocity(graphic, position, _steeringBehavior.GetEntityVelocity());
            RenderVelocityText(graphic, position, _steeringBehavior.GetEntityVelocity());
        }
    }
}
