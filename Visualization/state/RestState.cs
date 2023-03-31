using Src.behavior;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class RestState : IAttackState
    {

        public AttackState AttackState { get; }

        public RestState(AttackState attackState)
        {
            AttackState = attackState;
        }

        public void Enter()
        {
            AttackState.MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.IdlingBehavior, AttackState.MovingEntity), null);
        }

        public void Execute()
        {
            if (AttackState.Power == AttackState._maxPower)
            {
                AttackState.ChangeState(new ChaseState(AttackState));
                return;
            }

            AttackState.Power++;
        }

        public override string ToString() => "Resting...";
    }
}
