using System.Drawing;
using Src.util;

namespace SteeringCS.behavior
{
    public abstract class SteeringBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        private static readonly Color s_renderColor = Color.Gray;
        private static readonly Color s_secondaryRenderColor = Color.LightGray;
        public abstract Vector Calculate();
        public abstract bool ShouldAvoidObstacles();
        public abstract void Render(Graphics graphic);

        public abstract void RenderVelocity(Graphics graphic);

        protected static void RenderVelocity(Graphics graphic, Vector position, Vector velocity)
        {
            Vector targetPosition = position + velocity;
            Vector furtherTargetPosition = position + (velocity * 2);

            Pen pen = new Pen(s_renderColor, 2);
            Pen secondaryPen = new Pen(s_secondaryRenderColor, 2);

            Point positionPoint = new Point((int)position.X, (int)position.Y);
            Point targetPositionPoint = new Point((int)targetPosition.X, (int)targetPosition.Y);
            Point furtherTargetPositionPoint = new Point((int)furtherTargetPosition.X, (int)furtherTargetPosition.Y);

            graphic.DrawLine(secondaryPen, positionPoint, furtherTargetPositionPoint);
            graphic.DrawLine(pen, positionPoint, targetPositionPoint);
        }

        protected static void RenderVelocityText(Graphics graphic, Vector position, Vector velocity)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Font font = new Font("Open sans", 10, FontStyle.Bold);
            PointF pointF = new PointF((int)position.X, (int)position.Y);

            StringFormat stringFormatCenter = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            graphic.DrawString(velocity.ToString(), font, brush, pointF, stringFormatCenter);

        }
    }
}
