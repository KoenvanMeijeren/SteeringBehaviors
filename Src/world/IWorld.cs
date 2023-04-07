using System.Collections.Generic;
using Src.entity;
using Src.grid;
using Src.util;

namespace Src.world
{
    public interface IWorld
    {
        IPlayer Player { get; }
        IRescuee Rescuee { get; }
        List<IEnemy> Enemies { get; }
        IGrid Grid { get; }
        int Width { get; }
        int Height { get; }
        Vector Center { get; }
    }
}
