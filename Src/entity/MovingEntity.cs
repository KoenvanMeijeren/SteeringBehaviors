using Src.behavior;
using Src.util;
using Src.world;

namespace Src.entity
{

    public abstract class MovingEntity : BaseGameEntity, IMovingEntity
    {
        public const int MassDefault = 30, MaxSpeedDefault = 150;

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
            Vector acceleration = steeringForce.Divide(Mass);
            Velocity.Add(acceleration.Multiply(timeElapsed));
            Velocity.Truncate(MaxSpeed);
            CollisionHandler.AlterVectorToStayInsideOfWorld(Position, Velocity, World);
            CollisionHandler.AlterVectorToStayOutOfWalls(Position, Velocity, World.Grid);
            Position.Add(Velocity.Multiply(timeElapsed));

            // ToDo: Find out what the purpose is of this code.
            //update the heading if the vehicle has a velocity greater than a very small value
            //if (m_vVelocity.LengthSq() > 0.00000001)
            //{
            //    m_vHeading = Vec2DNormalize(m_vVelocity);
            //    m_vSide = m_vHeading.Perp();
            //} 

            //treat the screen as a toroid
            //WrapAround(m_vPos, m_pWorld->cxClient(), m_pWorld->cyClient());
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
