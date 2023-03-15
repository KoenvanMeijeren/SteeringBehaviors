using System.Collections.Generic;
using Src.behavior;
using Src.entity;
using Src.util;
using Src.world;
using Tests.fixtures.entity;

namespace Tests.fixtures.world
{
    public class WorldTest : WorldBase
    {
        public WorldTest(int width, int height) : base(width, height)
        {
        }

        protected override List<IMovingEntity> GetPopulation()
        {
            List<IMovingEntity> entities = new List<IMovingEntity>();
            VehicleTest vehicleTest = new VehicleTest(new Vector(Width / 2, Height / 2), this);
            entities.Add(vehicleTest);

            Target = new VehicleTest(new Vector(40, 60), this);

            return entities;
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
