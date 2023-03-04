using Src.entity;
using Src.grid;

namespace Src.world
{
    public interface IWorld
    {
        IMovingEntity Target { get; }
        IGrid Grid { get; }

        int Width { get; }
        int Height { get; }
    }
}
