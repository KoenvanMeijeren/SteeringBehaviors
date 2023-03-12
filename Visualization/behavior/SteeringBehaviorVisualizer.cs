using Src.util;
using System.Drawing;
namespace SteeringCS.behavior
{
    public abstract class SteeringBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        private static readonly Color s_renderColor = Color.Black;
        public abstract Vector Calculate();
        public abstract void Render(Graphics graphic);

        public void RenderVelocity(Graphics graphic, Vector position, Vector targetPosition)
        {
            Pen pen = new Pen(s_renderColor, 2);
            Point positionPoint = new Point((int)position.X, (int)position.Y);
            Point targetPositionPoint = new Point((int)targetPosition.X, (int)targetPosition.Y);
            graphic.DrawLine(pen, positionPoint, targetPositionPoint);
        }
    }
}
