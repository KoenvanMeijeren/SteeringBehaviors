using Src.entity;
using Src.util;
using System.Drawing;
namespace SteeringCS.behavior
{
    public abstract class SteeringBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        private static readonly Color _renderColor = Color.Gray;
        private static readonly Color _secondaryRenderColor = Color.LightGray;
        public abstract Vector Calculate();
        public abstract void Render(Graphics graphic);

        public void RenderVelocity(Graphics graphic, Vector position, Vector velocity)
        {
            Vector targetPosition = position.Clone().Add(velocity);
            Vector furtherTargetPosition = position.Clone().Add(velocity.Clone().Multiply(2));

            Pen pen = new Pen(_renderColor, 2);
            Pen secondaryPen = new Pen(_secondaryRenderColor, 2);

            Point positionPoint = new Point((int)position.X, (int)position.Y);
            Point targetPositionPoint = new Point((int)targetPosition.X, (int)targetPosition.Y);
            Point furtherTargetPositionPoint = new Point((int)furtherTargetPosition.X, (int)furtherTargetPosition.Y);

            graphic.DrawLine(secondaryPen, positionPoint, furtherTargetPositionPoint);
            graphic.DrawLine(pen, positionPoint, targetPositionPoint);
        }
    }
}
