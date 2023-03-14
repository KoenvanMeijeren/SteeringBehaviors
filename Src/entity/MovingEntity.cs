using Src.behavior;
using Src.util;
using Src.world;

namespace Src.entity
{

    public abstract class MovingEntity : BaseGameEntity, IMovingEntity
    {
        private const int MassDefault = 30, MaxSpeedDefault = 150;

        public Vector Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }

        public ISteeringBehavior SteeringBehavior { get; private set; }

        protected MovingEntity(Vector position, IWorld world, float height, float width) : base(position, world, height, width)
        {
            Mass = MassDefault;
            MaxSpeed = MaxSpeedDefault;
            Velocity = new Vector(0, 0);
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

            Vector steeringForce = SteeringBehavior.Calculate();
            if (steeringForce.ToString() == "(0,0)")
            {
                return;
            }
            
            Vector acceleration = steeringForce.Divide(Mass);
            Velocity.Add(acceleration.Multiply(timeElapsed));
            Velocity.Truncate(MaxSpeed);
            Velocity = CollisionHandler.AlterVectorToStayInsideOfWorld(Position, Velocity, World);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.UpperLeftCorner, Velocity, World.Grid);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.UpperRightCorner, Velocity, World.Grid);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.LowerLeftCorner, Velocity, World.Grid);
            Velocity = CollisionHandler.AlterVectorToStayOutOfWalls(Position, HitBox.LowerRightCorner, Velocity, World.Grid);
            Position.Add(Velocity.Multiply(timeElapsed));
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
