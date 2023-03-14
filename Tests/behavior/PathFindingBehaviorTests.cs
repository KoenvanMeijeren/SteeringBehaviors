using NUnit.Framework;
using Src.behavior;
using Src.util;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class PathFindingBehaviorTests
    {
        [TestCase(20, 20, new float[] { 1, 1 }, new float[] { 18, 18 }, "(0,0)")]
        [TestCase(100, 100, new float[] { 35, 35 }, new float[] { 75, 75 }, "(45,45)")]
        [TestCase(250, 250, new float[] { 50, 50 }, new float[] { 200, 200 }, "(30,30)")]
        public void Calculate_01_Ok(int width, int height, float[] seekingPositions, float[] targetPositions, string expectedResult)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(seekingPositions[0], seekingPositions[1]);
            Vector targetEntityPosition = new Vector(targetPositions[0], targetPositions[1]);
            WorldTest world = new WorldTest(width, height, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new PathfindingBehavior(world.SeekingEntity);

            // Act
            Vector velocity = steeringBehavior.Calculate();

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
    }
}
