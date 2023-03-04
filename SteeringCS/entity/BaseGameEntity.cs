using System.Drawing;
using Src.util;
using SteeringCS.world;

namespace SteeringCS.entity
{
    public abstract class BaseGameEntity
    {
        public Vector Position { get; set; }
        public float Scale { get; protected set; }
        public World World { get; }

        protected BaseGameEntity(Vector position, World world)
        {
            Position = position;
            World = world;
        }

        public abstract void Update(float delta);

        public virtual void Render(Graphics graphic)
        {
            graphic.FillEllipse(Brushes.Blue, new Rectangle((int)Position.X, (int)Position.Y, 10, 10));
        }
    }
}
