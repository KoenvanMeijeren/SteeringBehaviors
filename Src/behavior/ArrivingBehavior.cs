using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(IMovingEntity movingEntity, bool shouldAvoidObstacles = true) : base(movingEntity, shouldAvoidObstacles)
        {
        }

        public override Vector Calculate()
        {
            return Calculate(MovingEntity, MovingEntity.World.Player.Position);
        }

        public static Vector Calculate(IMovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition - movingEntity.Position;
            Vector actualVelocity = desiredVelocity - movingEntity.Velocity;

            return actualVelocity;
        }
    }
}
