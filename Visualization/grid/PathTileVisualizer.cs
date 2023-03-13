using System.Drawing;
using Src.entity;
using Src.grid;
using SteeringCS.util;

namespace SteeringCS.grid
{
    public static class PathTileVisualizer
    {
        public static void Render(Graphics graphic, PathTile pathTile)
        {
            Brush brush = new SolidBrush(Color.AliceBlue);
            Rectangle rectangle = new Rectangle((int)pathTile.Position.X, (int)pathTile.Position.Y, pathTile.Size, pathTile.Size);
            graphic.FillRectangle(brush, rectangle);
        }

        public static void RenderEntities(Graphics graphic, PathTile pathTile)
        {
            foreach (IMovingEntity entity in pathTile.Entities)
            {
                if (entity is IRender entityRender)
                {
                    entityRender.Render(graphic);
                }
            }
        }
    }
}
