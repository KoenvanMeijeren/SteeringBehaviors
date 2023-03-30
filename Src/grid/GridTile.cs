using Visualization.util;

namespace Visualization.grid
{
    public abstract class GridTile
    {
        public readonly int Size, SizeCenter;
        public readonly Vector Position, PositionCenter, PositionEnd;

        protected GridTile(int size, int x, int y)
        {
            Size = size;
            SizeCenter = size / 2;
            Position = new Vector(x, y);
            PositionCenter = new Vector(x + SizeCenter, y + SizeCenter);
            PositionEnd = new Vector(x + size, y + size);
        }
    }
}
