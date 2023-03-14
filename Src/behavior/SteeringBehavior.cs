using System;
using Src.entity;
using Src.util;

namespace Src.behavior
{
    public enum SteeringBehaviorOptions
    {
        IdlingBehavior,
        SeekingBehavior,
        FleeingBehavior,
        MosquitoBehavior,
        WanderingBehavior,
        PathfindingBehavior
    }

    public abstract class SteeringBehavior : ISteeringBehavior
    {
        protected IMovingEntity MovingEntity { get; }
        public abstract Vector Calculate();

        protected SteeringBehavior(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public Vector GetEntityPosition()
        {
            return MovingEntity.Position;
        }

        public Vector GetEntityTargetPosition()
        {
            return MovingEntity.Position.Clone().Add(MovingEntity.Velocity);
        }
    }
}
