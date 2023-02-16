using System;
using System.Drawing;
using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behavior
{
    public enum SteeringBehaviorOptions
    {
        IdlingBehavior,
        SeekingBehavior,
        FleeingBehavior,
        WanderingBehavior
    }

    public abstract class SteeringBehavior
    {
        protected readonly Random Randomizer = new Random();
        protected MovingEntity MovingEntity { get; }
        public abstract Vector2D Calculate();

        protected SteeringBehavior(MovingEntity movingEntity)
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

        /// <summary>
        /// Used for displaying debug-information on every moving entity.
        /// </summary>
        public virtual void Render(Graphics graphic)
        {
            
        }
    }
}
