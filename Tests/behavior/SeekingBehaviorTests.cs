using NUnit.Framework;
using Visualization.behavior;
using Visualization.entity;
using Visualization.util;
using Tests.behavior.util;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class SeekingBehaviorTests
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
            SeekingBehavior steeringBehavior = new SeekingBehavior(world.Rescuee, false);

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
            SeekingBehavior steeringBehavior = new SeekingBehavior(world.Rescuee, false);

            // Act
            Vector velocity = steeringBehavior.Calculate();

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
    }

    public class MovingEntityWithSeekingBehaviorTests
    {
        [Test]
        public void TestWorldUpdate_01_CloseToWallOk()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            SeekingBehavior steeringBehavior = new SeekingBehavior(world.Rescuee);
            IMovingEntity movingEntity = world.Rescuee;
            movingEntity.SetSteeringBehavior(steeringBehavior, null);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(35,35)", steeringBehavior.GetEntityPosition().ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            Assert.AreEqual("(0,0)", steeringBehavior.GetEntityVelocity().ToString());

            world.Update(TimeElapsed);
            Assert.AreEqual("(39.57,39.57)", movingEntity.Position.ToString());
            Assert.AreEqual("(39.57,39.57)", steeringBehavior.GetEntityPosition().ToString());
            Assert.AreEqual("(4.57,4.57)", movingEntity.Velocity.ToString());
            Assert.AreEqual("(4.57,4.57)", steeringBehavior.GetEntityVelocity().ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            world.Update(TimeElapsed);
            Assert.AreEqual("(179.32,179.32)", movingEntity.Position.ToString());
            Assert.AreEqual("(179.32,179.32)", steeringBehavior.GetEntityPosition().ToString());
            Assert.AreEqual("(11.17,11.17)", movingEntity.Velocity.ToString());
            Assert.AreEqual("(11.17,11.17)", steeringBehavior.GetEntityVelocity().ToString());

            for (int index = 0; index < 20; index++)
            {
                world.Update(TimeElapsed);
            }

            Assert.AreEqual("(220,220)", movingEntity.Position.ToString());
            Assert.AreEqual("(220,220)", steeringBehavior.GetEntityPosition().ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            Assert.AreEqual("(0,0)", steeringBehavior.GetEntityVelocity().ToString());
        }

        [Test]
        public void TestWorldUpdate_02_ThoroughlyOk()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(200, 200);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            SeekingBehavior steeringBehavior = new SeekingBehavior(world.Rescuee);
            IMovingEntity movingEntity = world.Rescuee;
            movingEntity.SetSteeringBehavior(steeringBehavior, null);

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
                "(161.48,161.48)",
                "(5.38,5.38)",
                "(7.83,7.83)",
                "(7.83,7.83)",
                "(7.83,7.83)",
                "(7.83,7.83)",
                "(7.83,7.83)",
                "(7.83,7.83)",
                "(7.83,7.83)",
                "(6.26,6.26)",
                "(44.78,44.78)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(44.78,44.78)", movingEntity.Position.ToString());
            Assert.AreEqual("(6.26,6.26)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(144.19,144.19)",
                "(47.22,47.22)",
                "(1.57,1.57)",
                "(9.84,9.84)",
                "(9.84,9.84)",
                "(9.84,9.84)",
                "(9.84,9.84)",
                "(9.84,9.84)",
                "(9.84,9.84)",
                "(9.84,9.84)",
                "(7.87,7.87)",
                "(152.07,152.07)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(152.07,152.07)", movingEntity.Position.ToString());
            Assert.AreEqual("(7.87,7.87)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(195.47,195.47)",
                "(2.51,2.51)",
                "(0.08,0.08)",
                "(2.09,2.09)",
                "(2.09,2.09)",
                "(2.09,2.09)",
                "(2.09,2.09)",
                "(2.09,2.09)",
                "(2.09,2.09)",
                "(2.09,2.09)",
                "(1.67,1.67)",
                "(197.14,197.14)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(197.14,197.14)", movingEntity.Position.ToString());
            Assert.AreEqual("(1.67,1.67)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 10; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(202.35,202.35)",
                "(-2.35,-2.35)",
                "(-0.08,-0.08)",
                "(-0.07,-0.07)",
                "(-0.07,-0.07)",
                "(-0.07,-0.07)",
                "(-0.07,-0.07)",
                "(-0.07,-0.07)",
                "(-0.07,-0.07)",
                "(-0.07,-0.07)",
                "(-0.06,-0.06)",
                "(202.3,202.3)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(202.3,202.3)", movingEntity.Position.ToString());
            Assert.AreEqual("(-0.06,-0.06)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 50; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(200,200)",
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
            Assert.AreEqual("(200,200)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
        }
    }
}
