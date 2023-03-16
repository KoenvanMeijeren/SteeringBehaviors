using NUnit.Framework;
using Src.behavior;
using Src.entity;
using Src.util;

namespace Tests.behavior.util
{
    public static class BehaviorTestUtil
    {
        public static void AssertMovingEntityWithSteeringBehavior(
            IMovingEntity movingEntity,
            ISteeringBehavior steeringBehavior,
            float timeElapsed,
            string expectedPositionBeforeVelocityAddition,
            string expectedSteeringForce,
            string expectedAcceleration,
            string expectedVelocityAfterAccelerationAddition,
            string expectedVelocityAfterTruncate,
            string expectedVelocityAfterKeepVectorInWorldAlter,
            string expectedVelocityAfterAlterVectorToStayOutOfWallsUpperLeftCorner,
            string expectedVelocityAfterAlterVectorToStayOutOfWallsUpperRightCorner,
            string expectedVelocityAfterAlterVectorToStayOutOfWallsLowerLeftCorner,
            string expectedVelocityAfterAlterVectorToStayOutOfWallsLowerRightCorner,
            string expectedVelocityAfterTimeElapsedMultiply,
            string expectedPositionAfterVelocityAddition
        )
        {
            Vector position = movingEntity.Position;
            Vector velocity = movingEntity.Velocity;
            Assert.AreEqual(expectedPositionBeforeVelocityAddition, position.ToString());

            Vector steeringForce = steeringBehavior.Calculate();
            Assert.AreEqual(expectedSteeringForce, steeringForce.ToString());

            Vector acceleration = steeringForce / movingEntity.Mass;
            Assert.AreEqual(expectedAcceleration, acceleration.ToString());

            velocity += acceleration * timeElapsed;
            Assert.AreEqual(expectedVelocityAfterAccelerationAddition, velocity.ToString());

            velocity.Truncate(movingEntity.MaxSpeed);
            Assert.AreEqual(expectedVelocityAfterTruncate, velocity.ToString());

            velocity = CollisionHandler.AlterVectorToStayInsideOfWorld(position, velocity, movingEntity.World);
            Assert.AreEqual(expectedVelocityAfterKeepVectorInWorldAlter, velocity.ToString());

            velocity = CollisionHandler.AlterVectorToStayOutOfWalls(position, movingEntity.HitBox.UpperLeftCorner, velocity, movingEntity.World.Grid);
            Assert.AreEqual(expectedVelocityAfterAlterVectorToStayOutOfWallsUpperLeftCorner, velocity.ToString());

            velocity = CollisionHandler.AlterVectorToStayOutOfWalls(position, movingEntity.HitBox.UpperRightCorner, velocity, movingEntity.World.Grid);
            Assert.AreEqual(expectedVelocityAfterAlterVectorToStayOutOfWallsUpperRightCorner, velocity.ToString());

            velocity = CollisionHandler.AlterVectorToStayOutOfWalls(position, movingEntity.HitBox.LowerLeftCorner, velocity, movingEntity.World.Grid);
            Assert.AreEqual(expectedVelocityAfterAlterVectorToStayOutOfWallsLowerLeftCorner, velocity.ToString());

            velocity = CollisionHandler.AlterVectorToStayOutOfWalls(position, movingEntity.HitBox.LowerRightCorner, velocity, movingEntity.World.Grid);
            Assert.AreEqual(expectedVelocityAfterAlterVectorToStayOutOfWallsLowerRightCorner, velocity.ToString());

            velocity *= timeElapsed;
            Assert.AreEqual(expectedVelocityAfterTimeElapsedMultiply, velocity.ToString());
            
            position += velocity;
            Assert.AreEqual(expectedPositionAfterVelocityAddition, position.ToString());
        }
    }
}
