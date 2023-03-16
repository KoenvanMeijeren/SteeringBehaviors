using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Tests.behavior.util;
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

    public class MovingEntityWithArrivingBehaviorTests
    {
        [Test]
        public void TestWorldUpdate_01_CloseToWallOk()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new ArrivingBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());

            world.Update(TimeElapsed);
            Assert.AreEqual("(39.57,39.57)", movingEntity.Position.ToString());
            Assert.AreEqual("(4.57,4.57)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            world.Update(TimeElapsed);
            Assert.AreEqual("(175.2,175.2)", movingEntity.Position.ToString());
            Assert.AreEqual("(11.19,11.19)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 20; index++)
            {
                world.Update(TimeElapsed);
            }

            Assert.AreEqual("(220,220)", movingEntity.Position.ToString());
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
            ISteeringBehavior steeringBehavior = new ArrivingBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                0f,
                "(35,35)",
                "(165,165)",
                "(5.5,5.5)",
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

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(35,35)",
                "(165,165)",
                "(5.5,5.5)",
                "(4.4,4.4)",
                "(4.4,4.4)",
                "(4.4,4.4)",
                "(4.4,4.4)",
                "(4.4,4.4)",
                "(4.4,4.4)",
                "(4.4,4.4)",
                "(3.52,3.52)",
                "(38.52,38.52)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(38.52,38.52)", movingEntity.Position.ToString());
            Assert.AreEqual("(3.52,3.52)", movingEntity.Velocity.ToString());

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(38.52,38.52)",
                "(157.96,157.96)",
                "(5.27,5.27)",
                "(7.73,7.73)",
                "(7.73,7.73)",
                "(7.73,7.73)",
                "(7.73,7.73)",
                "(7.73,7.73)",
                "(7.73,7.73)",
                "(7.73,7.73)",
                "(6.19,6.19)",
                "(44.71,44.71)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(44.71,44.71)", movingEntity.Position.ToString());
            Assert.AreEqual("(6.19,6.19)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(143.1,143.1)",
                "(48.27,48.27)",
                "(1.61,1.61)",
                "(9.92,9.92)",
                "(9.92,9.92)",
                "(9.92,9.92)",
                "(9.92,9.92)",
                "(9.92,9.92)",
                "(9.92,9.92)",
                "(9.92,9.92)",
                "(7.93,7.93)",
                "(151.03,151.03)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(151.03,151.03)", movingEntity.Position.ToString());
            Assert.AreEqual("(7.93,7.93)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(195.14,195.14)",
                "(2.79,2.79)",
                "(0.09,0.09)",
                "(2.15,2.15)",
                "(2.15,2.15)",
                "(2.15,2.15)",
                "(2.15,2.15)",
                "(2.15,2.15)",
                "(2.15,2.15)",
                "(2.15,2.15)",
                "(1.72,1.72)",
                "(196.86,196.86)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(196.86,196.86)", movingEntity.Position.ToString());
            Assert.AreEqual("(1.72,1.72)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(202.33,202.33)",
                "(-2.34,-2.34)",
                "(-0.08,-0.08)",
                "(-0.06,-0.06)",
                "(-0.06,-0.06)",
                "(-0.06,-0.06)",
                "(-0.06,-0.06)",
                "(-0.06,-0.06)",
                "(-0.06,-0.06)",
                "(-0.06,-0.06)",
                "(-0.05,-0.05)",
                "(202.29,202.29)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(202.29,202.29)", movingEntity.Position.ToString());
            Assert.AreEqual("(-0.05,-0.05)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 49; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(199.99,199.99)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(0,0)",
                "(200,200)"
            );
            Assert.AreEqual("(199.99,199.99)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
        }
    }
}
