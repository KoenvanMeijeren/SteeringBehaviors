using SteeringCS.behavior;
using Visualization.behavior;
using Visualization.entity;
using Visualization.state;

namespace SteeringCS.state
{
    public class ChaseState : IState
    {
        public IMovingEntity MovingEntity { get; }

        public ChaseState(IMovingEntity movingEntity)
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
