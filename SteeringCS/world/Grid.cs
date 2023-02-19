using SteeringCS.entity;
using System;
using System.Collections.Generic;
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
        private BaseGameEntity[,] _gridContent;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            initializeGridContent();
        }

        private void initializeGridContent()
        {
            int AmountOfTilesX = (_width + _gridTileSize - 1) / _gridTileSize;
            int AmountOfTilesY = (_height + _gridTileSize - 1) / _gridTileSize;

            _gridContent = new BaseGameEntity[AmountOfTilesX, AmountOfTilesY];
        }
    }
}
