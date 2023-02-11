using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behaviour
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity movingEntity) : base(movingEntity)
        {
        }
        
        public override Vector2D Calculate()
        {
            var targetPosition = MovingEntity.World.Target.Position.Clone();
            var desiredVelocity = targetPosition.Subtract(MovingEntity.Position);
            var actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);

            return actualVelocity;
        }
    }
}
