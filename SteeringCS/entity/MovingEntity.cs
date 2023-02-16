using System;
using SteeringCS.behavior;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCS.entity
{

    public abstract class MovingEntity : BaseGameEntity
    {
        public const int MassDefault = 30,
            MaxSpeedDefault = 150;

        public Vector2D Velocity { get; protected set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }

        public SteeringBehavior SteeringBehavior { get; private set; }

        protected MovingEntity(Vector2D position, World world) : base(position, world)
        {
            Mass = MassDefault;
            MaxSpeed = MaxSpeedDefault;
            Velocity = new Vector2D();
        }

        public override void Update(float timeElapsed)
        {
            if (SteeringBehavior == null)
            {
                return;
            }

            Vector2D steeringForce = SteeringBehavior.Calculate();
            Vector2D acceleration = steeringForce.Divide(Mass);
            Velocity.Add(acceleration.Multiply(timeElapsed));
            Velocity.Truncate(MaxSpeed);
            AlterVectorToStayInsideOfWorld(Velocity);
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

            Console.WriteLine(ToString());
        }

        public void AddSeekingBehavior()
        {
            SteeringBehavior = new SeekingBehavior(this);
        }

        public void AddFleeingBehavior()
        {
            SteeringBehavior = new FleeingBehavior(this);
        }

        public void AddMosquitoBehavior()
        {
            SteeringBehavior = new MosquitoBehavior(this);
        }

        public void AddIdlingBehavior()
        {
            SteeringBehavior = new IdlingBehavior(this);
        }

        public void AddWanderingBehavior()
        {
            SteeringBehavior = new WanderingBehavior(this);
        }

        public void AddSteeringBehavior(SteeringBehaviorOptions steeringBehaviorOption)
        {
            switch (steeringBehaviorOption)
            {
                case SteeringBehaviorOptions.IdlingBehavior:
                    {
                        AddIdlingBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.SeekingBehavior:
                    {
                        AddSeekingBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.FleeingBehavior:
                    {
                        AddFleeingBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.MosquitoBehavior:
                    {
                        AddMosquitoBehavior();
                        break;
                    }
                case SteeringBehaviorOptions.WanderingBehavior:
                    {
                        AddWanderingBehavior();
                        break;
                    }
                default: break;
            }
        }

        public Vector2D AlterVectorToStayInsideOfWorld(Vector2D vector)
        {
            Vector2D position = Position.Clone();
            Vector2D targetPosition = position.Add(vector);

            int maxY = World.Height;
            int maxX = World.Width;

            if (targetPosition.YPosition < 0)
            {
                vector.SubtractY(targetPosition.YPosition);
            }

            if (targetPosition.XPosition < 0)
            {
                vector.SubtractX(targetPosition.XPosition);
            }

            if (targetPosition.YPosition > maxY)
            {
                vector.SubtractY(targetPosition.YPosition - maxY);
            }

            if (targetPosition.XPosition > maxX)
            {
                vector.SubtractX(targetPosition.XPosition - maxX);
            }

            return vector;
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
