namespace SteeringCS.state
{
    public class DoAttackState : IAttackState
    {
        public AttackState AttackState { get; }

        public DoAttackState(AttackState attackState)
        {
            AttackState = attackState;
        }

        public void Enter()
        {

        }

        public void Execute()
        {
            AttackState.MovingEntity.World.Player.TakeDamage();
            AttackState.Power = 0;
            AttackState.ChangeState(new RestState(AttackState));
        }
    }
}
