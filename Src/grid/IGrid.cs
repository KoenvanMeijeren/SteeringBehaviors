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
        GridTile GetTile(int row, int column);
        PathTile GetRandomPathTile();
        void AddOrMoveEntity(IMovingEntity entity);
        void RemoveEntity(IMovingEntity entity);
    }
}
