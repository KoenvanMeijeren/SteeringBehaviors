using System;
using System.Collections.Generic;
using System.Drawing;
using SteeringCS.entity;
using SteeringCS.graph;
using Src.util;

namespace SteeringCS.grid
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private const int GridTileSize = 32;
        private readonly Color _renderColor = Color.SeaGreen;
        private GridTile[,] _gridTiles;
        private Graph _graph;

        public Grid(int width, int height, List<MovingEntity> entities)
        {
            _width = width;
            _height = height;
            InitializeGridTilesArray();
            InitializeOutsideWallTiles();
            InitializeMazeWallTiles();
            InitializePathTiles();
            InitializeGraph();
            AddEntities(entities);
        }

        private void InitializeGridTilesArray()
        {
            int amountOfTilesX = GetCoordinateOfTile(_width) + 1;
            int amountOfTilesY = GetCoordinateOfTile(_height) + 1;

            _gridTiles = new GridTile[amountOfTilesX, amountOfTilesY];
        }
        private void InitializeOutsideWallTiles()
        {
            int maxX = _gridTiles.GetLength(0);
            int maxY = _gridTiles.GetLength(1);

            for (int x = 0; x < maxX; x++)
            {
                _gridTiles[x, 0] = new WallTile(GridTileSize, x * GridTileSize, 0);
                _gridTiles[x, maxY - 1] = new WallTile(GridTileSize, x * GridTileSize, (maxY - 1) * GridTileSize);
            }

            for (int y = 1; y < maxY - 1; y++)
            {
                _gridTiles[0, y] = new WallTile(GridTileSize, 0 * GridTileSize, y * GridTileSize);
                _gridTiles[maxX - 1, y] = new WallTile(GridTileSize, (maxX - 1) * GridTileSize, y * GridTileSize);
            }
        }

        private void InitializeMazeWallTiles()
        {
            Random random = new Random();
            //TODO (It's random now)
            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    int randomNumber = random.Next(1, 101);

                    if (randomNumber <= 20)
                    {
                        _gridTiles[x, y] = new WallTile(GridTileSize, x * GridTileSize, y * GridTileSize);
                    }
                }
            }
        }

        private void InitializePathTiles()
        {
            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    if (_gridTiles[x, y] == null)
                    {
                        _gridTiles[x, y] = new PathTile(GridTileSize, x * GridTileSize, y * GridTileSize);
                    }
                }
            }
        }

        private void InitializeGraph()
        {
            Vertex[,] vertices = new Vertex[_gridTiles.GetLength(0), _gridTiles.GetLength(1)];

            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    if (_gridTiles[x, y] is PathTile pathTile)
                    {
                        vertices[x, y] = pathTile.Vertex;
                    }
                }
            }

            _graph = new Graph(vertices);
        }

        private int GetCoordinateOfTile(int length)
        {
            return (length - 1) / GridTileSize;
        }

        private void AddEntity(MovingEntity entity, Vector position)
        {
            int tileX = GetCoordinateOfTile((int)position.X);
            int tileY = GetCoordinateOfTile((int)position.Y);

            if (_gridTiles[tileX, tileY] is PathTile pathTile)
            {
                pathTile.AddEntity(entity);
            }
        }

        private void RemoveEntity(MovingEntity entity, Vector position)
        {
            int tileX = GetCoordinateOfTile((int)position.X);
            int tileY = GetCoordinateOfTile((int)position.Y);

            if (_gridTiles[tileX, tileY] is PathTile pathTile)
            {
                pathTile.RemoveEntity(entity);
            }
        }

        private void AddEntities(List<MovingEntity> entities)
        {
            foreach (MovingEntity entity in entities)
            {
                AddEntity(entity, entity.Position);
            }
        }

        public void MoveEntityIfInDifferentTile(Vector oldPos, Vector newPos, MovingEntity entity)
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

            GridTile gridTile = _gridTiles[tileX, tileY];

            if (gridTile == null || !(gridTile is WallTile))
            {
                return;
            }

            WallTile wallTile = (WallTile)gridTile;

            // Calculate distance of every direction from center of encountering block
            int halfWallTileSize = wallTile.Size / 2;
            int measureBuffer = 1;

            int wallTileCenterX = wallTile.Position.X + halfWallTileSize;
            int wallTileCenterY = wallTile.Position.Y + halfWallTileSize;

            double northDistanceFromWallTileCenter = wallTileCenterY - position.Y + measureBuffer;
            double eastDistanceFromWallTileCenter = position.X - wallTileCenterX + measureBuffer;
            double southDistanceFromWallTileCenter = position.Y - wallTileCenterY + measureBuffer;
            double westDistanceFromWallTileCenter = wallTileCenterX - position.X + measureBuffer;

            GridTile gridTileNorth = _gridTiles[tileX, tileY - 1];
            GridTile gridTileEast = _gridTiles[tileX + 1, tileY];
            GridTile gridTileSouth = _gridTiles[tileX, tileY + 1];
            GridTile gridTileWest = _gridTiles[tileX - 1, tileY];

            // Handle encountering north east corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
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


        public void Render(Graphics graphic)
        {
            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    _gridTiles[x, y].Draw(graphic);
                }
            }
        }

        public void RenderOutline(Graphics graphic)
        {
            Pen penDefault = new Pen(_renderColor);
            Pen penActive = new Pen(_renderColor, 3);
            Rectangle rectangle = new Rectangle(0, 0, GridTileSize, GridTileSize);

            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    GridTile gridTile = _gridTiles[x, y];

                    rectangle.X = gridTile.Position.X;
                    rectangle.Y = gridTile.Position.Y;

                    if (gridTile is PathTile pathTile && !pathTile.IsEmpty())
                    {
                        graphic.DrawRectangle(penActive, rectangle);
                        continue;
                    }

                    graphic.DrawRectangle(penDefault, rectangle);
                }
            }
        }

        public void RenderGraph(Graphics graphic)
        {
            _graph.Render(graphic);
        }
    }
}
