using System.Collections.Generic;
using Src.entity;
using Src.grid;

namespace Src.world
{
    public abstract class WorldBase : IWorld
    {
        public IPlayer Player { get; protected set; }
        public IRescue Rescue { get; protected set; }

        protected readonly List<IEnemy> Enemies;
        public IGrid Grid { get; protected set; }

        public int Width { get; }
        public int Height { get; }

        protected WorldBase(int width, int height)
        {
            Width = width;
            Height = height;
            Enemies = GetEnemies();
            Player = GetPlayer();
            Rescue = GetRescue();
            Grid = new Grid(width, height);
            Grid.AddOrMoveEntity(Player);
        }

        protected abstract List<IEnemy> GetEnemies();
        protected abstract IPlayer GetPlayer();
        protected abstract IRescue GetRescue();

        public void Update(float timeElapsed)
        {
            Player.Update(timeElapsed);
            Grid.AddOrMoveEntity(Player);

            Rescue.Update(timeElapsed);
            Grid.AddOrMoveEntity(Rescue);

            foreach (IEnemy entity in Enemies)
            {
                entity.Update(timeElapsed);
                Grid.AddOrMoveEntity(entity);
            }
        }
    }
}
