using Src.entity;
using Src.state;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public interface IAttackState
    {
        AttackState AttackState { get; }

        void Enter();
        void Execute();
    }

    public class AttackState : IState
    {
        public IMovingEntity MovingEntity { get; }
        private IAttackState _attackState;
        private const int _maxShortestPathDistance = 3;
        public const int _maxPower = 100;
        public int Power { get; set; } = _maxPower;

        public AttackState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void ChangeState(IAttackState attackState)
        {
            _attackState = attackState;
            attackState.Enter();
        }

        public void Enter()
        {
            ChangeState(new ChaseState(this));
        }

        public void Execute()
        {
            if (!(MovingEntity.SteeringBehavior is PathfindingBehaviorVisualizer pathfindingBehaviorVisualizer))
            {
                _attackState.Execute();
                return;
            }

            if (pathfindingBehaviorVisualizer.Path.Count > _maxShortestPathDistance)
            {
                MovingEntity.ChangeState(new SearchState(MovingEntity));
                return;
            }

            _attackState.Execute();
        }

        public override string ToString() => _attackState.ToString();
    }
}
