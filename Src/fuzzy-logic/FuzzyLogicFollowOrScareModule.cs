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

        private double CalculateDistanceToNearestGoomba()
        {
            double distanceToNearestGoomba = 800;

            foreach (IEnemy goomba in _movingEntity.World.Enemies)
            {
                double distanceFromNearestGoomba = _movingEntity.Position.DistanceBetween(goomba.Position);
                if (distanceFromNearestGoomba < distanceToNearestGoomba)
                {
                    distanceToNearestGoomba = _movingEntity.Position.DistanceBetween(goomba.Position);
                }
            }

            return distanceToNearestGoomba;
        }

        public bool ShouldFollowPlayer()
        {
            FuzzyLogicData.DistanceToNearestGoomba = CalculateDistanceToNearestGoomba();

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
            fuzzyModule.Fuzzify(FuzzyLogicFollowOrScareDataTransferObject.FuzzyVariableDistanceToNearestGoombaName, FuzzyLogicData.DistanceToNearestGoombaConverted);
            FuzzyLogicData.DeFuzzifiedValue = fuzzyModule.DeFuzzify(FuzzyLogicFollowOrScareDataTransferObject.FuzzyVariableDesirabilityName);

            return FuzzyLogicData.DeFuzzifiedValue == 0;
        }
    }

    public class FuzzyLogicFollowOrScareDataTransferObject
    {
        public static string FuzzyVariableDistanceToNearestGoombaName => "DistanceToNearestGoomba";
        public static string FuzzyVariableDesirabilityName => "DesirabilityToFollowMario";
        public double DistanceToNearestGoomba { get; set; } = 800;
        public double DistanceToNearestGoombaConverted => ConvertRange(0, 800, 0, 100, DistanceToNearestGoomba);
        public double DeFuzzifiedValue { get; set; }
        public double DistanceToNearestGoombaLeftShoulderMinValue { get; set; } = 0;
        public double DistanceToNearestGoombaLeftShoulderPeakValue { get; set; } = 1.25;
        public double DistanceToNearestGoombaLeftShoulderMaxValue { get; set; } = 3.75;
        public double DistanceToNearestGoombaTriangleMinValue { get; set; } = 1.25;
        public double DistanceToNearestGoombaTrianglePeakValue { get; set; } = 3.75;
        public double DistanceToNearestGoombaTriangleMaxValue { get; set; } = 6.25;
        public double DistanceToNearestGoombaRightShoulderMinValue { get; set; } = 3.75;
        public double DistanceToNearestGoombaRightShoulderPeakValue { get; set; } = 6.25;
        public double DistanceToNearestGoombaRightShoulderMaxValue { get; set; } = 100;
        public double UndesirableLeftShoulderMinValue { get; set; } = 0;
        public double UndesirableLeftShoulderPeakValue { get; set; } = 1.25;
        public double UndesirableLeftShoulderMaxValue { get; set; } = 3.75;
        public double DesirableTriangleMinValue { get; set; } = 1.25;
        public double DesirableTrianglePeakValue { get; set; } = 3.75;
        public double DesirableTriangleMaxValue { get; set; } = 6.25;
        public double VeryDesirableRightShoulderMinValue { get; set; } = 1.25;
        public double VeryDesirableRightShoulderPeakValue { get; set; } = 6.25;
        public double VeryDesirableRightShoulderMaxValue { get; set; } = 100;
        private static double ConvertRange(double originalStart, double originalEnd, double newStart, double newEnd, double value)
        {
            double scale = (newEnd - newStart) / (originalEnd - originalStart);

            return (newStart + ((value - originalStart) * scale));
        }
    }
}
