using System.Collections.Generic;
using Src.entity;
using Src.grid;
using Src.util;

namespace Src.world
{
    public abstract class WorldBase : IWorld
    {
        public IPlayer Player { get; protected set; }
        public IRescuee Rescuee { get; protected set; }

        public List<IEnemy> Enemies { get; protected set; }
        public IGrid Grid { get; protected set; }

        public int Width { get; }
        public int Height { get; }
        public Vector Center { get; }

        protected WorldBase(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new Grid(width, height);
            Enemies = GetEnemies();
            Player = GetPlayer();
            Rescuee = GetRescuee();
            Grid.AddOrMoveEntity(Player);

            Center = new Vector(Width/2, Height/2);
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
