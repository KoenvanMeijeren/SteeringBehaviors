using Src.entity;
using Src.util;

namespace Src.behavior
{
    public abstract class SteeringBehavior : ISteeringBehavior
    {
        protected IMovingEntity MovingEntity { get; }
        public abstract Vector Calculate();
        public abstract VectorImmutable CalculateImmutable();

        protected SteeringBehavior(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public Vector GetEntityPosition()
        {
            return MovingEntity.Position;
        }

        public Vector GetEntityVelocity()
        {
            return MovingEntity.Velocity;
        }
    }
}
