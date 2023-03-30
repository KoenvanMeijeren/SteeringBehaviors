using Visualization.entity;
using Visualization.grid;

namespace Visualization.world
{
    public interface IWorld
    {
        IPlayer Player { get; }
        IRescuee Rescuee { get; }
        IGrid Grid { get; }

        int Width { get; }
        int Height { get; }
    }
}
