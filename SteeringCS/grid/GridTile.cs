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
    public abstract class GridTile
    {
        public int _size; 
        public Position Position;

        public GridTile(int size, int x, int y)
        {
            _size = size;
            Position = new Position(x, y);
        }
            
        public abstract void Draw(Graphics graphic);
    }
}
