using SteeringCS.entity;
using SteeringCS.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behavior
{
    internal class MosquitoBehavior : SteeringBehavior
    {
        public MosquitoBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector2D Calculate()
        {
            return new Vector2D(Randomizer.Next(-1000, 1000), Randomizer.Next(-1000, 1000));
        }
    }
}
