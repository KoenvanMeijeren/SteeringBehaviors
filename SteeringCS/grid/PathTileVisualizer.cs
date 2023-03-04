using System.Drawing;
using Src.grid;

namespace SteeringCS.grid
{
    public static class PathTileVisualizer
    {
        public static void Render(Graphics graphic, PathTile pathTile)
        {
            Brush brush = new SolidBrush(Color.AliceBlue);
            Rectangle rectangle = new Rectangle((int) pathTile.Position.X, (int) pathTile.Position.Y, pathTile.Size, pathTile.Size);
            graphic.FillRectangle(brush, rectangle);
        }
    }
}
