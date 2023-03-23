using Src.entity;
using Src.util;

namespace Src.behavior
{
    public abstract class SteeringBehavior : ISteeringBehavior
    {
        private readonly bool _shouldAvoidObstacles;
        protected IMovingEntity MovingEntity { get; }
        public abstract Vector Calculate();

        protected SteeringBehavior(IMovingEntity movingEntity, bool shouldAvoidObstacles = false)
        {
            MovingEntity = movingEntity;
            _shouldAvoidObstacles = shouldAvoidObstacles;
        }

        public Vector GetEntityPosition()
        {
            return MovingEntity.Position;
        }

        public Vector GetEntityVelocity()
        {
            return MovingEntity.Velocity;
        }

        public bool ShouldAvoidObstacles()
        {
            return _shouldAvoidObstacles;
        }
    }
}
