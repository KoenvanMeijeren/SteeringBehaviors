using System;
using SteeringCS.behaviour;
using SteeringCS.util;
using SteeringCS.world;

namespace SteeringCS.entity
{

    public abstract class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }

        public SteeringBehavior SteeringBehavior { get; set; }

        protected MovingEntity(Vector2D position, World world) : base(position, world)
        {
            Mass = 30;
            MaxSpeed = 150;
            Velocity = new Vector2D();
        }

        public override void Update(float timeElapsed)
        {
            if (SteeringBehavior == null)
            {
                return;
            }

            var steeringForce = SteeringBehavior.Calculate();
            var acceleration = steeringForce.Divide(Mass);
            Velocity.Add(acceleration.Multiply(timeElapsed));
            Velocity.Truncate(MaxSpeed);
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
            // TO DO
        }

        public void AddIdleBehavior()
        {
            SteeringBehavior = new IdleBehavior(this);
        }

        public void AddSteeringBehavior(SteeringBehaviorOptions steeringBehaviourOption)
        {
            switch (steeringBehaviourOption)
            {
                case SteeringBehaviorOptions.IdleBehavior:
                    {
                        AddIdleBehavior();
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
                default: break;
            }
        }

        public override string ToString()
        {
            return $"{Velocity}";
        }
    }
}
