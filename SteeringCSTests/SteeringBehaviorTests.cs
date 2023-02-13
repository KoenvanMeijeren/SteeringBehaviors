using NUnit.Framework;
using SteeringCS.behaviour;
using SteeringCS.entity;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCSTests
{
    public class SeekingBehaviorTests
    {
        [Test]
        public void Test_Calculate_01_Ok()
        {
            // Mocked values
            const int EastPosition = 2, NorthPosition = 3, WorldWidth = 20, WorldHeight = 20;
            const double ExpectedEastPosition = 98.0d, ExpectedNorthPosition = 37.0d;
            
            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);
            var vehicle = new Vehicle(position, world);
            var behavior = new SeekBehaviour(vehicle);

            // Act
            var velocity = behavior.Calculate();

            // Assert
            Assert.AreEqual(ExpectedEastPosition, velocity.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, velocity.NorthPosition);
        }
        
        [Test]
        public void Test_CalculateDidNotChangeExistingValues_02_Ok()
        {
            // Mocked values
            const int EastPosition = 2, NorthPosition = 3, WorldWidth = 20, WorldHeight = 20;
            
            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);
            var vehicle = new Vehicle(position, world);
            var behavior = new SeekBehaviour(vehicle);

            // Act
            var velocity = behavior.Calculate();

            // Assert
            Assert.AreNotEqual(position, velocity);
            Assert.AreNotEqual(EastPosition, velocity.EastPosition);
            Assert.AreNotEqual(NorthPosition, velocity.NorthPosition);
        }
    }
}
