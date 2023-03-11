using Src.entity;
using Src.graph;
using Src.util;

namespace Src.grid
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        int TileSize { get; }
        GridTile[,] Tiles { get; }
        Graph Graph { get; }

        void MoveEntityIfInDifferentTile(Vector oldPos, Vector newPos, IMovingEntity entity);
        int GetCoordinateOfTile(int length);
        GridTile GetTile(int x, int y);
    }
}
