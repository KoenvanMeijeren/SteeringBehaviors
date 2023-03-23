using System.Collections.Generic;
using Src.behavior;
using Src.entity;
using Src.grid;
using Src.util;
using Src.world;
using Tests.fixtures.entity;

namespace Tests.fixtures.world
{
    public class WorldTest : WorldBase
    {
        public readonly IMovingEntity SeekingEntity;

        public WorldTest(int width, int height, Vector seekingEntityPosition, Vector targetEntityPosition) : base(width, height)
        {
            SeekingEntity = new VehicleTest(seekingEntityPosition, this);
            Player = new VehicleTest(targetEntityPosition, this);
            Enemies.Add(SeekingEntity);
            Grid = new Grid(width, height, Enemies, false);
            Grid.AddOrMoveEntity(Player);
        }

        protected override List<IMovingEntity> SetEntities()
        {
            return new List<IMovingEntity>();
        }

        public void EditPopulation(SteeringBehaviorOptions selectedOption, int mass, int maxSpeed)
        {
            foreach (IMovingEntity entity in Enemies)
            {
                entity.SetSteeringBehavior(
                    SteeringBehaviorFactory.CreateFromEnum(selectedOption, entity),
                    new CollisionAvoidingBehavior(entity)
                );
                entity.Mass = mass;
                entity.MaxSpeed = maxSpeed;
            }
        }

        public List<IMovingEntity> GetEntities()
        {
            return Enemies;
        }
    }
}
