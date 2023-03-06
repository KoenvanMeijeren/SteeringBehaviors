using System.Drawing;
using Src.behavior;
using Src.util;

namespace SteeringCS.behavior
{
    public interface ISteeringBehaviorVisualizer : ISteeringBehavior
    {
        /// <summary>
        /// Used for displaying debug-information on every moving entity.
        /// </summary>
        void Render(Graphics graphic);
    }
}
