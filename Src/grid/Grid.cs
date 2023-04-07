using System.Collections.Generic;
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

        public Grid(int width, int height, bool initializeMazeTiles)
        {
            Width = width;
            Height = height;
            _entities = new Dictionary<IMovingEntity, PathTile>();

            InitializeGridTilesArray();
            InitializeOutsideWallTiles();
            if (initializeMazeTiles)
            {
                InitializeMazeTiles();
            }
            
            InitializeFinishTiles();
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

        private void InitializeMazeTiles()
        {
            Tiles[1, 14] = new WallTile(TileSize, 1 * TileSize, 14 * TileSize);

            Tiles[2, 2] = new WallTile(TileSize, 2 * TileSize, 2 * TileSize);
            Tiles[2, 3] = new WallTile(TileSize, 2 * TileSize, 3 * TileSize);
            Tiles[2, 4] = new WallTile(TileSize, 2 * TileSize, 4 * TileSize);
            Tiles[2, 5] = new WallTile(TileSize, 2 * TileSize, 5 * TileSize);
            Tiles[2, 6] = new WallTile(TileSize, 2 * TileSize, 6 * TileSize);
            Tiles[2, 8] = new WallTile(TileSize, 2 * TileSize, 8 * TileSize);
            Tiles[2, 9] = new WallTile(TileSize, 2 * TileSize, 9 * TileSize);
            Tiles[2, 10] = new WallTile(TileSize, 2 * TileSize, 10 * TileSize);
            Tiles[2, 11] = new WallTile(TileSize, 2 * TileSize, 11 * TileSize);
            Tiles[2, 12] = new WallTile(TileSize, 2 * TileSize, 12 * TileSize);
            Tiles[2, 14] = new WallTile(TileSize, 2 * TileSize, 14 * TileSize);
            Tiles[2, 16] = new WallTile(TileSize, 2 * TileSize, 16 * TileSize);
            Tiles[2, 18] = new WallTile(TileSize, 2 * TileSize, 18 * TileSize);

            Tiles[3, 14] = new WallTile(TileSize, 3 * TileSize, 14 * TileSize);
            Tiles[3, 16] = new WallTile(TileSize, 3 * TileSize, 16 * TileSize);

            Tiles[4, 2] = new WallTile(TileSize, 4 * TileSize, 2 * TileSize);
            Tiles[4, 3] = new WallTile(TileSize, 4 * TileSize, 3 * TileSize);
            Tiles[4, 4] = new WallTile(TileSize, 4 * TileSize, 4 * TileSize);
            Tiles[4, 5] = new WallTile(TileSize, 4 * TileSize, 5 * TileSize);
            Tiles[4, 6] = new WallTile(TileSize, 4 * TileSize, 6 * TileSize);
            Tiles[4, 7] = new WallTile(TileSize, 4 * TileSize, 7 * TileSize);
            Tiles[4, 8] = new WallTile(TileSize, 4 * TileSize, 8 * TileSize);
            Tiles[4, 9] = new WallTile(TileSize, 4 * TileSize, 9 * TileSize);
            Tiles[4, 10] = new WallTile(TileSize, 4 * TileSize, 10 * TileSize);
            Tiles[4, 11] = new WallTile(TileSize, 4 * TileSize, 11 * TileSize);
            Tiles[4, 12] = new WallTile(TileSize, 4 * TileSize, 12 * TileSize);
            Tiles[4, 14] = new WallTile(TileSize, 4 * TileSize, 14 * TileSize);
            Tiles[4, 16] = new WallTile(TileSize, 4 * TileSize, 16 * TileSize);
            Tiles[4, 17] = new WallTile(TileSize, 4 * TileSize, 17 * TileSize);

            Tiles[5, 2] = new WallTile(TileSize, 5 * TileSize, 2 * TileSize);
            Tiles[5, 12] = new WallTile(TileSize, 5 * TileSize, 12 * TileSize);
            Tiles[5, 14] = new WallTile(TileSize, 5 * TileSize, 14 * TileSize);
            Tiles[5, 16] = new WallTile(TileSize, 5 * TileSize, 16 * TileSize);

            Tiles[6, 2] = new WallTile(TileSize, 6 * TileSize, 2 * TileSize);
            Tiles[6, 4] = new WallTile(TileSize, 6 * TileSize, 4 * TileSize);
            Tiles[6, 6] = new WallTile(TileSize, 6 * TileSize, 6 * TileSize);
            Tiles[6, 7] = new WallTile(TileSize, 6 * TileSize, 7 * TileSize);
            Tiles[6, 8] = new WallTile(TileSize, 6 * TileSize, 8 * TileSize);
            Tiles[6, 9] = new WallTile(TileSize, 6 * TileSize, 9 * TileSize);
            Tiles[6, 10] = new WallTile(TileSize, 6 * TileSize, 10 * TileSize);
            Tiles[6, 12] = new WallTile(TileSize, 6 * TileSize, 12 * TileSize);
            Tiles[6, 14] = new WallTile(TileSize, 6 * TileSize, 14 * TileSize);
            Tiles[6, 18] = new WallTile(TileSize, 6 * TileSize, 18 * TileSize);

            Tiles[7, 2] = new WallTile(TileSize, 7 * TileSize, 2 * TileSize);
            Tiles[7, 4] = new WallTile(TileSize, 7 * TileSize, 4 * TileSize);
            Tiles[7, 12] = new WallTile(TileSize, 7 * TileSize, 12 * TileSize);
            Tiles[7, 14] = new WallTile(TileSize, 7 * TileSize, 14 * TileSize);
            Tiles[7, 16] = new WallTile(TileSize, 7 * TileSize, 16 * TileSize);

            Tiles[8, 2] = new WallTile(TileSize, 8 * TileSize, 2 * TileSize);
            Tiles[8, 4] = new WallTile(TileSize, 8 * TileSize, 4 * TileSize);
            Tiles[8, 6] = new WallTile(TileSize, 8 * TileSize, 6 * TileSize);
            Tiles[8, 8] = new WallTile(TileSize, 8 * TileSize, 8 * TileSize);
            Tiles[8, 9] = new WallTile(TileSize, 8 * TileSize, 9 * TileSize);
            Tiles[8, 10] = new WallTile(TileSize, 8 * TileSize, 10 * TileSize);
            Tiles[8, 11] = new WallTile(TileSize, 8 * TileSize, 11 * TileSize);
            Tiles[8, 12] = new WallTile(TileSize, 8 * TileSize, 12 * TileSize);
            Tiles[8, 14] = new WallTile(TileSize, 8 * TileSize, 14 * TileSize);
            Tiles[8, 16] = new WallTile(TileSize, 8 * TileSize, 16 * TileSize);
            Tiles[8, 17] = new WallTile(TileSize, 8 * TileSize, 17 * TileSize);

            Tiles[9, 2] = new WallTile(TileSize, 9 * TileSize, 2 * TileSize);
            Tiles[9, 4] = new WallTile(TileSize, 9 * TileSize, 4 * TileSize);
            Tiles[9, 6] = new WallTile(TileSize, 9 * TileSize, 6 * TileSize);
            Tiles[9, 8] = new WallTile(TileSize, 9 * TileSize, 8 * TileSize);
            Tiles[9, 11] = new WallTile(TileSize, 9 * TileSize, 11 * TileSize);
            Tiles[9, 16] = new WallTile(TileSize, 9 * TileSize, 16 * TileSize);

            Tiles[10, 2] = new WallTile(TileSize, 10 * TileSize, 2 * TileSize);
            Tiles[10, 6] = new WallTile(TileSize, 10 * TileSize, 6 * TileSize);
            Tiles[10, 8] = new WallTile(TileSize, 10 * TileSize, 8 * TileSize);
            Tiles[10, 11] = new WallTile(TileSize, 10 * TileSize, 11 * TileSize);
            Tiles[10, 13] = new WallTile(TileSize, 10 * TileSize, 13 * TileSize);
            Tiles[10, 14] = new WallTile(TileSize, 10 * TileSize, 14 * TileSize);
            Tiles[10, 16] = new WallTile(TileSize, 10 * TileSize, 16 * TileSize);

            Tiles[11, 2] = new WallTile(TileSize, 11 * TileSize, 2 * TileSize);
            Tiles[11, 4] = new WallTile(TileSize, 11 * TileSize, 4 * TileSize);
            Tiles[11, 5] = new WallTile(TileSize, 11 * TileSize, 5 * TileSize);
            Tiles[11, 6] = new WallTile(TileSize, 11 * TileSize, 6 * TileSize);
            Tiles[11, 8] = new WallTile(TileSize, 11 * TileSize, 8 * TileSize);
            Tiles[11, 10] = new WallTile(TileSize, 11 * TileSize, 10 * TileSize);
            Tiles[11, 11] = new WallTile(TileSize, 11 * TileSize, 11 * TileSize);
            Tiles[11, 13] = new WallTile(TileSize, 11 * TileSize, 13 * TileSize);
            Tiles[11, 14] = new WallTile(TileSize, 11 * TileSize, 14 * TileSize);
            Tiles[11, 16] = new WallTile(TileSize, 11 * TileSize, 16 * TileSize);
            Tiles[11, 17] = new WallTile(TileSize, 11 * TileSize, 17 * TileSize);

            Tiles[12, 4] = new WallTile(TileSize, 12 * TileSize, 4 * TileSize);
            Tiles[12, 10] = new WallTile(TileSize, 12 * TileSize, 10 * TileSize);
            Tiles[12, 16] = new WallTile(TileSize, 12 * TileSize, 16 * TileSize);

            Tiles[13, 2] = new WallTile(TileSize, 13 * TileSize, 2 * TileSize);
            Tiles[13, 4] = new WallTile(TileSize, 13 * TileSize, 4 * TileSize);
            Tiles[13, 6] = new WallTile(TileSize, 13 * TileSize, 6 * TileSize);
            Tiles[13, 7] = new WallTile(TileSize, 13 * TileSize, 7 * TileSize);
            Tiles[13, 8] = new WallTile(TileSize, 13 * TileSize, 8 * TileSize);
            Tiles[13, 10] = new WallTile(TileSize, 13 * TileSize, 10 * TileSize);
            Tiles[13, 12] = new WallTile(TileSize, 13 * TileSize, 12 * TileSize);
            Tiles[13, 14] = new WallTile(TileSize, 13 * TileSize, 14 * TileSize);
            Tiles[13, 16] = new WallTile(TileSize, 13 * TileSize, 16 * TileSize);
            Tiles[13, 18] = new WallTile(TileSize, 13 * TileSize, 18 * TileSize);

            Tiles[14, 2] = new WallTile(TileSize, 14 * TileSize, 2 * TileSize);
            Tiles[14, 4] = new WallTile(TileSize, 14 * TileSize, 4 * TileSize);
            Tiles[14, 10] = new WallTile(TileSize, 14 * TileSize, 10 * TileSize);
            Tiles[14, 12] = new WallTile(TileSize, 14 * TileSize, 12 * TileSize);
            Tiles[14, 14] = new WallTile(TileSize, 14 * TileSize, 14 * TileSize);

            Tiles[15, 2] = new WallTile(TileSize, 15 * TileSize, 2 * TileSize);
            Tiles[15, 4] = new WallTile(TileSize, 15 * TileSize, 4 * TileSize);
            Tiles[15, 5] = new WallTile(TileSize, 15 * TileSize, 5 * TileSize);
            Tiles[15, 6] = new WallTile(TileSize, 15 * TileSize, 6 * TileSize);
            Tiles[15, 7] = new WallTile(TileSize, 15 * TileSize, 7 * TileSize);
            Tiles[15, 8] = new WallTile(TileSize, 15 * TileSize, 8 * TileSize);
            Tiles[15, 9] = new WallTile(TileSize, 15 * TileSize, 9 * TileSize);
            Tiles[15, 10] = new WallTile(TileSize, 15 * TileSize, 10 * TileSize);
            Tiles[15, 12] = new WallTile(TileSize, 15 * TileSize, 12 * TileSize);
            Tiles[15, 14] = new WallTile(TileSize, 15 * TileSize, 14 * TileSize);
            Tiles[15, 16] = new WallTile(TileSize, 15 * TileSize, 16 * TileSize);
            Tiles[15, 17] = new WallTile(TileSize, 15 * TileSize, 17 * TileSize);

            Tiles[16, 2] = new WallTile(TileSize, 16 * TileSize, 2 * TileSize);
            Tiles[16, 12] = new WallTile(TileSize, 16 * TileSize, 12 * TileSize);
            Tiles[16, 14] = new WallTile(TileSize, 16 * TileSize, 14 * TileSize);
            Tiles[16, 16] = new WallTile(TileSize, 16 * TileSize, 16 * TileSize);

            Tiles[17, 2] = new WallTile(TileSize, 17 * TileSize, 2 * TileSize);
            Tiles[17, 4] = new WallTile(TileSize, 17 * TileSize, 4 * TileSize);
            Tiles[17, 5] = new WallTile(TileSize, 17 * TileSize, 5 * TileSize);
            Tiles[17, 6] = new WallTile(TileSize, 17 * TileSize, 6 * TileSize);
            Tiles[17, 7] = new WallTile(TileSize, 17 * TileSize, 7 * TileSize);
            Tiles[17, 8] = new WallTile(TileSize, 17 * TileSize, 8 * TileSize);
            Tiles[17, 9] = new WallTile(TileSize, 17 * TileSize, 9 * TileSize);
            Tiles[17, 10] = new WallTile(TileSize, 17 * TileSize, 10 * TileSize);
            Tiles[17, 12] = new WallTile(TileSize, 17 * TileSize, 12 * TileSize);
            Tiles[17, 14] = new WallTile(TileSize, 17 * TileSize, 14 * TileSize);
            Tiles[17, 16] = new WallTile(TileSize, 17 * TileSize, 16 * TileSize);
            Tiles[17, 18] = new WallTile(TileSize, 17 * TileSize, 18 * TileSize);

            Tiles[18, 14] = new WallTile(TileSize, 18 * TileSize, 14 * TileSize);
        }

        private void InitializeFinishTiles()
        {
            int centerTileX = (Width / 2) / TileSize;
            int centerTileY = (Height / 2) / TileSize;

            if (IsPositionWithInBounds(centerTileX, centerTileY, Tiles))
            {
                Tiles[centerTileX, centerTileY] = new PathTile(TileSize, centerTileX * TileSize, centerTileY * TileSize, true);
            }

            if (IsPositionWithInBounds(centerTileX - 1, centerTileY, Tiles))
            {
                Tiles[centerTileX - 1, centerTileY] = new PathTile(TileSize, (centerTileX - 1) * TileSize, centerTileY * TileSize, true);
            }

            if (IsPositionWithInBounds(centerTileX, centerTileY - 1, Tiles))
            {
                Tiles[centerTileX, centerTileY - 1] = new PathTile(TileSize, centerTileX * TileSize, (centerTileY - 1) * TileSize, true);
            }

            if (IsPositionWithInBounds(centerTileX - 1, centerTileY - 1, Tiles))
            {
                Tiles[centerTileX - 1, centerTileY - 1] = new PathTile(TileSize, (centerTileX - 1) * TileSize, (centerTileY - 1) * TileSize, true);
            }
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

        public void RemoveEntity(IMovingEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            PathTile currentPathTile = _entities[entity];
            currentPathTile.RemoveEntity(entity);
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
