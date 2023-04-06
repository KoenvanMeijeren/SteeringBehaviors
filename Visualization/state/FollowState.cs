using Src.behavior;
using Src.entity;
using Src.fuzzy_logic;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;
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

        private FuzzyModule _fuzzyModule { get; }

        public FollowState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
            _fuzzyModule = new FuzzyModule();
            SetFuzzyModule();
        }

        private void SetFuzzyModule()
        {
            FuzzyVariable distanceToFinish = _fuzzyModule.CreateFlv("DistanceToFinish");
            FuzzyTermSet distanceToFinishClose = distanceToFinish.AddLeftShoulderSet("Close", 0, 0, 200);
            FuzzyTermSet distanceToFinishMedium = distanceToFinish.AddTriangleSet("Medium", 0, 200, 400);
            FuzzyTermSet distanceToFinishFar = distanceToFinish.AddRightShoulderSet("Far", 200, 400, 400);

            FuzzyVariable DistanceToNearestGoomba = _fuzzyModule.CreateFlv("DistanceToNearestGoomba");
            FuzzyTermSet DistanceToNearestGoombaClose = DistanceToNearestGoomba.AddLeftShoulderSet("Close", 0, 0, 400);
            FuzzyTermSet DistanceToNearestGoombaMedium = DistanceToNearestGoomba.AddTriangleSet("Medium", 0, 400, 800);
            FuzzyTermSet DistanceToNearestGoombaFar = DistanceToNearestGoomba.AddRightShoulderSet("Far", 400, 800, 800);

            FuzzyVariable desirability = _fuzzyModule.CreateFlv("DesirabilityToFollowMario");
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("Undesirable", 0, 0.25, 0.5);
            FuzzyTermSet desirable = desirability.AddTriangleSet("Desirable", 0.25, 0.5, 0.75);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("VeryDesirable", 0.5, 0.75, 1.0);

            _fuzzyModule.AddRule(new FuzzyOperatorOr(distanceToFinishClose, DistanceToNearestGoombaClose), undesirable);
            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishMedium, DistanceToNearestGoombaMedium), undesirable);
            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishFar, DistanceToNearestGoombaMedium), desirable);
            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishMedium, DistanceToNearestGoombaFar), desirable);
            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishFar, DistanceToNearestGoombaFar), veryDesirable);
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
            CalculateDistanceFromNearestGoomba();

            _fuzzyModule.Fuzzify("DistanceToFinish", _distanceFromFinish);
            _fuzzyModule.Fuzzify("DistanceToNearestGoomba", _distanceFromNearestGoomba);
            double deFuzzifiedValue = _fuzzyModule.DeFuzzify("DesirabilityToFollowMario");
            Console.WriteLine(deFuzzifiedValue);
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
        }

        public override string ToString() => "Follow";
    }
}
