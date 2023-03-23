namespace NestedStatesConsole.State
{
    public interface IState
    {
        Player Player { get; }

        void Enter();
        void Execute();
        void Exit();
    }
}
