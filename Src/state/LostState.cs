using Src.behavior;
using Src.entity;

namespace Src.state
{
    public class LostState : IState
    {
        public IMovingEntity MovingEntity { get; }

        public LostState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
