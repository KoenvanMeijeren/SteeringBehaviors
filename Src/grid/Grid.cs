using System;
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

        public Grid(int width, int height, List<IMovingEntity> entities)
        {
            Width = width;
            Height = height;
            InitializeGridTilesArray();
            InitializeOutsideWallTiles();
            InitializeMazeWallTiles();
            InitializePathTiles();
            InitializeGraph();
            AddEntities(entities);
        }

        private void InitializeGridTilesArray()
        {
            int amountOfTilesX = GetCoordinateOfTile(Width) + 1;
            int amountOfTilesY = GetCoordinateOfTile(Height) + 1;

            Tiles = new GridTile[amountOfTilesX, amountOfTilesY];
        }
        private void InitializeOutsideWallTiles()
        {
            int maxX = Tiles.GetLength(0);
            int maxY = Tiles.GetLength(1);

            for (int x = 0; x < maxX; x++)
            {
                Tiles[x, 0] = new WallTile(TileSize, x * TileSize, 0);
                Tiles[x, maxY - 1] = new WallTile(TileSize, x * TileSize, (maxY - 1) * TileSize);
            }

            for (int y = 1; y < maxY - 1; y++)
            {
                Tiles[0, y] = new WallTile(TileSize, 0 * TileSize, y * TileSize);
                Tiles[maxX - 1, y] = new WallTile(TileSize, (maxX - 1) * TileSize, y * TileSize);
            }
        }

        private void InitializeMazeWallTiles()
        {
            Random random = new Random();
            //TODO (It's random now)
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    int randomNumber = random.Next(1, 101);

                    if (randomNumber <= 20)
                    {
                        Tiles[x, y] = new WallTile(TileSize, x * TileSize, y * TileSize);
                    }
                }
            }

            /*            Tiles[5, 7] = new WallTile(TileSize, 5 * TileSize, 7 * TileSize);
                        Tiles[4, 7] = new WallTile(TileSize, 4 * TileSize, 7 * TileSize);
                        Tiles[5 ,8] = new WallTile(TileSize, 5 * TileSize, 8 * TileSize);
                        Tiles[4, 8] = new WallTile(TileSize, 4 * TileSize, 8 * TileSize);

                        Tiles[9, 8] = new WallTile(TileSize, 9 * TileSize, 8 * TileSize);
                        Tiles[10, 8] = new WallTile(TileSize, 10 * TileSize, 8 * TileSize);

                        Tiles[14, 7] = new WallTile(TileSize, 14 * TileSize, 7 * TileSize);
                        Tiles[15, 7] = new WallTile(TileSize, 15 * TileSize, 7 * TileSize);
                        Tiles[14, 8] = new WallTile(TileSize, 14 * TileSize, 8 * TileSize);
                        Tiles[15, 8] = new WallTile(TileSize, 15 * TileSize, 8 * TileSize);*/
        }

        private void InitializePathTiles()
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    if (Tiles[x, y] == null)
                    {
                        Tiles[x, y] = new PathTile(TileSize, x * TileSize, y * TileSize);
                    }
                }
            }
        }

        private void InitializeGraph()
        {
            Vertex[,] vertices = new Vertex[Tiles.GetLength(0), Tiles.GetLength(1)];

            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    if (Tiles[x, y] is PathTile pathTile)
                    {
                        vertices[x, y] = pathTile.Vertex;
                    }
                }
            }

            Graph = new Graph(vertices);
        }

        public int GetCoordinateOfTile(int length)
        {
            return (length - 1) / TileSize;
        }

        private void AddEntity(IMovingEntity entity, Vector position)
        {
            int tileX = GetCoordinateOfTile((int)position.X);
            int tileY = GetCoordinateOfTile((int)position.Y);

            if (Tiles[tileX, tileY] is PathTile pathTile)
            {
                pathTile.AddEntity(entity);
            }
        }

        private void RemoveEntity(IMovingEntity entity, Vector position)
        {
            int tileX = GetCoordinateOfTile((int)position.X);
            int tileY = GetCoordinateOfTile((int)position.Y);

            if (Tiles[tileX, tileY] is PathTile pathTile)
            {
                pathTile.RemoveEntity(entity);
            }
        }

        private void AddEntities(List<IMovingEntity> entities)
        {
            foreach (IMovingEntity entity in entities)
            {
                AddEntity(entity, entity.Position);
            }
        }

        public void MoveEntityIfInDifferentTile(Vector oldPos, Vector newPos, IMovingEntity entity)
        {
            int oldTileX = GetCoordinateOfTile((int)oldPos.X);
            int oldTileY = GetCoordinateOfTile((int)oldPos.Y);

            int newTileX = GetCoordinateOfTile((int)newPos.X);
            int newTileY = GetCoordinateOfTile((int)newPos.Y);

            if (oldTileX != newTileX || oldTileY != newTileY)
            {
                RemoveEntity(entity, oldPos);
                AddEntity(entity, newPos);
            }
        }
        public void AlterVectorToStayOutOfWalls(Vector position, Vector vector)
        {
            // Check if target position is in a wall tile
            Vector targetPosition = position.Clone().Add(vector);

            int tileX = GetCoordinateOfTile((int)targetPosition.X);
            int tileY = GetCoordinateOfTile((int)targetPosition.Y);

            GridTile gridTile = Tiles[tileX, tileY];

            if (gridTile == null || !(gridTile is WallTile))
            {
                return;
            }

            WallTile wallTile = (WallTile)gridTile;

            // Calculate distance of every direction from center of encountering block
            int halfWallTileSize = wallTile.Size / 2;
            int measureBuffer = 1;

            int wallTileCenterX = (int)wallTile.Position.X + halfWallTileSize;
            int wallTileCenterY = (int)wallTile.Position.Y + halfWallTileSize;

            double northDistanceFromWallTileCenter = wallTileCenterY - position.Y + measureBuffer;
            double eastDistanceFromWallTileCenter = position.X - wallTileCenterX + measureBuffer;
            double southDistanceFromWallTileCenter = position.Y - wallTileCenterY + measureBuffer;
            double westDistanceFromWallTileCenter = wallTileCenterX - position.X + measureBuffer;

            // Handle encountering north east corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                GridTile gridTileNorth = Tiles[tileX, tileY - 1];
                GridTile gridTileEast = Tiles[tileX + 1, tileY];

                if (gridTileNorth is WallTile && gridTileEast is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (gridTileNorth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    return;
                }

                if (gridTileEast is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (northDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                return;
            }

            // Handle encountering south east corner
            if (southDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                GridTile gridTileEast = Tiles[tileX + 1, tileY];
                GridTile gridTileSouth = Tiles[tileX, tileY + 1];

                if (gridTileSouth is WallTile && gridTileEast is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (gridTileSouth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    return;
                }

                if (gridTileEast is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (southDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                return;
            }

            // Handle encountering south west corner
            if (southDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                GridTile gridTileSouth = Tiles[tileX, tileY + 1];
                GridTile gridTileWest = Tiles[tileX - 1, tileY];

                if (gridTileSouth is WallTile && gridTileWest is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (gridTileSouth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    return;
                }

                if (gridTileWest is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (southDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                vector.SubtractX(targetPosition.X - gridTile.Position.X);
                return;
            }

            // Handle encountering north west corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                GridTile gridTileNorth = Tiles[tileX, tileY - 1];
                GridTile gridTileWest = Tiles[tileX - 1, tileY];

                if (gridTileNorth is WallTile && gridTileWest is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (gridTileNorth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    return;
                }

                if (gridTileWest is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (northDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                vector.SubtractX(targetPosition.X - gridTile.Position.X);
                return;
            }

            // Handle encountering north wall
            if (northDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                return;
            }

            // Handle encountering east wall
            if (eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                return;
            }

            // Handle encountering south wall
            if (southDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                return;
            }

            // Handle encountering west wall
            if (westDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractX(targetPosition.X - gridTile.Position.X);
                return;
            }
        }
    }
}
