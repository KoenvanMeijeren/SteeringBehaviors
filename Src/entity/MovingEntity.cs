using Src.behavior;
using Src.state;
using Src.util;
using Src.world;

namespace Src.entity
{

    public abstract class MovingEntity : IMovingEntity
    {
        public const int MassDefault = 30, MaxSpeedDefault = 150;
        public IWorld World { get; }
        public float Height { get; }
        public float Width { get; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        public HitBox HitBox { get; }
        public Vector Position { get; set; }
        public Vector Velocity { get; protected set; }

        public bool IsDirectionLeft { get; protected set; }
        public bool IsDirectionRight { get; protected set; }
        public bool IsDirectionUpwards { get; protected set; }
        public bool IsDirectionDownwards { get; protected set; }

        public ISteeringBehavior SteeringBehavior { get; private set; }
        public ISteeringBehavior CollisionAvoidingBehavior { get; private set; }
        public IState State { get; protected set; }

        protected MovingEntity(Vector position, IWorld world, float height, float width)
        {
            Position = position;
            World = world;
            Height = height;
            Width = width;
            HitBox = new HitBox(this);
            Mass = MassDefault;
            MaxSpeed = MaxSpeedDefault;
            Velocity = new Vector(0, 0);
        }

        public void SetSteeringBehavior(ISteeringBehavior steeringBehavior, ISteeringBehavior collisionAvoidingBehavior)
        {
            SteeringBehavior = steeringBehavior;
            CollisionAvoidingBehavior = collisionAvoidingBehavior;
        }

        public void ChangeState(IState state)
        {
            State = state;
            State.Enter();
        }

        public void Update(float timeElapsed)
        {
            State?.Execute();

            if (SteeringBehavior == null)
            {
                return;
            }

            Vector steeringForce = SteeringBehavior.Calculate();
            if (CollisionAvoidingBehavior != null && SteeringBehavior.ShouldAvoidObstacles())
            {
                steeringForce += CollisionAvoidingBehavior.Calculate();
            }

            Vector acceleration = steeringForce / Mass;
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
