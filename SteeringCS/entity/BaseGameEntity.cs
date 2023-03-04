using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.util;

namespace SteeringCS.entity
{
    public abstract class BaseGameEntity : IGameEntity
    {
        public Vector Position { get; set; }
        public float Scale { get; protected set; }
        public IWorld World { get; }

        protected BaseGameEntity(Vector position, IWorld world)
        {
            Position = position;
            World = world;
        }

        public abstract void Update(float timeElapsed);
    }
}
