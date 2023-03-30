using Visualization.entity;

namespace Visualization.state
{
    public interface IState
    {
        IMovingEntity MovingEntity { get; }

        void Enter();
        void Execute();
    }
}
