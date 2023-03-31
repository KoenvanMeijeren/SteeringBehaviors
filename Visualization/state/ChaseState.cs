using Src.behavior;
using Src.entity;
using Src.state;
using SteeringCS.behavior;

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
            if (!(MovingEntity.SteeringBehavior is PathfindingBehaviorVisualizer pathfindingBehaviorVisualizer))
            {
                return;
            }

            if (pathfindingBehaviorVisualizer.Path.Count > _maxShortestPathDistance)
            {
                MovingEntity.ChangeState(new SearchState(MovingEntity));
            }
        }
    }
}
