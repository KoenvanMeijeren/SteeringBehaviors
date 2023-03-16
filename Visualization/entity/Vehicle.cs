using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.util;

namespace SteeringCS.entity
{
    public class Vehicle : MovingEntity, IRender
    {
        private const int DefaultHeight = 25;
        private const int DefaultWidth = 25;
        private readonly Color _color;

        public Vehicle(VectorImmutable position, IWorld world) : base(position, world, DefaultHeight, DefaultWidth)
        {
            Velocity = new VectorImmutable(0, 0);
            _color = Color.Black;
        }

        public void Render(Graphics graphic)
        {
            double upperLeftCornerX = Position.X - Width / 2;
            double upperLeftCornerY = Position.Y - Height / 2;

            Pen pen = new Pen(_color, 2);
            graphic.DrawEllipse(pen, new Rectangle((int)upperLeftCornerX, (int)upperLeftCornerY, (int)Width, (int)Height));
        }
    }
}
