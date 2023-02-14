using System.Drawing;
using NUnit.Framework;
using SteeringCS.behaviour;
using SteeringCS.entity;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCSTests
{
    public class MovingEntityTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0,
                NorthPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25;
            const string ExpectedString = "(0,0)";

            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);

            // Act
            var movingEntity = new MovingEntityImplementation(position, world);

            // Assert
            Assert.AreEqual(MovingEntity.MassDefault, movingEntity.Mass);
            Assert.AreEqual(MovingEntity.MaxSpeedDefault, movingEntity.MaxSpeed);
            Assert.AreEqual(EastPosition, movingEntity.Velocity.EastPosition);
            Assert.AreEqual(NorthPosition, movingEntity.Velocity.NorthPosition);
            Assert.IsNull(movingEntity.SteeringBehaviour);
            Assert.AreEqual(ExpectedString, movingEntity.ToString());
        }

        [Test]
        public void Calculate_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0,
                NorthPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25,
                TimeElapsed = 10;

            const string ExpectedVelocity = "(333.33,133.33)",
                ExpectedPosition = "(333.33,133.33)";

            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);

            // Act
            var movingEntity = new MovingEntityImplementation(position, world);
            var previousVelocity = movingEntity.Velocity.Clone();
            var previousPosition = movingEntity.Position.Clone();
            var seekingBehaviour = new SeekBehaviour(movingEntity);
            movingEntity.SteeringBehaviour = seekingBehaviour;
            movingEntity.Update(TimeElapsed);

            // Assert
            Assert.AreNotEqual(previousVelocity.ToString(), movingEntity.Velocity.ToString());
            Assert.AreNotEqual(previousPosition.ToString(), movingEntity.Position.ToString());
            Assert.AreEqual(ExpectedVelocity, movingEntity.Velocity.ToString());
            Assert.AreEqual(ExpectedPosition, movingEntity.Position.ToString());
        }

        [Test]
        public void Calculate_02_DoesNotChangeWithoutSteeringBehaviour_Ok()
        {
            // Mocked values
            const int EastPosition = 0,
                NorthPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25,
                TimeElapsed = 10;

            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);

            // Act
            var movingEntity = new MovingEntityImplementation(position, world);
            var previousVelocity = movingEntity.Velocity.Clone();
            var previousPosition = movingEntity.Position.Clone();
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
            const int EastPosition = 0,
                NorthPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25;

            const float ExpectedScale = 0;

            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);

            // Act
            var movingEntity = new MovingEntityImplementation(position, world);

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
            const int EastPosition = 0,
                NorthPosition = 0,
                WorldWidth = 20,
                WorldHeight = 25;

            const float ExpectedScale = Vehicle.DefaultScale;

            // Arrange
            var position = new Vector2D(EastPosition, NorthPosition);
            var world = new World(WorldWidth, WorldHeight);

            // Act
            var movingEntity = new Vehicle(position, world);

            // Assert
            Assert.AreEqual(ExpectedScale, movingEntity.Scale);
            Assert.AreEqual(world, movingEntity.World);
            Assert.AreEqual(Color.Black, movingEntity.Color);
        }
    }

    public class MovingEntityImplementation : MovingEntity
    {
        public MovingEntityImplementation(Vector2D position, World world) : base(position, world)
        {
        }
    }
}
