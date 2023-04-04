using System.Drawing;
using System.Linq;
using Src.entity;
using Src.grid;
using SteeringCS.util;

namespace SteeringCS.grid
{
    public static class PathTileVisualizer
    {
        private static readonly Image s_image = Image.FromFile("graphics/path.png");
        private static readonly Image s_imageFinish = Image.FromFile("graphics/finish.png");

        public static void Render(Graphics graphic, PathTile pathTile)
        {
            if (pathTile.IsFinish)
            {
                graphic.DrawImage(s_imageFinish, (int)pathTile.Position.X, (int)pathTile.Position.Y);
                return;
            }

            graphic.DrawImage(s_image, (int)pathTile.Position.X, (int)pathTile.Position.Y);
        }

        public static void RenderEntities(Graphics graphic, PathTile pathTile)
        {

            foreach (IMovingEntity entity in pathTile.Entities.OrderBy(entity => entity.Position.Y))
            {
                if (entity is IRender entityRender)
                {
                    entityRender.Render(graphic);
                }
            }
        }
    }
}
