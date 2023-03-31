using Src.entity;

namespace Src.state
{
    public interface IState
    {
        IMovingEntity MovingEntity { get; }

        void Enter();
        void Execute();

        string ToString();
    }
}
