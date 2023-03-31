using SteeringCS.behavior;
using Visualization.behavior;
using Visualization.entity;
using Visualization.state;

namespace SteeringCS.state
{
    public class ChaseState : IState
    {
        public IMovingEntity MovingEntity { get; }
        private const int _maxShortestPathDistance = 3;

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
            if (MovingEntity.SteeringBehavior is PathfindingBehaviorVisualizer pathfindingBehaviorVisualizer)
            {
                if (pathfindingBehaviorVisualizer.Path.Count > _maxShortestPathDistance)
                {
                    MovingEntity.ChangeState(new SearchState(MovingEntity));
                }
            }
        }
    }
}
