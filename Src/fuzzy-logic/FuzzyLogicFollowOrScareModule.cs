using System;
using Src.entity;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;

namespace Src.fuzzy_logic
{
    public class FuzzyLogicFollowOrScareModule
    {
        private const string FuzzyVariableDistanceToNearestGoombaName = "DistanceToNearestGoomba",
            FuzzyVariableDesirabilityName = "DesirabilityToFollowMario";

        private readonly FuzzyModule _fuzzyModule = new FuzzyModule();
        private readonly IMovingEntity _movingEntity;

        private double _distanceToNearestGoomba; // Between 0 and 800

        public FuzzyLogicFollowOrScareModule(IMovingEntity movingEntity)
        {
            _movingEntity = movingEntity;

            FuzzyVariable distanceToNearestGoomba = _fuzzyModule.CreateFlv(FuzzyVariableDistanceToNearestGoombaName);
            FuzzyTermSet distanceToNearestGoombaClose = distanceToNearestGoomba.AddLeftShoulderSet("Close", 0, 1.25, 3.75);
            FuzzyTermSet distanceToNearestGoombaMedium = distanceToNearestGoomba.AddTriangleSet("Medium", 1.25, 3.75, 6.25);
            FuzzyTermSet distanceToNearestGoombaFar = distanceToNearestGoomba.AddRightShoulderSet("Far", 3.75, 6.25, 100);

            FuzzyVariable desirability = _fuzzyModule.CreateFlv(FuzzyVariableDesirabilityName);
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("Undesirable", 0, 1.25, 3.75);
            FuzzyTermSet desirable = desirability.AddTriangleSet("Desirable", 1.25, 3.75, 6.25);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("VeryDesirable", 1.25, 6.25, 100);

            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToNearestGoombaClose), undesirable);
            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToNearestGoombaMedium), desirable);
            _fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToNearestGoombaFar), veryDesirable);
        }

        private void CalculateDistanceToNearestGoomba()
        {
            _distanceToNearestGoomba = 800;

            foreach (IEnemy goomba in _movingEntity.World.Enemies)
            {
                double distanceFromNearestGoomba = _movingEntity.Position.DistanceBetween(goomba.Position);
                if (distanceFromNearestGoomba < _distanceToNearestGoomba)
                {
                    _distanceToNearestGoomba = _movingEntity.Position.DistanceBetween(goomba.Position);
                }
            }

            _distanceToNearestGoomba = ConvertRange(0, 800, 0, 100, _distanceToNearestGoomba);
        }

        public bool ShouldFollowPlayer()
        {
            CalculateDistanceToNearestGoomba();

            _fuzzyModule.Fuzzify(FuzzyVariableDistanceToNearestGoombaName, _distanceToNearestGoomba);
            double deFuzzifiedValue = _fuzzyModule.DeFuzzify(FuzzyVariableDesirabilityName);
            Console.WriteLine($"DTNG({_distanceToNearestGoomba.ToString("N1")}) -> {deFuzzifiedValue.ToString("N2")}");

            return deFuzzifiedValue == 0;
        }

        private static double ConvertRange(double originalStart, double originalEnd, double newStart, double newEnd, double value)
        {
            double scale = (newEnd - newStart) / (originalEnd - originalStart);

            return (newStart + ((value - originalStart) * scale));
        }
    }
}
