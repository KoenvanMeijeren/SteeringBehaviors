using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            return Calculate(MovingEntity, MovingEntity.World.Target.Position);
        }

        public static Vector Calculate(IMovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition - movingEntity.Position;
            Vector actualVelocity = desiredVelocity - movingEntity.Velocity;

            return actualVelocity;
        }

        public override bool ShouldAvoidObstacles()
        {
            return true;
        }
    }
}
