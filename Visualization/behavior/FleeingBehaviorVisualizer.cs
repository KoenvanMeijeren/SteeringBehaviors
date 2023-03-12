using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class FleeingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public FleeingBehavior SteeringBehavior { get; private set; }

        public FleeingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new FleeingBehavior(movingEntity);
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
