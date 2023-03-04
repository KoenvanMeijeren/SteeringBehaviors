using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;
using Src.world;
using Tests.fixtures.entity;
using Tests.fixtures.world;

namespace Tests
{
    public class MovingEntityTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Mocked values
            const int XPosition = 0,
                YPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25;
            const string ExpectedString = "(0,0)";

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            WorldTest world = new WorldTest(WorldWidth, WorldHeight);

            // Act
            MovingEntityImplementation movingEntity = new MovingEntityImplementation(position, world);

            // Assert
            Assert.AreEqual(MovingEntity.MassDefault, movingEntity.Mass);
            Assert.AreEqual(MovingEntity.MaxSpeedDefault, movingEntity.MaxSpeed);
            Assert.AreEqual(XPosition, movingEntity.Velocity.X);
            Assert.AreEqual(YPosition, movingEntity.Velocity.Y);
            Assert.IsNull(movingEntity.SteeringBehavior);
            Assert.AreEqual(ExpectedString, movingEntity.ToString());
        }

        [Test]
        public void Calculate_01_Ok()
        {
            // Mocked values
            const int XPosition = 50,
                YPosition = 50,
                WorldWidth = 600,
                WorldHeight = 600,
                TimeElapsed = 10;

            const string ExpectedVelocity = "(-33.33,33.33)",
                ExpectedPosition = "(16.67,83.33)";

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            WorldTest world = new WorldTest(WorldWidth, WorldHeight);

            // Act
            MovingEntityImplementation movingEntity = new MovingEntityImplementation(position, world);
            movingEntity.SetSteeringBehavior(new SeekingBehavior(movingEntity));
            Vector previousVelocity = movingEntity.Velocity.Clone();
            Vector previousPosition = movingEntity.Position.Clone();
            movingEntity.Update(TimeElapsed);

            // Assert
            Assert.AreNotEqual(previousVelocity.ToString(), movingEntity.Velocity.ToString());
            Assert.AreNotEqual(previousPosition.ToString(), movingEntity.Position.ToString());
            Assert.AreEqual(ExpectedVelocity, movingEntity.Velocity.ToString());
            Assert.AreEqual(ExpectedPosition, movingEntity.Position.ToString());
        }

        [Test]
        public void Calculate_02_DoesNotChangeWithoutSteeringBehavior_Ok()
        {
            // Mocked values
            const int XPosition = 0,
                YPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25,
                TimeElapsed = 10;

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            WorldTest world = new WorldTest(WorldWidth, WorldHeight);

            // Act
            MovingEntityImplementation movingEntity = new MovingEntityImplementation(position, world);
            Vector previousVelocity = movingEntity.Velocity.Clone();
            Vector previousPosition = movingEntity.Position.Clone();
            movingEntity.Update(TimeElapsed);

            // Assert
            Assert.AreEqual(previousVelocity.ToString(), movingEntity.Velocity.ToString());
            Assert.AreEqual(previousPosition.ToString(), movingEntity.Position.ToString());
        }
    }

    public class BaseGameEntityTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Mocked values
            const int XPosition = 0,
                YPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25;

            const float ExpectedScale = 0;

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            WorldTest world = new WorldTest(WorldWidth, WorldHeight);

            // Act
            MovingEntityImplementation movingEntity = new MovingEntityImplementation(position, world);

            // Assert
            Assert.AreEqual(ExpectedScale, movingEntity.Scale);
            Assert.AreEqual(world, movingEntity.World);
        }
    }

    public class VehicleTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Mocked values
            const int XPosition = 0,
                YPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25;

            const float ExpectedScale = VehicleTest.DefaultScale;

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            WorldTest world = new WorldTest(WorldWidth, WorldHeight);

            // Act
            VehicleTest movingEntity = new VehicleTest(position, world);

            // Assert
            Assert.AreEqual(ExpectedScale, movingEntity.Scale);
            Assert.AreEqual(world, movingEntity.World);
        }
    }

    public class MovingEntityImplementation : MovingEntity
    {
        public MovingEntityImplementation(Vector position, IWorld world) : base(position, world)
        {
        }
    }
}
