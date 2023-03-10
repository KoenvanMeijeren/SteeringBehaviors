using System.Drawing;
using Src.grid;

namespace SteeringCS.grid
{
    public static class WallTileVisualizer
    {
        private static readonly Image s_image = Image.FromFile("graphics/wall.png");

        public static void Render(Graphics graphic, WallTile wallTile)
        {
            graphic.DrawImage(s_image, (int)wallTile.Position.X, (int)wallTile.Position.Y);
        }
    }
}
