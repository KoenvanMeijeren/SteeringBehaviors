﻿using System;
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

        public GridTile GetTile(int x, int y)
        {
            if (x < 0 || x >= Tiles.GetLength(0))
            {
                return null;
            }

            if (y < 0 || y >= Tiles.GetLength(1))
            {
                return null;
            }
            
            return Tiles[x, y];
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
    }
}
