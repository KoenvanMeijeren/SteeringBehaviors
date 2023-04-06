using Src.behavior;
using Src.entity;
using Src.state;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class ScaredState : IState
    {
        public IMovingEntity MovingEntity { get; }

        public ScaredState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.IdlingBehavior, MovingEntity), null);
        }

        public void Execute()
        {
            // FUZY LOGIC (change to follow if fuzzy logics says so)
        }

        public override string ToString() => "Scared";
    }
}
