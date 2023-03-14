using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class SeekingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public SeekingBehavior SteeringBehavior { get; private set; }

        public SeekingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new SeekingBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return SteeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            Vector position = SteeringBehavior.GetEntityPosition();
            SolidBrush brush = new SolidBrush(Color.Red);
            Font font = new Font("Arial", 14, FontStyle.Bold);
            PointF pointF = new PointF((int)position.X, (int)position.Y);
            
            RenderVelocity(graphic, position, SteeringBehavior.GetEntityTargetPosition());
            graphic.DrawString(Calculate().ToString(), font, brush, pointF);
        }
    }
}
