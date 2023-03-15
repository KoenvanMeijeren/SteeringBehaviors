using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class ArrivingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public ArrivingBehavior SteeringBehavior { get; private set; }

        public ArrivingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new ArrivingBehavior(movingEntity);
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
