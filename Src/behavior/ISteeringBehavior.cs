﻿using Src.util;

namespace Src.behavior
{
    public interface ISteeringBehavior
    {
        Vector Calculate();

        bool ShouldAvoidObstacles();
    }
}
