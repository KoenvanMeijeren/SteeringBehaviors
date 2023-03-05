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
        WanderingBehavior
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
    }
}
