using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class SeekingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly SeekingBehavior _steeringBehavior;

        public SeekingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new SeekingBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            Vector position = _steeringBehavior.GetEntityPosition();
            SolidBrush brush = new SolidBrush(Color.Red);
            Font font = new Font("Arial", 14, FontStyle.Bold);
            PointF pointF = new PointF((int)position.X, (int)position.Y);

            RenderVelocity(graphic, position, _steeringBehavior.GetEntityVelocity());
            graphic.DrawString(Calculate().ToString(), font, brush, pointF);
        }
    }
}
