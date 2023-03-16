using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Tests.behavior.util;
using Tests.fixtures.world;

namespace Tests.behavior
{
    public class KeyBoardBehaviorTests
    {
        [TestCase(PressedKey.A, "(-20,0)")]
        [TestCase(PressedKey.W, "(0,-20)")]
        [TestCase(PressedKey.S, "(0,20)")]
        [TestCase(PressedKey.D, "(20,0)")]
        [TestCase(PressedKey.DoNothing, "(0,0)")]
        public void Calculate_01_SingleKeyPressed_Ok(PressedKey pressedKey, string expectedResult)
        {
            // Arrange
            KeyHandler.Reset();
            Vector seekingEntityPosition = new Vector(10, 10);
            Vector targetEntityPosition = new Vector(50, 50);
            WorldTest world = new WorldTest(500, 500, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new KeyboardBehavior(world.SeekingEntity);

            // Act
            KeyHandler.RegisterPressedKeys(pressedKey);
            Vector velocity = steeringBehavior.Calculate();
            KeyHandler.RegisterUnpressedKeys(pressedKey);

            // Assert
            Assert.AreEqual(expectedResult, velocity.ToString());
        }
    }

    public class MovingEntityWithKeyBoardBehaviorTests
    {
        [TestCase(PressedKey.A, "(37.4,37.4)", "(2.4,2.4)", "(38.89,39.32)", "(1.49,1.92)", "(44.87,47)")]
        [TestCase(PressedKey.W, "(37.4,37.4)", "(2.4,2.4)", "(39.32,38.89)", "(1.92,1.49)", "(47,44.87)")]
        [TestCase(PressedKey.S, "(37.4,37.4)", "(2.4,2.4)", "(39.32,39.75)", "(1.92,2.35)", "(47,49.13)")]
        [TestCase(PressedKey.D, "(37.4,37.4)", "(2.4,2.4)", "(39.75,39.32)", "(2.35,1.92)", "(49.13,47)")]
        [TestCase(PressedKey.DoNothing, "(35,35)", "(0,0)", "(35,35)", "(0,0)", "(35,35)")]
        public void TestWorldUpdate_01_SingleKeyPressed_Ok(PressedKey pressedKey, string expectedPosition1, string expectedVelocity1, string expectedPosition2, string expectedVelocity2, string expectedPosition3)
        {
            // Arrange
            KeyHandler.Reset();
            
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new KeyboardBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);
            
            
            // Act & assert
            KeyHandler.RegisterPressedKeys(pressedKey);
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());

            world.Update(TimeElapsed);
            Assert.AreEqual(expectedPosition1, movingEntity.Position.ToString());
            Assert.AreEqual(expectedVelocity1, movingEntity.Velocity.ToString());
            
            world.Update(TimeElapsed);
            Assert.AreEqual(expectedPosition2, movingEntity.Position.ToString());
            Assert.AreEqual(expectedVelocity2, movingEntity.Velocity.ToString());
            
            KeyHandler.RegisterUnpressedKeys(pressedKey);

            for (int index = 0; index < 37; index++)
            {
                world.Update(TimeElapsed);
            }

            Assert.AreEqual(expectedPosition3, movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());

        }

        [Test]
        public void TestWorldUpdate_02_SingleKeyPressed_ThoroughlyOk()
        {
            // Mocked values
            const PressedKey PressedKey = PressedKey.D;
            const float TimeElapsed = 0.800000012f;
            
            // Arrange
            KeyHandler.Reset();
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(200, 200);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            ISteeringBehavior steeringBehavior = new KeyboardBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey);
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                0f,
                "(35,35)",
                "(20,0)",
                "(0.67,0)",
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
                "(20,0)",
                "(0.67,0)",
                "(0.53,0)",
                "(0.53,0)",
                "(0.53,0)",
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
                "(20,0)",
                "(0.67,0)",
                "(2.93,2.4)",
                "(2.93,2.4)",
                "(2.93,2.4)",
                "(2.93,2.4)",
                "(2.93,2.4)",
                "(2.93,2.4)",
                "(2.93,2.4)",
                "(2.35,1.92)",
                "(39.75,39.32)"
            );
            world.Update(TimeElapsed);
            Assert.AreEqual("(39.75,39.32)", movingEntity.Position.ToString());
            Assert.AreEqual("(2.35,1.92)", movingEntity.Velocity.ToString());
            
            KeyHandler.RegisterUnpressedKeys(PressedKey);
            for (int index = 0; index < 37; index++)
            {
                world.Update(TimeElapsed);
            }
            
            BehaviorTestUtil.AssertMovingEntityWithSteeringBehavior(
                movingEntity,
                steeringBehavior,
                TimeElapsed,
                "(49.13,47)",
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
                "(49.13,47)"
            );
            Assert.AreEqual("(49.13,47)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
        }
    }
}
