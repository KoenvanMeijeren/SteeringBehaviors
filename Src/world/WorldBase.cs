using System.Collections.Generic;
using Src.entity;
using Src.grid;

namespace Src.world
{
    public abstract class WorldBase : IWorld
    {
        public IPlayer Player { get; protected set; }
        public IRescuee Rescuee { get; protected set; }

        public readonly List<IEnemy> Enemies;
        public IGrid Grid { get; protected set; }

        public int Width { get; }
        public int Height { get; }

        protected WorldBase(int width, int height)
        {
            Width = width;
            Height = height;
            Enemies = GetEnemies();
            Player = GetPlayer();
            Rescuee = GetRescuee();
            Grid = new Grid(width, height);
            Grid.AddOrMoveEntity(Player);
        }

        protected abstract List<IEnemy> GetEnemies();
        protected abstract IPlayer GetPlayer();
        protected abstract IRescuee GetRescuee();

        public void Update(float timeElapsed)
        {
            Player.Update(timeElapsed);
            Grid.AddOrMoveEntity(Player);

            Rescuee.Update(timeElapsed);
            Grid.AddOrMoveEntity(Rescuee);

            foreach (IEnemy entity in Enemies)
            {
                entity.Update(timeElapsed);
                Grid.AddOrMoveEntity(entity);
            }
        }
    }
}
