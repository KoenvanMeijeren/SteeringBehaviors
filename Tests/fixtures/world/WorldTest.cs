using System.Collections.Generic;
using Src.entity;
using Src.grid;
using Src.util;
using Src.world;
using Tests.fixtures.entity;

namespace Tests.fixtures.world
{
    public class WorldTest : WorldBase
    {
        public WorldTest(int width, int height, Vector seekingEntityPosition, Vector targetEntityPosition) : base(width, height)
        {
            Player = new VehicleTest(targetEntityPosition, this);
            Rescue = new VehicleTest(seekingEntityPosition, this);
            Grid = new Grid(width, height, false);
            Grid.AddOrMoveEntity(Player);
        }

        protected override List<IEnemy> GetEnemies()
        {
            return new List<IEnemy>();
        }

        protected override IPlayer GetPlayer()
        {
            return null;
        }

        protected override IRescue GetRescue()
        {
            return null;
        }
    }
}
