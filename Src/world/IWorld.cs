using System.Collections.Generic;
using Src.entity;
using Src.grid;

namespace Src.world
{
    public interface IWorld
    {
        IPlayer Player { get; }
        IRescuee Rescuee { get; }
        IGrid Grid { get; }
        List<IEnemy> Enemies { get; }
        int Width { get; }
        int Height { get; }
    }
}
