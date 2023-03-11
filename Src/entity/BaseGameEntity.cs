using Src.util;
using Src.world;

namespace Src.entity
{
    public abstract class BaseGameEntity : IGameEntity
    {
        public Vector Position { get; set; }
        public float Height { get; protected set; }
        public float Width { get; protected set; }
        public Hitbox Hitbox { get; protected set; }
        public IWorld World { get; }

        protected BaseGameEntity(Vector position, IWorld world, float height, float width)
        {
            Position = position;
            World = world;
            Height = height;
            Width = width;

            Hitbox = new Hitbox(this);
        }

        public abstract void Update(float timeElapsed);
    }
}
