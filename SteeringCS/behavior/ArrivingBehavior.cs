using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            return new Vector2D();
        }

        public static Vector2D Calculate(MovingEntity movingEntity, Vector2D targetPosition)
        {
            Vector2D desiredVelocity = targetPosition.Clone().Subtract(movingEntity.Position);
            Vector2D actualVelocity = desiredVelocity.Subtract(movingEntity.Velocity);

            return actualVelocity;
        }
    }
}
