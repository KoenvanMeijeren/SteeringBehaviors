using System.Drawing;
using SteeringCS.util;

namespace SteeringCS.grid
{
    public abstract class GridTile
    {
        public readonly int Size;
        public readonly Position Position;

        protected GridTile(int size, int x, int y)
        {
            Size = size;
            Position = new Position(x, y);
        }

        public abstract void Draw(Graphics graphic);
    }
}
