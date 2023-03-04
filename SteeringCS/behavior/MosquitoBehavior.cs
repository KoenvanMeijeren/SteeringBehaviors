using SteeringCS.entity;
using Src.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behavior
{
    public class MosquitoBehavior : SteeringBehavior
    {
        public MosquitoBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            return new Vector(Randomizer.Next(-1000, 1000), Randomizer.Next(-1000, 1000));
        }
    }
}
