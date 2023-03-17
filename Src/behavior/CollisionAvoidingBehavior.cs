using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class CollisionAvoidingBehavior : SteeringBehavior
    {
        public Vector AheadPosition { get; private set; }
        private const int MaxSeeAhead = 50;

        public CollisionAvoidingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            Vector currentPosition = MovingEntity.Position;
            Vector currentVelocity = MovingEntity.Velocity;
            AheadPosition = currentPosition + (currentVelocity.Normalize() * MaxSeeAhead);

            return new Vector(0, 0);
        }
    }
}
