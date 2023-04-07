using System.Collections.Generic;
using Src.entity;
using Src.grid;
using Src.util;
using System.Collections.Generic;

namespace Src.world
{
    public interface IWorld
    {
        IPlayer Player { get; }
        IRescuee Rescuee { get; }
        List<IEnemy> Enemies { get; }
        IGrid Grid { get; }
        List<IEnemy> Enemies { get; }
        int Width { get; }
        int Height { get; }
        Vector Center { get; }
    }
}
