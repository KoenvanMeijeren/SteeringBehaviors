namespace NestedStatesConsole.State
{
    public interface IAttackState
    {
        AttackState AttackState { get; }

        void Enter();
        void Execute();
        void Exit();
    }
}
