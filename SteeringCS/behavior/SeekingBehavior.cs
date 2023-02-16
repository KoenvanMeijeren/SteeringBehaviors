using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behavior
{
    public class SeekingBehavior : SteeringBehavior
    {
        public SeekingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            var targetPosition = MovingEntity.World.Target.Position.Clone();
            var desiredVelocity = targetPosition.Subtract(MovingEntity.Position);

            if (desiredVelocity.Length() > 200)
            {
                return desiredVelocity;
            }

            var actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);
            return actualVelocity;
        }
    }
}
