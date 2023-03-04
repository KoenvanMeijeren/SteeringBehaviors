using System.Drawing;
using Src.util;

namespace SteeringCS.behavior
{
    public interface ISteeringBehaviorVisualizer
    {
        Vector Calculate();
        
        /// <summary>
        /// Used for displaying debug-information on every moving entity.
        /// </summary>
        void Render(Graphics graphic);
    }
}
