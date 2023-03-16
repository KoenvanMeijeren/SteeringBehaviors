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

        public override VectorImmutable Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, _steeringBehavior.GetEntityPosition(), _steeringBehavior.GetEntityVelocity());

            VectorImmutable targetCircle = _steeringBehavior.TargetCircle;
            VectorImmutable selectedPoint = _steeringBehavior.SelectedPoint;
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

            Pen redPen = new Pen(Color.Red, 2);
            Pen greenPen = new Pen(Color.Green, 2);
            graphic.DrawEllipse(redPen, new Rectangle((int)outerLeftCorner, (int)outerRightCorner, WanderingBehavior.CircleSize, WanderingBehavior.CircleSize));
            graphic.DrawEllipse(greenPen, new Rectangle((int)centerLeftCorner, (int)centerRightCorner, CenterSize, CenterSize));
            graphic.DrawEllipse(greenPen, new Rectangle((int)selectedLeftCorner, (int)selectedRightCorner, CenterSize, CenterSize));
        }
    }
}
