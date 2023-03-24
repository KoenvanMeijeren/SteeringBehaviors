using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        private const int MinimalDistanceForObstacleAvoiding = 15;
        public ArrivingBehavior(IMovingEntity movingEntity, bool shouldAvoidObstacles = true) : base(movingEntity, shouldAvoidObstacles)
        {
        }

        public override bool ShouldAvoidObstacles()
        {
            double distanceBetween = MovingEntity.Position.DistanceBetween(MovingEntity.World.Player.Position);
            return distanceBetween > MinimalDistanceForObstacleAvoiding;
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
