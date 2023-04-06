using Src.behavior;
using Src.entity;
using Src.state;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class FollowState : IState
    {
        public IMovingEntity MovingEntity { get; }

        private const int _distanceFromFinish = 80;
        private const int _distanceFromNearestGoomba = 3;

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
            // FUZY LOGIC (change to scared if fuzzy logics says so)
            MovingEntity.ChangeState(new ScaredState(MovingEntity));
        }

        public override string ToString() => "Follow";
    }
}
