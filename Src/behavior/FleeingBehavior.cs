using Visualization.entity;
using Visualization.util;

namespace Visualization.behavior
{
    public class FleeingBehavior : SteeringBehavior
    {
        private const int MinimalDistanceForObstacleAvoiding = 15;
        public FleeingBehavior(IMovingEntity movingEntity, bool shouldAvoidObstacles = true) : base(movingEntity, shouldAvoidObstacles)
        {
        }

        public override bool ShouldAvoidObstacles()
        {
            double distanceBetween = MovingEntity.Position.DistanceBetween(MovingEntity.World.Player.Position);
            return distanceBetween > MinimalDistanceForObstacleAvoiding;
        }

        public override Vector Calculate()
        {
            Vector targetPosition = MovingEntity.World.Player.Position;
            Vector myPosition = MovingEntity.Position;

            Vector desiredVelocity = myPosition - targetPosition;
            Vector actualVelocity = desiredVelocity - MovingEntity.Velocity;

            return actualVelocity;
        }
    }
}
