using Src.entity;
using System.Drawing;

namespace SteeringCS.util
{
    public static class HitboxVisualizer
    {
        private static readonly Color s_renderColor = Color.Fuchsia;
        public static void Render(Graphics graphic, Hitbox hitbox)
        {
            Pen pen = new Pen(s_renderColor, 1);
            Point upperLeftPoint = new Point((int)hitbox.UpperLeftCorner.X, (int)hitbox.UpperLeftCorner.Y);
            Point upperRightPoint = new Point((int)hitbox.UpperRightCorner.X, (int)hitbox.UpperRightCorner.Y);
            Point lowerLeftPoint = new Point((int)hitbox.LowerLeftCorner.X, (int)hitbox.LowerLeftCorner.Y);
            Point lowerRightPoint = new Point((int)hitbox.LowerRightCorner.X, (int)hitbox.LowerRightCorner.Y);

            graphic.DrawLine(pen, upperLeftPoint, upperRightPoint);
            graphic.DrawLine(pen, upperRightPoint, lowerRightPoint);
            graphic.DrawLine(pen, lowerRightPoint, lowerLeftPoint);
            graphic.DrawLine(pen, lowerLeftPoint, upperLeftPoint);
        }
    }
}
