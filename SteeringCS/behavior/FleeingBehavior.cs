using SteeringCS.entity;
using SteeringCS.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behavior
{
    internal class FleeingBehavior : SteeringBehavior
    {
        public FleeingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D targetPosition = MovingEntity.World.Target.Position.Clone();
            Vector2D myPosition = MovingEntity.Position.Clone();

            Vector2D desiredVelocity = myPosition.Subtract(targetPosition);
            Vector2D actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);

            return actualVelocity;
        }
    }
}
