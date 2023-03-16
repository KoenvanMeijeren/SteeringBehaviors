using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class FleeingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly FleeingBehavior _steeringBehavior;

        public FleeingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new FleeingBehavior(movingEntity);
        }

        public override VectorImmutable Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, _steeringBehavior.GetEntityPosition(), _steeringBehavior.GetEntityVelocity());
        }
    }
}
