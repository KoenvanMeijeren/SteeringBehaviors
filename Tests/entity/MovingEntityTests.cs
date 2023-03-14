using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Tests.fixtures.entity;
using Tests.fixtures.world;

namespace Tests.entity
{
    public class MovingEntityTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            SeekingBehavior steeringBehavior = new SeekingBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act & assert
            Assert.AreEqual("(0,0)", movingEntity.Velocity.ToString());
            Assert.AreEqual("(35,35)", movingEntity.Position.ToString());
            Assert.AreEqual("(0,0)", movingEntity.ToString());
            Assert.AreEqual(world, movingEntity.World);
            Assert.AreEqual(VehicleTest.DefaultWidth, movingEntity.Width);
            Assert.AreEqual(VehicleTest.DefaultHeight, movingEntity.Height);
            Assert.AreEqual("(30,40)", movingEntity.HitBox.LowerLeftCorner.ToString());
            Assert.AreEqual("(40,40)", movingEntity.HitBox.LowerRightCorner.ToString());
            Assert.AreEqual("(30,30)", movingEntity.HitBox.UpperLeftCorner.ToString());
            Assert.AreEqual("(40,30)", movingEntity.HitBox.UpperRightCorner.ToString());
            Assert.AreEqual(MovingEntity.MassDefault, movingEntity.Mass);
            Assert.AreEqual(MovingEntity.MaxSpeedDefault, movingEntity.MaxSpeed);
        }
        
        [Test]
        public void Update_01_Ok_ChangesVelocityAndPositionAfterUpdate()
        {
            // Arrange
            const float TimeElapsed = 0.800000012f;
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            SeekingBehavior steeringBehavior = new SeekingBehavior(world.SeekingEntity);
            IMovingEntity movingEntity = world.SeekingEntity;
            movingEntity.SetSteeringBehavior(steeringBehavior);

            // Act
            movingEntity.Update(TimeElapsed);
            
            // Assert
            Assert.AreEqual("(39.57,39.57)", movingEntity.Position.ToString());
            Assert.AreEqual("(4.57,4.57)", movingEntity.Velocity.ToString());
        }
        
        [Test]
        public void Update_02_Ok_DoesNotCrashWithoutSteeringBehavior()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            IMovingEntity movingEntity = world.SeekingEntity;

            // Act & assert
            movingEntity.Update(0f);
        }
    }
}
