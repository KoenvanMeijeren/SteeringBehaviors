using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class FleeingBehavior : SteeringBehavior
    {
        public FleeingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override VectorImmutable Calculate()
        {
            VectorImmutable targetPosition = MovingEntity.World.Target.Position;
            VectorImmutable myPosition = MovingEntity.Position;

            VectorImmutable desiredVelocity = myPosition - targetPosition;
            VectorImmutable actualVelocity = desiredVelocity - MovingEntity.Velocity;

            return actualVelocity;
        }
    }
}
