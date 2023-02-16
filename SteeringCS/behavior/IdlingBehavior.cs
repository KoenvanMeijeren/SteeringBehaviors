using SteeringCS.entity;
using SteeringCS.util;
using System;

namespace SteeringCS.behavior
{
    public class IdlingBehavior : SteeringBehavior
    {
        public IdlingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D vector = new Vector2D(0, 0);
            return vector;
        }
    }
}
