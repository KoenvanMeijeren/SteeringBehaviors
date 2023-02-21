using SteeringCS.entity;
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
        private const int _gridTileSize = 64;
        private readonly Color _gridColor = Color.SeaGreen;
        private GridTile[,] _gridTiles;

        public Grid(int width, int height, List<MovingEntity> entities)
        {
            _width = width;
            _height = height;
            initializeGridTiles();
            addEntities(entities);
        }

        private void initializeGridTiles()
        {
            int AmountOfTilesX = getCoordinateOfTile(_width) + 1;
            int AmountOfTilesY = getCoordinateOfTile(_height) + 1;

            _gridTiles = new GridTile[AmountOfTilesX, AmountOfTilesY];

            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    _gridTiles[x, y] = new GridTile();
                }
            }
        }

        private int getCoordinateOfTile(int length)
        {
            return (length - 1) / _gridTileSize;
        }

        private void addEntity(MovingEntity entity, Vector2D position)
        {
            int TileX = getCoordinateOfTile((int)position.XPosition);
            int TileY = getCoordinateOfTile((int)position.YPosition);

            _gridTiles[TileX, TileY].AddEntity(entity);
            Console.WriteLine(TileX + " " + TileY);
        }

        private void removeEntity(MovingEntity entity, Vector2D position)
        {
            int TileX = getCoordinateOfTile((int)position.XPosition);
            int TileY = getCoordinateOfTile((int)position.YPosition);

            _gridTiles[TileX, TileY].RemoveEntity(entity);
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
            Pen penDefault = new Pen(_gridColor);
            Pen penActive = new Pen(_gridColor, 3);
            Rectangle rectangle = new Rectangle(0, 0, _gridTileSize, _gridTileSize);

            for (int x = 0; x < _gridTiles.GetLength(0); x++)
            {
                for (int y = 0; y < _gridTiles.GetLength(1); y++)
                {
                    rectangle.X = x * _gridTileSize;
                    rectangle.Y = y * _gridTileSize;

                    if (!_gridTiles[x, y].IsEmpty())
                    {
                        graphic.DrawRectangle(penActive, rectangle);
                        continue;
                    }

                    graphic.DrawRectangle(penDefault, rectangle);
                }
            }
        }
    }
}
