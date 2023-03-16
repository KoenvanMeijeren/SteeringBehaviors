using Src.behavior;
using Src.entity;
using Src.util;
using System.Drawing;

namespace SteeringCS.behavior
{
    public class KeyboardBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly KeyboardBehavior _steeringBehavior;
        public KeyboardBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new KeyboardBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, _steeringBehavior.GetEntityPosition(), _steeringBehavior.GetEntityVelocity());
        }
    }
}
