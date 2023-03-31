using Src.behavior;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class ChaseState : IAttackState
    {
        public AttackState AttackState { get; }

        private const int _attackDistance = 16;

        public ChaseState(AttackState attackState)
        {
            AttackState = attackState;
        }

        public void Enter()
        {
            AttackState.MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.PathfindingBehavior, AttackState.MovingEntity), null);
        }

        public void Execute()
        {
            double distanceFromPlayer = AttackState.MovingEntity.Position.DistanceBetween(AttackState.MovingEntity.World.Player.Position);
            bool isPlayerClose = distanceFromPlayer < _attackDistance;

            if (isPlayerClose)
            {
                AttackState.ChangeState(new DoAttackState(AttackState));
            }
        }

        public override string ToString()
        {
            return "Chase";
        }
    }
}
