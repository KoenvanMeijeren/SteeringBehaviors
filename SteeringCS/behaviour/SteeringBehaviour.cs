using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.behaviour
{
    public abstract class SteeringBehaviour
    {
        protected MovingEntity MovingEntity { get; }
        public abstract Vector2D Calculate();

        protected SteeringBehaviour(MovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }
    }

    
}
