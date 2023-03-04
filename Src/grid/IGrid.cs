using Src.entity;
using Src.util;

namespace Src.grid
{
    public interface IGrid
    {
        void MoveEntityIfInDifferentTile(Vector oldPos, Vector newPos, IMovingEntity entity);
        void AlterVectorToStayOutOfWalls(Vector position, Vector vector);
    }
}
