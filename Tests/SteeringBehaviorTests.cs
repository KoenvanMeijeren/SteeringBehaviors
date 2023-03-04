using NUnit.Framework;
using Src.behavior;
using Src.util;
using SteeringCS.behavior;
using SteeringCS.entity;
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
            Vector position = new(XPosition, YPosition);
            WorldVisualization world = new(WorldWidth, WorldHeight);
            Vehicle vehicle = new(position, world);
            SeekingBehavior behaviorVisualizer = new(vehicle);

            // Act
            Vector velocity = behaviorVisualizer.Calculate();

            // Assert
            Assert.AreEqual(ExpectedXPosition, velocity.X);
            Assert.AreEqual(ExpectedYPosition, velocity.Y);
        }

        [Test]
        public void Test_CalculateDidNotChangeExistingValues_02_Ok()
        {
            // Mocked values
            const int XPosition = 2, YPosition = 3, WorldWidth = 20, WorldHeight = 20;

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            WorldVisualization world = new WorldVisualization(WorldWidth, WorldHeight);
            Vehicle vehicle = new Vehicle(position, world);
            SeekingBehavior behaviorVisualizer = new SeekingBehavior(vehicle);

            // Act
            Vector velocity = behaviorVisualizer.Calculate();

            // Assert
            Assert.AreNotEqual(position, velocity);
            Assert.AreNotEqual(XPosition, velocity.X);
            Assert.AreNotEqual(YPosition, velocity.Y);
        }
    }
}
