using SteeringCS.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            return new Vector(0, 0);
        }

        public static Vector Calculate(MovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition.Clone().Subtract(movingEntity.Position);
            Vector actualVelocity = desiredVelocity.Subtract(movingEntity.Velocity);

            return actualVelocity;
        }
    }
}
