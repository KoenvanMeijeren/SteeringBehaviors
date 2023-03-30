﻿using System.Collections.Generic;
using Visualization.entity;
using Visualization.grid;
using Visualization.util;
using Visualization.world;
using Tests.fixtures.entity;

namespace Tests.fixtures.world
{
    public class WorldTest : WorldBase
    {
        public WorldTest(int width, int height, Vector seekingEntityPosition, Vector targetEntityPosition) : base(width, height)
        {
            Player = new VehicleTest(targetEntityPosition, this);
            Rescuee = new VehicleTest(seekingEntityPosition, this);
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

        protected override IRescuee GetRescuee()
        {
            return null;
        }
    }
}
