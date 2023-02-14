using NUnit.Framework;
using SteeringCS.behavior;
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
            const int XPosition = 2, YPosition = 3, WorldWidth = 20, WorldHeight = 20;
            const double ExpectedXPosition = 98.0d, ExpectedYPosition = 37.0d;

            // Arrange
            var position = new Vector2D(XPosition, YPosition);
            var world = new World(WorldWidth, WorldHeight);
            var vehicle = new Vehicle(position, world);
            var behavior = new SeekingBehavior(vehicle);

            // Act
            var velocity = behavior.Calculate();

            // Assert
            Assert.AreEqual(ExpectedXPosition, velocity.XPosition);
            Assert.AreEqual(ExpectedYPosition, velocity.YPosition);
        }

        [Test]
        public void Test_CalculateDidNotChangeExistingValues_02_Ok()
        {
            // Mocked values
            const int XPosition = 2, YPosition = 3, WorldWidth = 20, WorldHeight = 20;

            // Arrange
            var position = new Vector2D(XPosition, YPosition);
            var world = new World(WorldWidth, WorldHeight);
            var vehicle = new Vehicle(position, world);
            var behavior = new SeekingBehavior(vehicle);

            // Act
            var velocity = behavior.Calculate();

            // Assert
            Assert.AreNotEqual(position, velocity);
            Assert.AreNotEqual(XPosition, velocity.XPosition);
            Assert.AreNotEqual(YPosition, velocity.YPosition);
        }
    }
}
