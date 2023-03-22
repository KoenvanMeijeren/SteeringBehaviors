﻿using Src.entity;
using Src.util;

namespace Src.behavior
{
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

        public Vector GetEntityVelocity()
        {
            return MovingEntity.Velocity;
        }

        public virtual bool ShouldAvoidObstacles()
        {
            return false;
        }
    }
}
