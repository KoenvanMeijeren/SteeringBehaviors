using Visualization.entity;
using Visualization.graph;

namespace Visualization.grid
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
        void AddOrMoveEntity(IMovingEntity entity);
    }
}
