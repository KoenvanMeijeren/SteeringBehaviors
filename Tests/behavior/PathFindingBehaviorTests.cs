using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Tests.behavior.util;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class PathFindingBehaviorTests
    {
        [TestCase(100, 100, new float[] { 35, 35 }, new float[] { 75, 75 }, "(40,40)")]
        [TestCase(250, 250, new float[] { 50, 50 }, new float[] { 200, 200 }, "(30,30)")]
        public void Calculate_01_Ok(int width, int height, float[] seekingPositions, float[] targetPositions, string expectedResult)
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(seekingPositions[0], seekingPositions[1]);
            Vector targetEntityPosition = new Vector(targetPositions[0], targetPositions[1]);
            WorldTest world = new WorldTest(width, height, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new PathfindingBehavior(world.Rescuee);

            // Act
            Vector velocity = steeringBehavior.Calculate();

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
    }

    public class MovingEntityWithPathFindingBehaviorTests
    {
        [Test]
        public void TestWorldUpdate_01_CloseToWallOk()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(210, 210);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new PathfindingBehavior(world.Rescuee);
            ISteeringBehavior collisionBehavior = new CollisionAvoidingBehavior(world.Rescuee);
            IMovingEntity movingEntity = world.Rescuee;
            movingEntity.SetSteeringBehavior(steeringBehavior, collisionBehavior);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());

            world.Update(TimeElapsed);
            Assert.AreEqual("(37.4,37.4)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.4,2.4)", movingEntity.Velocity.ToString());

            world.Update(TimeElapsed);
            Assert.AreEqual("(40.18,40.18)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.78,2.78)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 19; index++)
            {
                world.Update(TimeElapsed);
            }

            world.Update(TimeElapsed);
            Assert.AreEqual("(98.41,98.41)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.29,2.29)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 100; index++)
            {
                world.Update(TimeElapsed);
            }

            Assert.AreEqual("(210,210)", movingEntity.Position.ToString());
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
            ISteeringBehavior steeringBehavior = new PathfindingBehavior(world.Rescuee);
            ISteeringBehavior collisionBehavior = new CollisionAvoidingBehavior(world.Rescuee);
            IMovingEntity movingEntity = world.Rescuee;
            movingEntity.SetSteeringBehavior(steeringBehavior, collisionBehavior);

            // Act & assert
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                0f,
                "(35,35)",
                "(45,45)",
                "(1.5,1.5)",
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
                "(45,45)",
                "(1.5,1.5)",
                "(1.2,1.2)",
                "(1.2,1.2)",
                "(1.2,1.2)",
                "(3,3)",
                "(3,3)",
                "(3,3)",
                "(3,3)",
                "(2.4,2.4)",
                "(37.4,37.4)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(37.4,37.4)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.4,2.4)", movingEntity.Velocity.ToString());

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(37.4,37.4)",
                "(40.2,40.2)",
                "(1.34,1.34)",
                "(3.47,3.47)",
                "(3.47,3.47)",
                "(3.47,3.47)",
                "(3.47,3.47)",
                "(3.47,3.47)",
                "(3.47,3.47)",
                "(3.47,3.47)",
                "(2.78,2.78)",
                "(40.18,40.18)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(40.18,40.18)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.78,2.78)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 40; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(157.9,157.9)",
                "(15.42,15.42)",
                "(0.51,0.51)",
                "(3.09,3.09)",
                "(3.09,3.09)",
                "(3.09,3.09)",
                "(3.09,3.09)",
                "(3.09,3.09)",
                "(3.09,3.09)",
                "(3.09,3.09)",
                "(2.47,2.47)",
                "(160.37,160.37)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(160.37,160.37)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.47,2.47)", movingEntity.Velocity.ToString());

            for (int index = 0; index < 100; index++)
            {
                world.Update(TimeElapsed);
            }

            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(200,200)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(-0,-0)",
                "(200,200)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(200,200)", movingEntity.Position.ToString());
            Assert.AreEqual("(-0,-0)", movingEntity.Velocity.ToString());
        }
    }
}
