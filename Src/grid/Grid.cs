using System.Collections.Generic;
using System.Data.Common;
using Src.entity;
using Src.graph;
using Src.util;

namespace Src.grid
{
    public class Grid : IGrid
    {
        public int Width { get; }
        public int Height { get; }
        public int TileSize => 32;
        public GridTile[,] Tiles { get; private set; }
        public Graph Graph { get; private set; }
        private readonly Dictionary<IMovingEntity, PathTile> _entities;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            _entities = new Dictionary<IMovingEntity, PathTile>();

            InitializeGridTilesArray();
            InitializeOutsideWallTiles();
            InitializeFinishTiles();
            InitializeTwirlMazeWallTiles();
            InitializePathTiles();
            InitializeGraph();
        }

        private void InitializeGridTilesArray()
        {
            int rowTilesCount = GetCoordinateOfTile(Width) + 1;
            int columnTilesCount = GetCoordinateOfTile(Height) + 1;

            Tiles = new GridTile[rowTilesCount, columnTilesCount];
        }
        private void InitializeOutsideWallTiles()
        {
            int maximumRowLength = Tiles.GetLength(0);
            int maximumColumnLenght = Tiles.GetLength(1);

            for (int row = 0; row < maximumRowLength; row++)
            {
                Tiles[row, 0] = new WallTile(TileSize, row * TileSize, 0);
                Tiles[row, maximumColumnLenght - 1] = new WallTile(TileSize, row * TileSize, (maximumColumnLenght - 1) * TileSize);
            }

            for (int column = 1; column < maximumColumnLenght - 1; column++)
            {
                Tiles[0, column] = new WallTile(TileSize, 0 * TileSize, column * TileSize);
                Tiles[maximumRowLength - 1, column] = new WallTile(TileSize, (maximumRowLength - 1) * TileSize, column * TileSize);
            }
        }

        private void InitializeFinishTiles()
        {
            int centerTileX = (Width / 2)/TileSize;
            int centerTileY = (Height / 2)/TileSize;

            Tiles[centerTileX, centerTileY] = new PathTile(TileSize, centerTileX * TileSize, centerTileY * TileSize, true);
            Tiles[centerTileX - 1, centerTileY] = new PathTile(TileSize, (centerTileX - 1) * TileSize, centerTileY * TileSize, true);
            Tiles[centerTileX, centerTileY - 1] = new PathTile(TileSize, centerTileX * TileSize, (centerTileY - 1) * TileSize, true);
            Tiles[centerTileX - 1, centerTileY - 1] = new PathTile(TileSize, (centerTileX - 1) * TileSize, (centerTileY - 1) * TileSize, true);
        }

        private void InitializeTwirlMazeWallTiles()
        {

        }

        private void InitializePathTiles()
        {
            for (int row = 0; row < Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < Tiles.GetLength(1); column++)
                {
                    if (Tiles[row, column] == null)
                    {
                        Tiles[row, column] = new PathTile(TileSize, row * TileSize, column * TileSize);
                    }
                }
            }
        }

        private void InitializeGraph()
        {
            Vertex[,] vertices = new Vertex[Tiles.GetLength(0), Tiles.GetLength(1)];

            for (int row = 0; row < Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < Tiles.GetLength(1); column++)
                {
                    if (Tiles[row, column] is PathTile pathTile)
                    {
                        vertices[row, column] = pathTile.Vertex;
                    }
                }
            }

            Graph = new Graph(vertices);
        }

        public int GetCoordinateOfTile(int length)
        {
            return (length - 1) / TileSize;
        }

        public GridTile GetTile(int row, int column)
        {
            return IsPositionWithInBounds(row, column, Tiles) ? Tiles[row, column] : null;
        }

        public PathTile GetRandomPathTile()
        {
            List<PathTile> pathTiles = new List<PathTile>();

            foreach (GridTile tile in Tiles)
            {
                if (tile is PathTile pathTile && !pathTile.IsFinish)
                {
                    pathTiles.Add(pathTile);
                }
            }

            if (pathTiles.Count == 0)
            {
                return null;
            }

            int randomIndex = Randomizer.GetRandomNumber(0, pathTiles.Count);
            return pathTiles[randomIndex];
        }

        public void AddOrMoveEntity(IMovingEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            Vector position = entity.Position;
            int tileRow = GetCoordinateOfTile((int)position.X);
            int tileColumn = GetCoordinateOfTile((int)position.Y);

            GridTile gridTile = GetTile(tileRow, tileColumn);
            if (!(gridTile is PathTile newPathTile))
            {
                return;
            }

            if (!_entities.ContainsKey(entity))
            {
                newPathTile.AddEntity(entity);
                _entities.Add(entity, newPathTile);
                return;
            }

            PathTile currentPathTile = _entities[entity];
            if (newPathTile == currentPathTile)
            {
                return;
            }

            currentPathTile.RemoveEntity(entity);
            newPathTile.AddEntity(entity);
            _entities[entity] = newPathTile;
        }

        private static bool IsPositionWithInBounds(int row, int column, GridTile[,] tiles)
        {
            if (row < 0 || row >= tiles.GetLength(0))
            {
                return false;
            }

            return column >= 0 && column < tiles.GetLength(1);
        }
    }
}
