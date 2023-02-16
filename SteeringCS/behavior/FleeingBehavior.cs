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
            var targetPosition = MovingEntity.World.Target.Position.Clone();
            var myPosition = MovingEntity.Position.Clone();

            var desiredVelocity = myPosition.Subtract(targetPosition);
            var actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);

            return actualVelocity;
        }
    }
}
