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
            string expectedPositionAfterVelocityAddition
        )
        {
            VectorImmutable position = movingEntity.Position;
            VectorImmutable velocity = movingEntity.Velocity;
            Assert.AreEqual(expectedPositionBeforeVelocityAddition, position.ToString());

            VectorImmutable steeringForce = steeringBehavior.Calculate();
            Assert.AreEqual(expectedSteeringForce, steeringForce.ToString());

            VectorImmutable acceleration = steeringForce / movingEntity.Mass;
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

            // @todo: add an extra assert for this calculation
            position += velocity * timeElapsed;
            Assert.AreEqual(expectedPositionAfterVelocityAddition, position.ToString());
        }
    }
}
