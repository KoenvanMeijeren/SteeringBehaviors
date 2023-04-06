using Src.behavior;
using Src.entity;
using Src.state;
using SteeringCS.behavior;
using System;

namespace SteeringCS.state
{
    public class FollowState : IState
    {
        public IMovingEntity MovingEntity { get; }

        private double _distanceFromFinish; // Between 0 and 400
        private double _distanceFromNearestGoomba; // Between 0 and 800

        public FollowState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.PathfindingBehavior, MovingEntity), null);
        }

        public void Execute()
        {
            // FUZY LOGIC (change to scared if fuzzy logics says so)
            // MovingEntity.ChangeState(new ScaredState(MovingEntity));
            CalculateDistanceFromNearestGoomba();
        }

        public void CalculateDistanceFromFinish()
        {
            _distanceFromFinish = MovingEntity.Position.DistanceBetween(MovingEntity.World.Center);
        }

        public void CalculateDistanceFromNearestGoomba()
        {
            _distanceFromNearestGoomba = double.MaxValue;
            double distanceFromNearestGoomba;

            foreach(IEnemy goomba in MovingEntity.World.Enemies)
            {
                distanceFromNearestGoomba = MovingEntity.Position.DistanceBetween(goomba.Position);
                if (distanceFromNearestGoomba < _distanceFromNearestGoomba)
                {
                    _distanceFromNearestGoomba = MovingEntity.Position.DistanceBetween(goomba.Position);
                }
            }

            Console.WriteLine(_distanceFromNearestGoomba.ToString());
        }

        public override string ToString() => "Follow";
    }
}
