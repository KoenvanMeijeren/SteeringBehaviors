using System.ComponentModel;
using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Tests.fixtures.entity;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class SteeringBehaviorFactoryTests
    {
        [Test]
        public void CreateFromEnum_01_Ok()
        {
            // Arrange
            IMovingEntity movingEntity = new VehicleTest(new Vector(0, 0), 
                new WorldTest(0, 0, new Vector(0, 0), new Vector(0, 0))
            );
            
            // Act & Assert
            Assert.IsInstanceOf<IdlingBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.IdlingBehavior, movingEntity));
            Assert.IsInstanceOf<FleeingBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.FleeingBehavior, movingEntity));
            Assert.IsInstanceOf<ArrivingBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.ArrivingBehavior, movingEntity));
            Assert.IsInstanceOf<MosquitoBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.MosquitoBehavior, movingEntity));
            Assert.IsInstanceOf<PathfindingBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.PathfindingBehavior, movingEntity));
            Assert.IsInstanceOf<SeekingBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.SeekingBehavior, movingEntity));
            Assert.IsInstanceOf<WanderingBehavior>(SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.WanderingBehavior, movingEntity));
        }
        
        [Test]
        public void CreateFromEnum_02_ThrowsOnNotImplementedBehavior()
        {
            // Arrange
            IMovingEntity movingEntity = new VehicleTest(new Vector(0, 0), 
                new WorldTest(0, 0, new Vector(0, 0), new Vector(0, 0))
            );
            
            // Act & Assert
            Assert.Throws<InvalidEnumArgumentException>(() =>
            {
                SteeringBehaviorFactory.CreateFromEnum(SteeringBehaviorOptions.NotImplementedBehavior, movingEntity);
            });
        }
    }
}
