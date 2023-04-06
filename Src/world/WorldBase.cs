using System.Collections.Generic;
using Src.entity;
using Src.grid;

namespace Src.world
{
    public abstract class WorldBase : IWorld
    {
        public const int DefaultEnemiesCount = 3;
        public IPlayer Player { get; protected set; }
        public IRescuee Rescuee { get; protected set; }

        public List<IEnemy> Enemies { get; private set; }
        public IGrid Grid { get; protected set; }

        public int Width { get; }
        public int Height { get; }

        private int _enemiesCount = DefaultEnemiesCount;

        protected WorldBase(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new Grid(width, height);
            Enemies = GetEnemies(_enemiesCount);
            Player = GetPlayer();
            Rescuee = GetRescuee();
            Grid.AddOrMoveEntity(Player);
        }

        protected abstract List<IEnemy> GetEnemies(int enemiesCount);
        protected abstract IPlayer GetPlayer();
        protected abstract IRescuee GetRescuee();

        public void UpdateEnemies(int enemiesCount)
        {
            if (_enemiesCount == enemiesCount)
            {
                return;
            }

            _enemiesCount = enemiesCount;
            // Remove all entities from grid because otherwise they stay forever on the last known grid tiles.
            foreach (IEnemy enemy in Enemies)
            {
                Grid.RemoveEntity(enemy);
            }

            Enemies = GetEnemies(enemiesCount);
        }

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
