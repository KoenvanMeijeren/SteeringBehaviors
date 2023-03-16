using Src.util;

namespace Src.grid
{
    public abstract class GridTile
    {
        public readonly int Size;
        public readonly Vector Position;

        protected GridTile(int size, int x, int y)
        {
            Size = size;
            Position = new Vector(x, y);
        }
    }
}
