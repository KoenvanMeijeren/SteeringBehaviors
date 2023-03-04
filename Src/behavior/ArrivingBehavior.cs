﻿using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class ArrivingBehavior : SteeringBehavior
    {
        public ArrivingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            return new Vector(0, 0);
        }

        public static Vector Calculate(IMovingEntity movingEntity, Vector targetPosition)
        {
            Vector desiredVelocity = targetPosition.Clone().Subtract(movingEntity.Position);
            Vector actualVelocity = desiredVelocity.Subtract(movingEntity.Velocity);

            return actualVelocity;
        }
    }
}