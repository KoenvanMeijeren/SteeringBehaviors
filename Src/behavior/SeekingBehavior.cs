using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class SeekingBehavior : SteeringBehavior
    {
        private const int ArrivalRange = 200, MinimalDistanceForObstacleAvoiding = 15;
        public SeekingBehavior(IMovingEntity movingEntity, bool shouldAvoidObstacles = true) : base(movingEntity, shouldAvoidObstacles)
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

        private static Vector Calculate(IMovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition - movingEntity.Position;

            if (desiredVelocity.Length > ArrivalRange)
            {
                return desiredVelocity;
            }

            Vector actualVelocity = desiredVelocity - movingEntity.Velocity;
            return actualVelocity * 2;
        }
    }
}
