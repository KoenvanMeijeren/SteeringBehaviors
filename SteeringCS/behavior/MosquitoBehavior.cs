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
            var randomizer = new Random();
            var vector = new Vector2D(randomizer.Next(-1000, 1000), randomizer.Next(-1000, 1000));
            return vector;
        }
    }
}
