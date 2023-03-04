using Src.behavior;
using Src.entity;
using SteeringCS.behavior;
using Src.util;
using Src.world;
using SteeringCS.world;

namespace SteeringCS.entity
{

    public abstract class MovingEntity : BaseGameEntity, IMovingEntity
    {
        public const int MassDefault = 30, MaxSpeedDefault = 150;

        public Vector Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }

        public ISteeringBehaviorVisualizer SteeringBehaviorVisualizer { get; private set; }

        protected MovingEntity(Vector position, IWorld world) : base(position, world)
        {
            Mass = MassDefault;
            MaxSpeed = MaxSpeedDefault;
            Velocity = new Vector(0, 0);
        }

        public override void Update(float timeElapsed)
        {
            if (SteeringBehaviorVisualizer == null)
            {
                return;
            }

            Vector steeringForce = SteeringBehaviorVisualizer.Calculate();
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

        public void SetSeekingBehavior()
        {
            SteeringBehaviorVisualizer = new SeekingBehaviorVisualizer(this);
        }

        public void SetFleeingBehavior()
        {
            SteeringBehaviorVisualizer = new FleeingBehaviorVisualizer(this);
        }

        public void SetMosquitoBehavior()
        {
            SteeringBehaviorVisualizer = new MosquitoBehaviorVisualizer(this);
        }

        public void SetIdlingBehavior()
        {
            SteeringBehaviorVisualizer = new IdlingBehaviorVisualizer(this);
        }

        public void SetWanderingBehavior()
        {
            SteeringBehaviorVisualizer = new WanderingBehaviorVisualizer(this);
        }

        public void SetSteeringBehavior(SteeringBehaviorOptions steeringBehaviorOption)
        {
            switch (steeringBehaviorOption)
            {
                case SteeringBehaviorOptions.IdlingBehavior:
                    {
                        SetIdlingBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.SeekingBehavior:
                    {
                        SetSeekingBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.FleeingBehavior:
                    {
                        SetFleeingBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.MosquitoBehavior:
                    {
                        SetMosquitoBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.WanderingBehavior:
                    {
                        SetWanderingBehavior();
                        break;
                    }
                default: break;
            }
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
