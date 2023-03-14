using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Tests.behavior.util;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class IdlingBehaviorTests
    {
        [TestCase(20, 20, new float[] { 1, 1 }, new float[] { 18, 18 }, "(0,0)")]
        [TestCase(20, 20, new float[] { 5, 5 }, new float[] { 18, 18 }, "(0,0)")]
        [TestCase(20, 20, new float[] { 5, 5 }, new float[] { 10, 10 }, "(0,0)")]
        [TestCase(500, 500, new float[] { 5, 5 }, new float[] { 450, 10 }, "(0,0)")]
        public void Calculate_01_Ok(int width, int height, float[] seekingPositions, float[] targetPositions, string expectedResult)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(seekingPositions[0], seekingPositions[1]);
            Vector targetEntityPosition = new Vector(targetPositions[0], targetPositions[1]);
            WorldTest world = new WorldTest(width, height, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new IdlingBehavior(world.SeekingEntity);

            // Act
            Vector velocity = steeringBehavior.Calculate();

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }

        [TestCase(10, 10, new float[] { 5, 5 }, new float[] { 450, 450 }, "(0,0)")]
        public void Calculate_01_OkOnPositionOutOfWorld(int width, int height, float[] seekingPositions, float[] targetPositions, string expectedResult)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(seekingPositions[0], seekingPositions[1]);
            Vector targetEntityPosition = new Vector(targetPositions[0], targetPositions[1]);
            WorldTest world = new WorldTest(width, height, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new IdlingBehavior(world.SeekingEntity);

            // Act
            Vector velocity = steeringBehavior.Calculate();

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
    }

    public class MovingEntityWithIdlingBehaviorTests
    {
        [Test]
        public void TestWorldUpdate_01_Ok()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new IdlingBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 100; index++)
            {
                world.Update(TimeElapsed);
            }

            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
        }

        [Test]
        public void TestWorldUpdate_02_ThoroughlyOk()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(200, 200);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new IdlingBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            BehaviorTestUtil.AssertMovingEntityWithSeekingBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(35,35)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(35,35)"
            );

            for (int index = 0; index < 100; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSeekingBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(35,35)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(35,35)"
            );
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
        }
    }
}
