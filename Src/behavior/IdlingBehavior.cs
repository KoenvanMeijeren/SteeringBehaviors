using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class IdlingBehavior : SteeringBehavior
    {
        public IdlingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate() => new Vector(0, 0);
    }
}
