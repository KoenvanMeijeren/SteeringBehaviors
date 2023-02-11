using NUnit.Framework;
using SteeringCS.util;

namespace SteeringCSTests
{
    public class Tests
    {
        [Test]
        public void Test_CreateEmpty_01_Ok()
        {
            // Arrange
            const int ExpectedEastPosition = 0;
            const int ExpectedNorthPosition = 0;

            // Act
            var vector = new Vector2D();

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
    }
}
