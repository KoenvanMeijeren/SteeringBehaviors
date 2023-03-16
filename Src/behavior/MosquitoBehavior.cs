﻿using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class MosquitoBehavior : SteeringBehavior
    {
        public MosquitoBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate() => new Vector(Randomizer.GetRandomNumber(-1000, 1000), Randomizer.GetRandomNumber(-1000, 1000));
    }
}
