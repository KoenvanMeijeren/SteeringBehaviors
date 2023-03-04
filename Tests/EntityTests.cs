using System.Drawing;
using NUnit.Framework;
using Src.util;
using SteeringCS.entity;
using SteeringCS.world;

namespace SteeringCSTests
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
            World world = new World(WorldWidth, WorldHeight);

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
            const int XPosition = 0,
                YPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25,
                TimeElapsed = 10;

            const string ExpectedVelocity = "(200,133.33)",
                ExpectedPosition = "(200,133.33)";

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            World world = new World(WorldWidth, WorldHeight);

            // Act
            MovingEntityImplementation movingEntity = new MovingEntityImplementation(position, world);
            Vector previousVelocity = movingEntity.Velocity.Clone();
            Vector previousPosition = movingEntity.Position.Clone();
            movingEntity.AddSeekingBehavior();
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
            World world = new World(WorldWidth, WorldHeight);

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
            World world = new World(WorldWidth, WorldHeight);

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

            const float ExpectedScale = Vehicle.DefaultScale;

            // Arrange
            Vector position = new Vector(XPosition, YPosition);
            World world = new World(WorldWidth, WorldHeight);

            // Act
            Vehicle movingEntity = new Vehicle(position, world);

            // Assert
            Assert.AreEqual(ExpectedScale, movingEntity.Scale);
            Assert.AreEqual(world, movingEntity.World);
            Assert.AreEqual(Color.Black, movingEntity.Color);
        }
    }

    public class MovingEntityImplementation : MovingEntity
    {
        public MovingEntityImplementation(Vector position, World world) : base(position, world)
        {
        }
    }
}
