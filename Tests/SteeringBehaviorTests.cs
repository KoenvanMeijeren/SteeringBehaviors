using NUnit.Framework;
using Src.behavior;
using Src.util;
using Tests.fixtures.entity;
using Tests.fixtures.world;

namespace Tests
{
    public class SeekingBehaviorTests
    {
        [Test]
        public void Test_Calculate_01_Ok()
        {
            // Mocked values
            const int XPosition = 2, YPosition = 3, WorldWidth = 20, WorldHeight = 20;
            const double ExpectedXPosition = 38.0d, ExpectedYPosition = 57.0d;

            // Arrange
            Vector position = new(XPosition, YPosition);
            WorldTest world = new(WorldWidth, WorldHeight);
            VehicleTest vehicleTest = new(position, world);
            SeekingBehavior behaviorVisualizer = new(vehicleTest);

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
            WorldTest world = new WorldTest(WorldWidth, WorldHeight);
            VehicleTest vehicleTest = new VehicleTest(position, world);
            SeekingBehavior behaviorVisualizer = new SeekingBehavior(vehicleTest);

            // Act
            Vector velocity = behaviorVisualizer.Calculate();

            // Assert
            Assert.AreNotEqual(position, velocity);
            Assert.AreNotEqual(XPosition, velocity.X);
            Assert.AreNotEqual(YPosition, velocity.Y);
        }
    }
}
