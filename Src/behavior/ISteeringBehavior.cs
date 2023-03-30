using Visualization.util;

namespace Visualization.behavior
{
    public interface ISteeringBehavior
    {
        Vector Calculate();

        bool ShouldAvoidObstacles();
    }
}
