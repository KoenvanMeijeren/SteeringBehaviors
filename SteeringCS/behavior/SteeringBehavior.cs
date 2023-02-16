using SteeringCS.entity;
using SteeringCS.util;
using System;

namespace SteeringCS.behavior
{
    public enum SteeringBehaviorOptions
    {
        IdlingBehavior,
        SeekingBehavior,
        FleeingBehavior,
        MosquitoBehavior
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
