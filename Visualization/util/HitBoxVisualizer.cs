using System.Drawing;
using Src.util;

namespace SteeringCS.util
{
    public static class HitBoxVisualizer
    {
        private static readonly Color s_renderColor = Color.Fuchsia;
        public static void Render(Graphics graphic, HitBox hitBox)
        {
            Pen pen = new Pen(s_renderColor, 1);
            Point upperLeftPoint = new Point((int)hitBox.UpperLeftCorner.X, (int)hitBox.UpperLeftCorner.Y);
            Point upperRightPoint = new Point((int)hitBox.UpperRightCorner.X, (int)hitBox.UpperRightCorner.Y);
            Point lowerLeftPoint = new Point((int)hitBox.LowerLeftCorner.X, (int)hitBox.LowerLeftCorner.Y);
            Point lowerRightPoint = new Point((int)hitBox.LowerRightCorner.X, (int)hitBox.LowerRightCorner.Y);

            graphic.DrawLine(pen, upperLeftPoint, upperRightPoint);
            graphic.DrawLine(pen, upperRightPoint, lowerRightPoint);
            graphic.DrawLine(pen, lowerRightPoint, lowerLeftPoint);
            graphic.DrawLine(pen, lowerLeftPoint, upperLeftPoint);
        }
    }
}
