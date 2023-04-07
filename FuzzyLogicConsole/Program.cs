using System;
using Src.fuzzy_logic;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;

namespace FuzzyLogicConsole
{
    internal static class Program
    {
        private const string FuzzyVariableDistanceToFinishName = "DistanceToFinish", 
            FuzzyVariableDistanceToNearestGoombaName = "DistanceToNearestGoomba",
            FuzzyVariableDesirabilityName = "DesirabilityToFollowMario";
        
        private static void Main()
        {
            Console.WriteLine("Fuzzy logic demo");

            FuzzyModule fuzzyModule = new();

            FuzzyVariable distanceToFinish = fuzzyModule.CreateFlv(FuzzyVariableDistanceToFinishName);
            FuzzyTermSet distanceToFinishClose = distanceToFinish.AddLeftShoulderSet("Close", 0, 10, 30);
            FuzzyTermSet distanceToFinishMedium = distanceToFinish.AddTriangleSet("Medium", 10, 50, 80);
            FuzzyTermSet distanceToFinishFar = distanceToFinish.AddRightShoulderSet("Far", 50, 80, 100);

            FuzzyVariable distanceToNearestGoomba = fuzzyModule.CreateFlv(FuzzyVariableDistanceToNearestGoombaName);
            FuzzyTermSet distanceToNearestGoombaClose = distanceToNearestGoomba.AddLeftShoulderSet("Close", 0, 10, 30);
            FuzzyTermSet distanceToNearestGoombaMedium = distanceToNearestGoomba.AddTriangleSet("Medium", 10, 30, 50);
            FuzzyTermSet distanceToNearestGoombaFar = distanceToNearestGoomba.AddRightShoulderSet("Far", 30, 50, 100);

            FuzzyVariable desirability = fuzzyModule.CreateFlv(FuzzyVariableDesirabilityName);
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("Undesirable", 0, 25, 50);
            FuzzyTermSet desirable = desirability.AddTriangleSet("Desirable", 25, 50, 75);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("VeryDesirable", 50, 75, 100);

            fuzzyModule.AddRule(new FuzzyOperatorOr(distanceToFinishClose, distanceToNearestGoombaClose), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishMedium, distanceToNearestGoombaMedium), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishFar, distanceToNearestGoombaMedium), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishMedium, distanceToNearestGoombaFar), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(distanceToFinishFar, distanceToNearestGoombaFar), veryDesirable);

            Console.WriteLine("Desirability for DTF and DTNG if hidden : <= 50: undesirable");
            for (double hungerIndex = 0; hungerIndex < 100; hungerIndex += 1)
            {
                for (double sleepIndex = 0; sleepIndex < 100; sleepIndex += 1)
                {
                    fuzzyModule.Fuzzify(FuzzyVariableDistanceToFinishName, hungerIndex);
                    fuzzyModule.Fuzzify(FuzzyVariableDistanceToNearestGoombaName, sleepIndex);
                    double deFuzzifiedValue = fuzzyModule.DeFuzzify(FuzzyVariableDesirabilityName);
                    if (deFuzzifiedValue == 0)
                    {
                        continue;
                    }

                    string desirableValue = deFuzzifiedValue switch
                    {
                        >= 40 and <= 75 => "desirable -> to follow mario",
                        >= 50 and <= 100 => "very desirable -> to follow mario",
                        _ => "undesirable -> to follow mario"
                    };

                    Console.WriteLine($"Desirability for hunger({hungerIndex:N2}) and sleep ({sleepIndex:N2}): " + deFuzzifiedValue.ToString("N2") + ": " + desirableValue);
                }
            }
        }
    }
}
