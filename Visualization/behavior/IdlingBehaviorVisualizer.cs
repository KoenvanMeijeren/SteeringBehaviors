using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class IdlingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public IdlingBehavior SteeringBehavior { get; private set; }

        public IdlingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new IdlingBehavior(movingEntity);
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
