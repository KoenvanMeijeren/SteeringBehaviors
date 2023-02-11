using System.Drawing;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCS.entity
{
    public class Vehicle : MovingEntity
    {
        private const int DefaultScale = 5;
        public Color Color { get; set; }

        public Vehicle(Vector2D position, World world) : base(position, world)
        {
            Velocity = new Vector2D();
            Scale = DefaultScale;
            Color = Color.Black;
        }

        public override void Render(Graphics graphic)
        {
            var leftCorner = Position.EastPosition - Scale;
            var rightCorner = Position.NorthPosition - Scale;
            var size = Scale * 2;

            var pen = new Pen(Color, 2);
            graphic.DrawEllipse(pen, new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size));
            graphic.DrawLine(pen, (int)Position.EastPosition, (int)Position.NorthPosition, (int)Position.EastPosition + (int)(Velocity.EastPosition * 2), (int)Position.NorthPosition + (int)(Velocity.NorthPosition * 2));
        }
    }
}
