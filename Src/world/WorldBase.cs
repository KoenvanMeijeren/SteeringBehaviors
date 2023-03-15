using System.Collections.Generic;
using Src.entity;
using Src.grid;

namespace Src.world
{
    public abstract class WorldBase : IWorld
    {
        protected readonly List<IMovingEntity> Entities;
        public IGrid Grid { get; protected set; }
        public IMovingEntity Target { get; protected set; }

        public int Width { get; }
        public int Height { get; }

        protected WorldBase(int width, int height)
        {
            Width = width;
            Height = height;
            Entities = GetPopulation();
            Grid = new Grid(width, height, Entities);
            Grid.AddOrMoveEntity(Target);
        }

        protected abstract List<IMovingEntity> GetPopulation();

        public void Update(float timeElapsed)
        {
            Target.Update(timeElapsed);
            Grid.AddOrMoveEntity(Target);

            foreach (IMovingEntity entity in Entities)
            {
                entity.Update(timeElapsed);
                Grid.AddOrMoveEntity(entity);
            }
        }

        public void UpdateImmutable(float timeElapsed)
        {
            Target.UpdateImmutable(timeElapsed);
            Grid.AddOrMoveEntity(Target);

            foreach (IMovingEntity entity in Entities)
            {
                entity.UpdateImmutable(timeElapsed);
                Grid.AddOrMoveEntity(entity);
            }
        }
    }
}
