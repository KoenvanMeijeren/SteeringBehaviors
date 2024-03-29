﻿using System.Drawing;
using Src.behavior;

namespace SteeringCS.behavior
{
    public interface ISteeringBehaviorVisualizer : ISteeringBehavior
    {
        /// <summary>
        /// Used for displaying debug-information on every moving entity.
        /// </summary>
        void Render(Graphics graphic);
        void RenderVelocity(Graphics graphic);
    }
}
