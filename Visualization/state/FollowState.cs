using Src.behavior;
using Src.entity;
using Src.fuzzy_logic;
using Src.state;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class FollowState : IState
    {
        public IMovingEntity MovingEntity { get; }

        private readonly FuzzyLogicFollowOrScareModule _fuzzyModule;

        public FollowState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
            _fuzzyModule = new FuzzyLogicFollowOrScareModule(MovingEntity);
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.PathfindingBehavior, MovingEntity), null);
        }

        public void Execute()
        {
            if (!_fuzzyModule.ShouldFollowPlayer())
            {
                MovingEntity.ChangeState(new ScaredState(MovingEntity));
            }
        }

        public override string ToString() => "Follow";
    }
}
