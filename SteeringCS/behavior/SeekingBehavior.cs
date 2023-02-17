using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behavior
{
    public class SeekingBehavior : SteeringBehavior
    {
        private const int ArrivalRange = 200;
        public SeekingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D targetPosition = MovingEntity.World.Target.Position.Clone();
            Vector2D desiredVelocity = targetPosition.Subtract(MovingEntity.Position);

            if (desiredVelocity.Length() > ArrivalRange)
            {
                return desiredVelocity;
            }

            Vector2D actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);
            return actualVelocity;
        }
    }
}
