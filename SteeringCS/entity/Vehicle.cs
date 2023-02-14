using System.Drawing;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCS.entity
{
    public class Vehicle : MovingEntity
    {
        public const int DefaultScale = 5;
        public Color Color { get; set; }

        public Vehicle(Vector2D position, World world) : base(position, world)
        {
            Velocity = new Vector2D();
            Scale = DefaultScale;
            Color = Color.Black;
        }

        public override void Render(Graphics graphic)
        {
            var leftCorner = Position.XPosition - Scale;
            var rightCorner = Position.YPosition - Scale;
            var size = Scale * 2;

            var pen = new Pen(Color, 2);
            graphic.DrawEllipse(pen, new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size));
            graphic.DrawLine(pen, (int)Position.XPosition, (int)Position.YPosition, (int)Position.XPosition + (int)(Velocity.XPosition * 2), (int)Position.YPosition + (int)(Velocity.YPosition * 2));
        }
    }
}
