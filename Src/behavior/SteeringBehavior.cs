using Src.entity;
using Src.util;

namespace Src.behavior
{
    public abstract class SteeringBehavior : ISteeringBehavior
    {
        protected IMovingEntity MovingEntity { get; }
        public abstract VectorImmutable Calculate();

        protected SteeringBehavior(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public VectorImmutable GetEntityPosition()
        {
            return MovingEntity.Position;
        }

        public VectorImmutable GetEntityVelocity()
        {
            return MovingEntity.Velocity;
        }
    }
}
