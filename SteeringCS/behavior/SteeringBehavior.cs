using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behavior
{
    public enum SteeringBehaviorOptions
    {
        IdlingBehavior,
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
