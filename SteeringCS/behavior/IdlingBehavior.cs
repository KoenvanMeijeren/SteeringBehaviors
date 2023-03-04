using SteeringCS.entity;
using Src.util;
using System;

namespace SteeringCS.behavior
{
    public class IdlingBehavior : SteeringBehavior
    {
        public IdlingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            Vector vector = new Vector(0, 0);
            return vector;
        }
    }
}
