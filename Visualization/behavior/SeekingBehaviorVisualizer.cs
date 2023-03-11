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
            RenderVelocity(graphic, SteeringBehavior.GetEntityPosition(), SteeringBehavior.GetEntityTargetPosition());
        }
    }
}
