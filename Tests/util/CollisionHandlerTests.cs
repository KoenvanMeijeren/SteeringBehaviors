using NUnit.Framework;
using Src.util;
using Tests.fixtures.world;

namespace Tests.util
{
    public class CollisionHandlerTests
    {
        [TestCase(249, 249, 0, 20, "(0,1)", "(249,250)")]
        [TestCase(249, 249, 20, 0, "(1,0)", "(250,249)")]
        [TestCase(1, 1, 0, -20, "(0,-1)", "(1,0)")]
        [TestCase(1, 1, -20, 0, "(-1,0)", "(0,1)")]
        public void AlterVectorToStayInsideOfWorld_01_Ok(double startPositionX, double startPositionY, double addVelocityX, double addVelocityY, string expectedNewVelocity, string expectedMaximumPosition)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            Vector position = new Vector(startPositionX, startPositionY);
            Vector velocity = world.Rescuee.Velocity + new Vector(addVelocityX, addVelocityY);

            // Act
            Vector newVelocity = CollisionHandler.AlterVectorToStayInsideOfWorld(position, velocity, world);
            Vector maximumPosition = position + newVelocity;

            // Assert
            Assert.AreNotEqual(velocity.ToString(), newVelocity.ToString());
            Assert.AreEqual(expectedNewVelocity, newVelocity.ToString());
            Assert.AreEqual(expectedMaximumPosition, maximumPosition.ToString());
        }
    }
}
