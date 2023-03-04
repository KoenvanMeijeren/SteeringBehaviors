using SteeringCS.entity;
using Src.util;
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

        public override Vector Calculate()
        {
            Vector targetPosition = MovingEntity.World.Target.Position.Clone();
            Vector myPosition = MovingEntity.Position.Clone();

            Vector desiredVelocity = myPosition.Subtract(targetPosition);
            Vector actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);

            return actualVelocity;
        }
    }
}
