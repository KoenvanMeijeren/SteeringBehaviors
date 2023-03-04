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

        protected MovingEntity(Vector position, IWorld world) : base(position, world)
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
            AlterVectorToStayInsideOfWorld(Velocity);
            AlterVectorToStayOutOfWalls(Velocity);
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

        public void AlterVectorToStayInsideOfWorld(Vector vector)
        {
            Vector position = Position.Clone();
            Vector targetPosition = position.Add(vector);

            int maxY = World.Height;
            int maxX = World.Width;

            if (targetPosition.Y < 0)
            {
                vector.SubtractY(targetPosition.Y);
            }

            if (targetPosition.X < 0)
            {
                vector.SubtractX(targetPosition.X);
            }

            if (targetPosition.Y > maxY)
            {
                vector.SubtractY(targetPosition.Y - maxY);
            }

            if (targetPosition.X > maxX)
            {
                vector.SubtractX(targetPosition.X - maxX);
            }
        }

        public void AlterVectorToStayOutOfWalls(Vector vector)
        {
            Vector position = Position.Clone();

            World.Grid.AlterVectorToStayOutOfWalls(position, vector);
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
