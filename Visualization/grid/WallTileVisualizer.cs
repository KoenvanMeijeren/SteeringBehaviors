using System.Drawing;
using Src.grid;

namespace SteeringCS.grid
{
    public static class WallTileVisualizer
    {
        private static readonly Image s_image = Image.FromFile("graphics/wall3d.png");

        public static void Render(Graphics graphic, WallTile wallTile)
        {
            int surplusY = 0;

            if (wallTile.Size < s_image.Height)
            {
                surplusY = s_image.Height - wallTile.Size;
            }

            graphic.DrawImage(s_image, (int)wallTile.Position.X, (int)wallTile.Position.Y - surplusY);
        }
    }
}
