using System;
using Src.entity;
using Src.util;

namespace Src.behavior
{
    public enum SteeringBehaviorOptions
    {
        ArrivingBehavior,
        IdlingBehavior,
        SeekingBehavior,
        FleeingBehavior,
        MosquitoBehavior,
        WanderingBehavior,
        PathfindingBehavior,
        NotImplementedBehavior
    }

    public abstract class SteeringBehavior : ISteeringBehavior
    {
        protected readonly Random Randomizer = new Random();
        protected IMovingEntity MovingEntity { get; }
        public abstract Vector Calculate();

        protected SteeringBehavior(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        protected int RandomClamped()
        {
            return Randomizer.NextDouble() >= 0.5 ? -1 : 1;
        }

        protected double GetRandomNumber(double minimum, double maximum)
        {
            return Randomizer.NextDouble() * (maximum - minimum) + minimum;
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
