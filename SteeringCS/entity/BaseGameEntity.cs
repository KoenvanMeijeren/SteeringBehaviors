using System.Drawing;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCS.entity
{
    public abstract class BaseGameEntity
    {
        public Vector2D Position { get; set; }
        public float Scale { get; protected set; }
        public World World { get; }

        protected BaseGameEntity(Vector2D position, World world)
        {
            Position = position;
            World = world;
        }

        public abstract void Update(float delta);

        public virtual void Render(Graphics graphic)
        {
            graphic.FillEllipse(Brushes.Blue, new Rectangle((int)Position.XPosition, (int)Position.YPosition, 10, 10));
        }
    }
}
