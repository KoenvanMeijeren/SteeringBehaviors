using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class KeyboardBehavior : SteeringBehavior
    {
        public KeyboardBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override VectorImmutable Calculate() => KeyHandler.GetKeysDirection();
    }
}
