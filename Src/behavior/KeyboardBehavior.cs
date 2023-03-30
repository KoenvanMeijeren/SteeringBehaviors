using Visualization.entity;
using Visualization.util;

namespace Visualization.behavior
{
    public class KeyboardBehavior : SteeringBehavior
    {
        public KeyboardBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate() => KeyHandler.GetKeysDirection();
    }
}
