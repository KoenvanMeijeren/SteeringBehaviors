using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class SeekingBehavior : SteeringBehavior
    {
        private const int ArrivalRange = 200;
        public SeekingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override VectorImmutable Calculate()
        {
            return Calculate(MovingEntity, MovingEntity.World.Target.Position);
        }

        private static VectorImmutable Calculate(IMovingEntity movingEntity, VectorImmutable targetPosition)
        {
            VectorImmutable desiredVelocity = targetPosition - movingEntity.Position;

            if (desiredVelocity.Length > ArrivalRange)
            {
                return desiredVelocity;
            }

            VectorImmutable actualVelocity = desiredVelocity - movingEntity.Velocity;
            return actualVelocity;
        }
    }
}
