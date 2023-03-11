using NUnit.Framework;
using Src.behavior;
using Src.util;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class ArrivingBehaviorTests
    {
        [TestCase(20, 20, new float[] { 1, 1 }, new float[] { 18, 18 }, "(17,17)")]
        [TestCase(20, 20, new float[] { 5, 5 }, new float[] { 18, 18 }, "(13,13)")]
        [TestCase(20, 20, new float[] { 5, 5 }, new float[] { 10, 10 }, "(5,5)")]
        [TestCase(500, 500, new float[] { 5, 5 }, new float[] { 450, 10 }, "(445,5)")]
        public void Calculate_01_Ok(int width, int height, float[] seekingPositions, float[] targetPositions, string expectedResult)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(seekingPositions[0], seekingPositions[1]);
            Vector targetEntityPosition = new Vector(targetPositions[0], targetPositions[1]);
            WorldTest world = new WorldTest(width, height, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new ArrivingBehavior(world.SeekingEntity);

            // Act
            Vector velocity = steeringBehavior.Calculate();

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
        
        [TestCase(10, 10, new float[] { 5, 5 }, new float[] { 450, 450 }, "(445,445)")]
        public void Calculate_01_OkOnPositionOutOfWorld(int width, int height, float[] seekingPositions, float[] targetPositions, string expectedResult)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(seekingPositions[0], seekingPositions[1]);
            Vector targetEntityPosition = new Vector(targetPositions[0], targetPositions[1]);
            WorldTest world = new WorldTest(width, height, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new ArrivingBehavior(world.SeekingEntity);

            // Act
            Vector velocity = steeringBehavior.Calculate();
            
            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
    }
}
