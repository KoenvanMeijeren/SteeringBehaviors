using SteeringCS.entity;
using SteeringCS.graph;
using SteeringCS.grid;
using SteeringCS.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.world
{
    public class Grid
    {
        private int _width;
        private int _height;
        private const int _gridTileSize = 32;
        private readonly Color _renderColor = Color.SeaGreen;
        private GridTile[,] _gridTiles;
        private Graph _graph;

        public Grid(int width, int height, List<MovingEntity> entities)
        {
            _width = width;
            _height = height;
            initializeGridTilesArray();
            initializeOutsideWallTiles();
            initializeMazeWallTiles();
            initializePathTiles();
            initializeGraph();
            addEntities(entities);
        }

        private void initializeGridTilesArray()
        {
            int AmountOfTilesX = getCoordinateOfTile(_width) + 1;
            int AmountOfTilesY = getCoordinateOfTile(_height) + 1;

            _gridTiles = new GridTile[AmountOfTilesX, AmountOfTilesY];
        }
        private void initializeOutsideWallTiles()
        {
            int MaxX = _gridTiles.GetLength(0);
            int MaxY = _gridTiles.GetLength(1);

            for (int x = 0; x < MaxX; x++)
            {
                _gridTiles[x, 0] = new WallTile(_gridTileSize, x * _gridTileSize, 0);
                _gridTiles[x, MaxY - 1] = new WallTile(_gridTileSize, x * _gridTileSize, (MaxY-1) * _gridTileSize);
            }

            for (int y = 1; y < MaxY - 1; y++)
            {
                _gridTiles[0, y] = new WallTile(_gridTileSize, 0 * _gridTileSize, y * _gridTileSize);
                _gridTiles[MaxX - 1, y] = new WallTile(_gridTileSize, (MaxX - 1) * _gridTileSize, y * _gridTileSize);
            }
        }

        private void initializeMazeWallTiles()
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
                        _gridTiles[x, y] = new WallTile(_gridTileSize, x * _gridTileSize, y * _gridTileSize);
                    }
                }
            }
        }

        private void initializePathTiles()
        {
            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    if (_gridTiles[x,y] == null)
                    {
                        _gridTiles[x, y] = new PathTile(_gridTileSize, x * _gridTileSize, y * _gridTileSize);
                    }
                }
            }
        }

        private void initializeGraph()
        {
            Vertex[,] vertices = new Vertex[_gridTiles.GetLength(0), _gridTiles.GetLength(1)];

            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    if (_gridTiles[x,y] is PathTile pathTile)
                    {
                        vertices[x, y] = pathTile.Vertex;
                    }
                }
            }

            _graph = new Graph(vertices);
        }

        private int getCoordinateOfTile(int length)
        {
            return (length - 1) / _gridTileSize;
        }

        private void addEntity(MovingEntity entity, Vector2D position)
        {
            int TileX = getCoordinateOfTile((int)position.XPosition);
            int TileY = getCoordinateOfTile((int)position.YPosition);

            if (_gridTiles[TileX, TileY] is PathTile pathTile)
            {
                pathTile.AddEntity(entity);
                Console.WriteLine(TileX + " " + TileY);
            }
        }

        private void removeEntity(MovingEntity entity, Vector2D position)
        {
            int TileX = getCoordinateOfTile((int)position.XPosition);
            int TileY = getCoordinateOfTile((int)position.YPosition);

            if (_gridTiles[TileX, TileY] is PathTile pathTile)
            {
                pathTile.RemoveEntity(entity);
            }
        }

        private void addEntities(List<MovingEntity> entities)
        {
            foreach (MovingEntity entity in entities)
            {
                addEntity(entity, entity.Position);
            }
        }

        public void MoveEntityIfInDifferentTile(Vector2D oldPos, Vector2D newPos, MovingEntity entity)
        {
            int oldTileX = getCoordinateOfTile((int)oldPos.XPosition);
            int oldTileY = getCoordinateOfTile((int)oldPos.YPosition);

            int newTileX = getCoordinateOfTile((int)newPos.XPosition);
            int newTileY = getCoordinateOfTile((int)newPos.YPosition);

            if (oldTileX != newTileX || oldTileY != newTileY)
            {
                removeEntity(entity, oldPos);
                addEntity(entity, newPos);
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
            Rectangle rectangle = new Rectangle(0, 0, _gridTileSize, _gridTileSize);

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
