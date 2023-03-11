using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.behavior;
using SteeringCS.util;

namespace SteeringCS.entity
{
    public class Vehicle : MovingEntity, IRender
    {
        public const int DefaultHeight = 50;
        public const int DefaultWidth = 50;
        public Color Color { get; set; }

        public Vehicle(Vector position, IWorld world) : base(position, world, DefaultHeight, DefaultWidth)
        {
            Velocity = new Vector(0, 0);
            Color = Color.Black;
        }

        public void Render(Graphics graphic)
        {
            double upperLeftCornerX = Position.X - Width/2;
            double upperLeftCornerY = Position.Y - Height/2;

            Pen pen = new Pen(Color, 2);
            graphic.DrawEllipse(pen, new Rectangle((int)upperLeftCornerX, (int)upperLeftCornerY, (int)Width, (int)Height));
        }
    }
}
