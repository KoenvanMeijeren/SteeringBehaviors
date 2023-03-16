using Src.behavior;
using Src.util;
using Src.world;

namespace Src.entity
{

    public abstract class MovingEntity : BaseGameEntity, IMovingEntity
    {
        public const int MassDefault = 30, MaxSpeedDefault = 150;

        public VectorImmutable Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }

        public ISteeringBehavior SteeringBehavior { get; private set; }

        protected MovingEntity(VectorImmutable position, IWorld world, float height, float width) : base(position, world, height, width)
        {
            Mass = MassDefault;
            MaxSpeed = MaxSpeedDefault;
            Velocity = new VectorImmutable(0, 0);
        }

        public void SetSteeringBehavior(ISteeringBehavior steeringBehavior)
        {
            SteeringBehavior = steeringBehavior;
        }

        public override void Update(float timeElapsed)
        {
            if (SteeringBehavior == null)
            {
                return;
            }

            VectorImmutable steeringForce = SteeringBehavior.Calculate();
            VectorImmutable acceleration = steeringForce / Mass;
            Velocity += acceleration * timeElapsed;
            Velocity.Truncate(MaxSpeed);
            Velocity = CollisionHandler.AlterVectorToStayInsideOfWorld(Position, Velocity, World);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.UpperLeftCorner, Velocity, World.Grid);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.UpperRightCorner, Velocity, World.Grid);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.LowerLeftCorner, Velocity, World.Grid);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.LowerRightCorner, Velocity, World.Grid);
            Velocity *= timeElapsed;
            Position += Velocity;
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
