using SteeringCS.entity;
using SteeringCS.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    internal class IdlingBehavior : SteeringBehavior
    {
        public IdlingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            var rnd = new Random();
            var vector = new Vector2D(rnd.Next(-1000, 1000), rnd.Next(-1000, 1000));
            return vector;
        }
    }
}
