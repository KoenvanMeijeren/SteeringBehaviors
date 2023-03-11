using Src.util;

namespace Src.entity
{
    public class Hitbox
    {
        public IGameEntity Entity;

        public Vector UpperLeftCorner => Entity.Position.Clone().Add(-Entity.Width/2, -Entity.Height/2);
        public Vector UpperRightCorner => Entity.Position.Clone().Add(Entity.Width / 2, -Entity.Height / 2);
        public Vector LowerLeftCorner => Entity.Position.Clone().Add(-Entity.Width / 2, Entity.Height / 2);
        public Vector LowerRightCorner => Entity.Position.Clone().Add(Entity.Width / 2, Entity.Height / 2);

        public Hitbox(IGameEntity entity)
        {
            Entity = entity;
        }
    }
}
