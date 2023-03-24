using Src.behavior;
using Src.entity;
using System;

namespace Src.state
{
    public class LostState : IState
    {
        public IMovingEntity MovingEntity { get; }

        public LostState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorFactory.CreateFromEnum(
                SteeringBehaviorOptions.IdlingBehavior, MovingEntity, null));
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
