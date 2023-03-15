using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            return Calculate(MovingEntity, MovingEntity.World.Target.Position);
        }

        public static Vector Calculate(IMovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition.Clone().Subtract(movingEntity.Position);
            Vector actualVelocity = desiredVelocity.Subtract(movingEntity.Velocity);

            return actualVelocity;
        }

        public override VectorImmutable CalculateImmutable()
        {
            return CalculateImmutable(MovingEntity, MovingEntity.World.Target.PositionImmutable);
        }

        public static VectorImmutable CalculateImmutable(IMovingEntity movingEntity, VectorImmutable targetPosition)
        {
            VectorImmutable desiredVelocity = targetPosition - movingEntity.PositionImmutable;
            VectorImmutable actualVelocity = desiredVelocity - movingEntity.VelocityImmutable;

            return actualVelocity;
        }
    }
}
