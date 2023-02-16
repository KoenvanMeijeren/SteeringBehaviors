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
            return Calculate(MovingEntity, MovingEntity.World.Target.Position);
        }
        
        public static Vector2D Calculate(MovingEntity movingEntity, Vector2D targetPosition)
        {
            var desiredVelocity = targetPosition.Clone().Subtract(movingEntity.Position);
            var actualVelocity = desiredVelocity.Subtract(movingEntity.Velocity);

            return actualVelocity;
        }
    }
}
