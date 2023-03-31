using System;
using SteeringCS.world;

namespace SteeringCS.events
{
    public class UpdateWorldEvent : EventArgs
    {
        public readonly WorldVisualization World;

        public UpdateWorldEvent(WorldVisualization world)
        {
            World = world;
        }
    }
}
