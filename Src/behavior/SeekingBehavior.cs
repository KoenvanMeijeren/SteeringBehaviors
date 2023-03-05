using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class SeekingBehavior : SteeringBehavior
    {
        private const int ArrivalRange = 200;
        public SeekingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            Vector targetPosition = MovingEntity.World.Target.Position.Clone();
            Vector desiredVelocity = targetPosition.Subtract(MovingEntity.Position);

            if (desiredVelocity.Length() > ArrivalRange)
            {
                return desiredVelocity;
            }

            Vector actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);
            return actualVelocity;
        }
    }
}
