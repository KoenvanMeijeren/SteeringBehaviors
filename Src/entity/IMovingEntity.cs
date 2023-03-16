﻿using Src.behavior;
using Src.util;

namespace Src.entity
{
    public interface IMovingEntity : IGameEntity
    {
        VectorImmutable Velocity { get; set; }
        float Mass { get; set; }
        float MaxSpeed { get; set; }
        void SetSteeringBehavior(ISteeringBehavior steeringBehavior);
    }
}
