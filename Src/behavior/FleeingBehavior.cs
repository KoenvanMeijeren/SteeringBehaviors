using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class FleeingBehavior : SteeringBehavior
    {
        public FleeingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            Vector targetPosition = MovingEntity.World.Target.Position;
            Vector myPosition = MovingEntity.Position;

            Vector desiredVelocity = myPosition - targetPosition;
            Vector actualVelocity = desiredVelocity - MovingEntity.Velocity;

            return actualVelocity;
        }
        
        public override bool ShouldAvoidObstacles()
        {
            return true;
        }
    }
}
