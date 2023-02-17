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
            Vector2D position = new Vector2D(XPosition, YPosition);
            World world = new World(WorldWidth, WorldHeight);
            Vehicle vehicle = new Vehicle(position, world);
            SeekingBehavior behavior = new SeekingBehavior(vehicle);

            // Act
            Vector2D velocity = behavior.Calculate();

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
            Vector2D position = new Vector2D(XPosition, YPosition);
            World world = new World(WorldWidth, WorldHeight);
            Vehicle vehicle = new Vehicle(position, world);
            SeekingBehavior behavior = new SeekingBehavior(vehicle);

            // Act
            Vector2D velocity = behavior.Calculate();

            // Assert
            Assert.AreNotEqual(position, velocity);
            Assert.AreNotEqual(XPosition, velocity.XPosition);
            Assert.AreNotEqual(YPosition, velocity.YPosition);
        }
    }
}
