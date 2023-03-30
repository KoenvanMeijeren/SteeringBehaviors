using Visualization.entity;
using Visualization.util;

namespace Visualization.behavior
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

        public virtual bool ShouldAvoidObstacles()
        {
            return _shouldAvoidObstacles;
        }
    }
}
