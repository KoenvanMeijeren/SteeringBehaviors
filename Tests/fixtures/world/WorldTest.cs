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
            Target = new VehicleTest(targetEntityPosition, this);
            Entities.Add(SeekingEntity);
            Grid = new Grid(width, height, Entities, false);
            Grid.AddOrMoveEntity(Target);
        }

        protected override List<IMovingEntity> GetPopulation()
        {
            return new List<IMovingEntity>();
        }

        public void EditPopulation(SteeringBehaviorOptions selectedOption, int mass, int maxSpeed)
        {
            foreach (IMovingEntity entity in Entities)
            {
                entity.SetSteeringBehavior(SteeringBehaviorFactory.CreateFromEnum(selectedOption, entity));
                entity.Mass = mass;
                entity.MaxSpeed = maxSpeed;
            }
        }
    }
}
