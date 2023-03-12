using Src.behavior;
using Src.entity;
using Src.util;
using System.Drawing;

namespace SteeringCS.behavior
{
    public class KeyboardBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public KeyboardBehavior SteeringBehavior { get; private set; }
        public KeyboardBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new KeyboardBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return SteeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, SteeringBehavior.GetEntityPosition(), SteeringBehavior.GetEntityVelocity());
        }
    }
}
