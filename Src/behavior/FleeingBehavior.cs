using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class FleeingBehavior : SteeringBehavior
    {
        public FleeingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            Vector targetPosition = MovingEntity.World.Target.Position.Clone();
            Vector myPosition = MovingEntity.Position.Clone();

            Vector desiredVelocity = myPosition.Subtract(targetPosition);
            Vector actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);

            return actualVelocity;
        }

        public override VectorImmutable CalculateImmutable()
        {
            VectorImmutable targetPosition = MovingEntity.World.Target.PositionImmutable;
            VectorImmutable myPosition = MovingEntity.PositionImmutable;

            VectorImmutable desiredVelocity = myPosition - targetPosition;
            VectorImmutable actualVelocity = desiredVelocity - MovingEntity.VelocityImmutable;

            return actualVelocity;
        }
    }
}
