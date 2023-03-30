using System.Drawing;
using System.Linq;
using Visualization.entity;
using Visualization.grid;
using SteeringCS.util;

namespace SteeringCS.grid
{
    public static class PathTileVisualizer
    {
        private static readonly Image s_image = Image.FromFile("graphics/path.png");

        public static void Render(Graphics graphic, PathTile pathTile)
        {
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
