using Src.util;
using System.Drawing;

namespace SteeringCS.behavior
{
    public abstract class SteeringBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        private static readonly Color s_renderColor = Color.Gray;
        private static readonly Color s_secondaryRenderColor = Color.LightGray;
        public abstract VectorImmutable Calculate();
        public abstract void Render(Graphics graphic);

        protected static void RenderVelocity(Graphics graphic, VectorImmutable position, VectorImmutable velocity)
        {
            VectorImmutable targetPosition = position + velocity;
            VectorImmutable furtherTargetPosition = position + (velocity * 2);

            Pen pen = new Pen(s_renderColor, 2);
            Pen secondaryPen = new Pen(s_secondaryRenderColor, 2);

            Point positionPoint = new Point((int)position.X, (int)position.Y);
            Point targetPositionPoint = new Point((int)targetPosition.X, (int)targetPosition.Y);
            Point furtherTargetPositionPoint = new Point((int)furtherTargetPosition.X, (int)furtherTargetPosition.Y);

            graphic.DrawLine(secondaryPen, positionPoint, furtherTargetPositionPoint);
            graphic.DrawLine(pen, positionPoint, targetPositionPoint);
        }
    }
}
