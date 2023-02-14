using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behaviour
{
    public enum SteeringBehaviorOptions
    {
        IdleBehavior,
        SeekingBehavior,
        FleeingBehavior
    }

    public abstract class SteeringBehavior
    {
        protected MovingEntity MovingEntity { get; }
        public abstract Vector2D Calculate();

        protected SteeringBehavior(MovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }
    }
}
