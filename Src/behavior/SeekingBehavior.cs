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

        public override Vector Calculate()
        {
            return Calculate(MovingEntity, MovingEntity.World.Target.Position.Clone());
        }

        private static Vector Calculate(IMovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition.Subtract(movingEntity.Position);

            if (desiredVelocity.Length() > ArrivalRange)
            {
                return desiredVelocity;
            }

            Vector actualVelocity = desiredVelocity.Subtract(movingEntity.Velocity);
            return actualVelocity;
        }

        public override VectorImmutable CalculateImmutable()
        {
            return CalculateImmutable(MovingEntity, MovingEntity.World.Target.PositionImmutable);
        }

        private static VectorImmutable CalculateImmutable(IMovingEntity movingEntity, VectorImmutable targetPosition)
        {
            VectorImmutable desiredVelocity = targetPosition - movingEntity.PositionImmutable;

            if (desiredVelocity.Length > ArrivalRange)
            {
                return desiredVelocity;
            }

            VectorImmutable actualVelocity = desiredVelocity - movingEntity.VelocityImmutable;
            return actualVelocity;
        }
    }
}
