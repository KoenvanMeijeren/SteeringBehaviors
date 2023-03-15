using Src.entity;
using Src.graph;

namespace Src.grid
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        int TileSize { get; }
        GridTile[,] Tiles { get; }
        Graph Graph { get; }

        int GetCoordinateOfTile(int length);
        GridTile GetTile(int x, int y);
        void AddOrMoveEntity(IMovingEntity entity);
    }
}
