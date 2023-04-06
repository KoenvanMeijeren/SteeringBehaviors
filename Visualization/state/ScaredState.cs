using Src.behavior;
using Src.entity;
using Src.state;
using SteeringCS.behavior;

namespace SteeringCS.state
{
    public class ScaredState : IState
    {
        public IMovingEntity MovingEntity { get; }

        private double _distanceFromFinish; // Between 0 and 400
        private double _distanceFromNearestGoomba; // Between 0 and 800

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

        public void CalculateDistanceFromFinish()
        {
            _distanceFromFinish = MovingEntity.Position.DistanceBetween(MovingEntity.World.Center);
        }

        public void CalculateDistanceFromNearestGoomba()
        {
            _distanceFromNearestGoomba = double.MaxValue;
            double distanceFromNearestGoomba;

            foreach (IEnemy goomba in MovingEntity.World.Enemies)
            {
                distanceFromNearestGoomba = MovingEntity.Position.DistanceBetween(goomba.Position);
                if (distanceFromNearestGoomba < _distanceFromNearestGoomba)
                {
                    _distanceFromNearestGoomba = MovingEntity.Position.DistanceBetween(goomba.Position);
                }
            }
        }

        public override string ToString() => "Scared";
    }
}
