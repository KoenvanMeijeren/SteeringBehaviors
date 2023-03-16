using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override VectorImmutable Calculate()
        {
            return Calculate(MovingEntity, MovingEntity.World.Target.Position);
        }

        public static VectorImmutable Calculate(IMovingEntity movingEntity, VectorImmutable targetPosition)
        {
            VectorImmutable desiredVelocity = targetPosition - movingEntity.Position;
            VectorImmutable actualVelocity = desiredVelocity - movingEntity.Velocity;

            return actualVelocity;
        }
    }
}
