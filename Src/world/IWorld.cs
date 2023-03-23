using Src.entity;
using Src.grid;

namespace Src.world
{
    public interface IWorld
    {
        IPlayer Player { get; }
        IRescue Rescue { get; }
        IGrid Grid { get; }

        int Width { get; }
        int Height { get; }
    }
}
