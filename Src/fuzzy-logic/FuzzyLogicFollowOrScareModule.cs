using System;
using Src.entity;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;
using Src.world;

namespace Src.fuzzy_logic
{
    public class FuzzyLogicFollowOrScareModule
    {
        private readonly IMovingEntity _movingEntity;
        private IWorld World => _movingEntity.World;
        private FuzzyLogicFollowOrScareDataTransferObject FuzzyLogicData => World.FuzzyLogicData;

        public FuzzyLogicFollowOrScareModule(IMovingEntity movingEntity)
        {
            _movingEntity = movingEntity;
        }

        private Tuple<double, string> CalculateNearestGoombaData()
        {
            double distanceToNearestGoomba = 800;
            string stateOfNearestGoomba = null;
            foreach (IEnemy goomba in _movingEntity.World.Enemies)
            {
                double distanceToGoomba = _movingEntity.Position.DistanceBetween(goomba.Position);
                if (distanceToGoomba < distanceToNearestGoomba)
                {
                    distanceToNearestGoomba = distanceToGoomba;
                    stateOfNearestGoomba = goomba.State?.ToString() ?? "";
                }
            }

            return new Tuple<double, string>(distanceToNearestGoomba, stateOfNearestGoomba);
        }

        public bool ShouldFollowPlayer()
        {
            Tuple<double, string> nearestGoombaData = CalculateNearestGoombaData();
            FuzzyLogicData.DistanceToNearestGoomba = nearestGoombaData.Item1;

            FuzzyModule fuzzyModule = new FuzzyModule();
            FuzzyVariable distanceToNearestGoomba = fuzzyModule.CreateFlv(FuzzyLogicFollowOrScareDataTransferObject.FuzzyVariableDistanceToNearestGoombaName);
            FuzzyTermSet distanceToNearestGoombaClose = distanceToNearestGoomba.AddLeftShoulderSet("Close", FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMinValue, FuzzyLogicData.DistanceToNearestGoombaLeftShoulderPeakValue, FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMaxValue);
            FuzzyTermSet distanceToNearestGoombaMedium = distanceToNearestGoomba.AddTriangleSet("Medium", FuzzyLogicData.DistanceToNearestGoombaTriangleMinValue, FuzzyLogicData.DistanceToNearestGoombaTrianglePeakValue, FuzzyLogicData.DistanceToNearestGoombaTriangleMaxValue);
            FuzzyTermSet distanceToNearestGoombaFar = distanceToNearestGoomba.AddRightShoulderSet("Far", FuzzyLogicData.DistanceToNearestGoombaRightShoulderMinValue, FuzzyLogicData.DistanceToNearestGoombaRightShoulderPeakValue, FuzzyLogicData.DistanceToNearestGoombaRightShoulderMaxValue);

            FuzzyVariable desirability = fuzzyModule.CreateFlv(FuzzyLogicFollowOrScareDataTransferObject.FuzzyVariableDesirabilityName);
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("Undesirable", FuzzyLogicData.UndesirableLeftShoulderMinValue, FuzzyLogicData.UndesirableLeftShoulderPeakValue, FuzzyLogicData.UndesirableLeftShoulderMaxValue);
            FuzzyTermSet desirable = desirability.AddTriangleSet("Desirable", FuzzyLogicData.DesirableTriangleMinValue, FuzzyLogicData.DesirableTrianglePeakValue, FuzzyLogicData.DesirableTriangleMaxValue);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("VeryDesirable", FuzzyLogicData.VeryDesirableRightShoulderMinValue, FuzzyLogicData.VeryDesirableRightShoulderPeakValue, FuzzyLogicData.VeryDesirableRightShoulderMaxValue);

            fuzzyModule.AddRule(new FuzzyOperatorOr(distanceToNearestGoombaClose), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorOr(distanceToNearestGoombaMedium), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorOr(distanceToNearestGoombaFar), veryDesirable);
            fuzzyModule.Fuzzify(FuzzyLogicFollowOrScareDataTransferObject.FuzzyVariableDistanceToNearestGoombaName, FuzzyLogicData.DistanceToNearestGoomba);
            FuzzyLogicData.DeFuzzifiedValue = fuzzyModule.DeFuzzify(FuzzyLogicFollowOrScareDataTransferObject.FuzzyVariableDesirabilityName);

            return FuzzyLogicData.DeFuzzifiedValue == 0 && !nearestGoombaData.Item2.Equals("Chase");
        }
    }

    public class FuzzyLogicFollowOrScareDataTransferObject
    {
        public static string FuzzyVariableDistanceToNearestGoombaName => "DistanceToNearestGoomba";
        public static string FuzzyVariableDesirabilityName => "DesirabilityToFollowMario";
        private static double DefaultLeftShoulderMinValue => 0;
        private static double DefaultLeftShoulderPeakValue => 20;
        private static double DefaultLeftShoulderMaxValue => 40;
        private static double DefaultTriangleMinValue => 20;
        private static double DefaultTrianglePeakValue => 40;
        private static double DefaultTriangleMaxValue => 400;
        private static double DefaultRightShoulderMinValue => 40;
        private static double DefaultRightShoulderPeakValue => 400;
        private static double DefaultRightShoulderMaxValue => 800;
        public const int MaximumDistanceToNearestGoomba = 800;
        public double DistanceToNearestGoombaLeftShoulderMinValue { get; set; } = DefaultLeftShoulderMinValue;
        public double DistanceToNearestGoombaLeftShoulderPeakValue { get; set; } = DefaultLeftShoulderPeakValue;
        public double DistanceToNearestGoombaLeftShoulderMaxValue { get; set; } = DefaultLeftShoulderMaxValue;
        public double DistanceToNearestGoombaTriangleMinValue { get; set; } = DefaultTriangleMinValue;
        public double DistanceToNearestGoombaTrianglePeakValue { get; set; } = DefaultTrianglePeakValue;
        public double DistanceToNearestGoombaTriangleMaxValue { get; set; } = DefaultTriangleMaxValue;
        public double DistanceToNearestGoombaRightShoulderMinValue { get; set; } = DefaultRightShoulderMinValue;
        public double DistanceToNearestGoombaRightShoulderPeakValue { get; set; } = DefaultRightShoulderPeakValue;
        public double DistanceToNearestGoombaRightShoulderMaxValue { get; set; } = DefaultRightShoulderMaxValue;
        public double UndesirableLeftShoulderMinValue { get; set; } = DefaultLeftShoulderMinValue;
        public double UndesirableLeftShoulderPeakValue { get; set; } = DefaultLeftShoulderPeakValue;
        public double UndesirableLeftShoulderMaxValue { get; set; } = DefaultLeftShoulderMaxValue;
        public double DesirableTriangleMinValue { get; set; } = DefaultTriangleMinValue;
        public double DesirableTrianglePeakValue { get; set; } = DefaultTrianglePeakValue;
        public double DesirableTriangleMaxValue { get; set; } = DefaultTriangleMaxValue;
        public double VeryDesirableRightShoulderMinValue { get; set; } = DefaultRightShoulderMinValue;
        public double VeryDesirableRightShoulderPeakValue { get; set; } = DefaultRightShoulderPeakValue;
        public double VeryDesirableRightShoulderMaxValue { get; set; } = DefaultRightShoulderMaxValue;
        public double DistanceToNearestGoomba { get; set; } = 800;
        public double DeFuzzifiedValue { get; set; }
    }
}
