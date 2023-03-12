using System.Collections.Generic;
using Src.entity;
using Src.grid;
using Src.util;

namespace Src.world
{
    public abstract class WorldBase : IWorld
    {
        protected readonly List<IMovingEntity> Entities;
        public IGrid Grid { get; }
        public IMovingEntity Target { get; protected set; }

        public int Width { get; }
        public int Height { get; }

        protected WorldBase(int width, int height)
        {
            Width = width;
            Height = height;
            Entities = GetPopulation();
            Grid = new Grid(width, height, Entities);
        }

        protected abstract List<IMovingEntity> GetPopulation();

        public void Update(float timeElapsed)
        {
            Target.Update(timeElapsed);

            foreach (IMovingEntity entity in Entities)
            {
                Vector oldPos = entity.Position.Clone();
                entity.Update(timeElapsed);
                Vector newPos = entity.Position.Clone();
                Grid.MoveEntityIfInDifferentTile(oldPos, newPos, entity);
            }
        }
    }
}
