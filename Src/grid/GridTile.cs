using Src.util;

namespace Src.grid
{
    public abstract class GridTile
    {
        public readonly int Size, SizeCenter;
        public readonly Vector Position, PositionCenter, PositionStart, PositionEnd;

        protected GridTile(int size, int x, int y)
        {
            Size = size;
            SizeCenter = size / 2;
            Position = new Vector(x, y);
            PositionCenter = new Vector(x + SizeCenter, y + SizeCenter);
            PositionStart = new Vector(x, y);
            PositionEnd = new Vector(x + size, y + size);
        }
    }
}
