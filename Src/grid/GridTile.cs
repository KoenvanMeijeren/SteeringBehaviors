using Src.util;

namespace Src.grid
{
    public abstract class GridTile
    {
        public readonly int Size;
        public readonly VectorImmutable Position;

        protected GridTile(int size, int x, int y)
        {
            Size = size;
            Position = new VectorImmutable(x, y);
        }
    }
}
