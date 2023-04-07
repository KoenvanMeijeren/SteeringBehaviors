using Src.behavior;
using Src.entity;
using Src.fuzzy_logic;
using Src.state;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class ScaredState : IState
    {
        private const int MaximumDistanceBetweenPlayerToBeScared = 150;
        public IMovingEntity MovingEntity { get; }

        private readonly FuzzyLogicFollowOrScareModule _fuzzyModule;

        public ScaredState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
            _fuzzyModule = new FuzzyLogicFollowOrScareModule(MovingEntity);
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.IdlingBehavior, MovingEntity), null);
        }

        public void Execute()
        {
            double distanceToPlayer = MovingEntity.Position.DistanceBetween(MovingEntity.World.Player.Position);
            if (distanceToPlayer > MaximumDistanceBetweenPlayerToBeScared)
            {
                MovingEntity.ChangeState(new LostState(MovingEntity));
                return;
            }

            if (!_fuzzyModule.ShouldFollowPlayer())
            {
                return;
            }

            MovingEntity.ChangeState(new FollowState(MovingEntity));
        }

        public override string ToString() => "Scared";
    }
}
