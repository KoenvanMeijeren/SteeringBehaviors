using System;
using Src.fuzzy_logic;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;

namespace FuzzyLogicConsole
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Fuzzy logic demo");
            
            FuzzyModule fuzzyModule = new();

            FuzzyVariable hunger = fuzzyModule.CreateFlv("Hunger");
            FuzzyTermSet starving = hunger.AddLeftShoulderSet("Starving", 0.0, 0.1, 0.3);
            FuzzyTermSet content = hunger.AddTriangleSet("Content", 0.1, 0.5, 0.8);
            FuzzyTermSet full = hunger.AddRightShoulderSet("Full", 0.5, 0.8, 1.0);

            FuzzyVariable sleep = fuzzyModule.CreateFlv("Sleep");
            FuzzyTermSet tired = sleep.AddLeftShoulderSet("Tired", 0.0, 0.1, 0.3);
            FuzzyTermSet sleepy = sleep.AddTriangleSet("Sleepy", 0.1, 0.3, 0.5);
            FuzzyTermSet awake = sleep.AddRightShoulderSet("Awake", 0.3, 0.5, 1.0);

            FuzzyVariable desirability = fuzzyModule.CreateFlv("Desirability");
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("Undesirable", 0, 0.25, 0.5);
            FuzzyTermSet desirable = desirability.AddTriangleSet("Desirable", 0.25, 0.5, 0.75);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("VeryDesirable", 0.5, 0.75, 1.0);

            fuzzyModule.AddRule(new FuzzyOperatorOr(starving, tired), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(content, sleepy), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(full, sleepy), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(content, awake), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(full, awake), veryDesirable);

            Console.WriteLine("Desirability for hunger and sleep if hidden : <= 0.5: undesirable");
            for (double hungerIndex = 0; hungerIndex < 1; hungerIndex += 0.1)
            {
                for (double sleepIndex = 0; sleepIndex < 1; sleepIndex += 0.1)
                {
                    fuzzyModule.Fuzzify("Hunger", hungerIndex);
                    fuzzyModule.Fuzzify("Sleep", sleepIndex);
                    double deFuzzifiedValue = fuzzyModule.DeFuzzify("Desirability");
                    if (deFuzzifiedValue == 0)
                    {
                        continue;
                    }

                    string desirableValue = "";
                    if (deFuzzifiedValue is >= 0 and <= 0.5)
                    {
                        desirableValue = "undesirable";
                    }
                    
                    if (deFuzzifiedValue is >= 0.25 and <= 0.75)
                    {
                        if (desirableValue.Length > 0)
                        {
                            desirableValue += "&";
                        }
                        
                        desirableValue += "desirable";
                    }

                    if (deFuzzifiedValue is >= 0.5 and <= 1.0)
                    {
                        if (desirableValue.Length > 0)
                        {
                            desirableValue += "&";
                        }
                        
                        desirableValue += "veryDesirable";
                    }

                    Console.WriteLine($"Desirability for hunger({hungerIndex.ToString("N2")}) and sleep ({sleepIndex.ToString("N2")}): " + deFuzzifiedValue.ToString("N2") + ": " + desirableValue);
                }
            }
        }
    }
}
