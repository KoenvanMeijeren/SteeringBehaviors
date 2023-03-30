using SteeringCS.behavior;
using Visualization.behavior;
using Visualization.entity;

namespace Visualization.state
{
    public class FollowState : IState
    {
        public IMovingEntity MovingEntity { get; }

        public FollowState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.PathfindingBehavior, MovingEntity), null);
        }

        public void Execute()
        {
        }
    }
}
