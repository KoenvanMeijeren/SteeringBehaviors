using NUnit.Framework;
using Src.fuzzy_logic;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;

namespace Tests.fuzzy_logic
{
    public class FuzzyModuleTests
    {
        [TestCase(0, 0, 0)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 10, 37.5)]
        [TestCase(10, 1, 37.5)]
        [TestCase(25, 25, 0)]
        [TestCase(10, 25, 37.5)]
        [TestCase(25, 10, 37.5)]
        [TestCase(35, 35, 50)]
        [TestCase(45, 45, 50)]
        [TestCase(45, 75, 0)]
        [TestCase(55, 55, 70)]
        [TestCase(65, 65, 73.07692307692308d)]
        [TestCase(65, 25, 50)]
        [TestCase(75, 75, 50)]
        [TestCase(85, 45, 80)]
        [TestCase(85, 85, 83.333333333333329d)]
        [TestCase(95, 85, 87.5d)]
        [TestCase(85, 95, 83.333333333333329d)]
        [TestCase(95, 95, 87.5d)]
        [TestCase(100, 1, 87.5)]
        [TestCase(1, 100, 0)]
        [TestCase(100, 100, 87.5)]
        public void FuzzifyAndDefuzzyify_01_OrOperator_TwoAntecedents_Ok(double energyInput, double sleepInput, double expectedResult)
        {
            // Arrange
            FuzzyModule fuzzyModule = new();

            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet energyLow = energy.AddLeftShoulderSet("low", 0, 10, 30);
            FuzzyTermSet energyDecent = energy.AddTriangleSet("content", 10, 50, 75);
            FuzzyTermSet energyFull = energy.AddRightShoulderSet("high", 50, 75, 100);

            FuzzyVariable sleep = fuzzyModule.CreateFlv("sleep");
            FuzzyTermSet tired = sleep.AddLeftShoulderSet("tired", 0, 10, 30);
            FuzzyTermSet sleepy = sleep.AddTriangleSet("sleepy", 10, 30, 50);
            FuzzyTermSet awake = sleep.AddRightShoulderSet("awake", 30, 50, 100);

            FuzzyVariable desirability = fuzzyModule.CreateFlv("desirability");
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("undesirable", 0, 25, 50);
            FuzzyTermSet desirable = desirability.AddTriangleSet("desirable", 25, 50, 75);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("veryDesirable", 50, 75, 100);

            // Act
            fuzzyModule.AddRule(new FuzzyOperatorOr(energyLow, tired), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorOr(energyDecent, sleepy), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorOr(energyFull, awake), veryDesirable);

            fuzzyModule.Fuzzify("energy", energyInput);
            fuzzyModule.Fuzzify("sleep", sleepInput);
            double result = fuzzyModule.DeFuzzify("desirability");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 0)]
        [TestCase(9, 9, 0)]
        [TestCase(10, 9, 0)]
        [TestCase(10, 10, 37.5)]
        [TestCase(15, 12, 37.5)]
        [TestCase(18, 10, 37.5)]
        [TestCase(19, 19, 37.5)]
        [TestCase(51, 31, 50)]
        [TestCase(53, 44, 50)]
        [TestCase(75, 34, 50)]
        [TestCase(85, 45, 50)]
        [TestCase(78, 59, 87.5)]
        [TestCase(86, 51, 87.5)]
        [TestCase(90, 65, 87.5)]
        [TestCase(97, 65, 87.5)]
        public void FuzzifyAndDefuzzyify_01_AndOperator_TwoAntecedents_Ok(double energyInput, double sleepInput, double expectedResult)
        {
            // Arrange
            FuzzyModule fuzzyModule = new();

            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet energyLow = energy.AddLeftShoulderSet("low", 0, 10, 30);
            FuzzyTermSet energyDecent = energy.AddTriangleSet("content", 10, 50, 75);
            FuzzyTermSet energyFull = energy.AddRightShoulderSet("high", 50, 75, 100);

            FuzzyVariable sleep = fuzzyModule.CreateFlv("sleep");
            FuzzyTermSet tired = sleep.AddLeftShoulderSet("tired", 0, 10, 30);
            FuzzyTermSet sleepy = sleep.AddTriangleSet("sleepy", 10, 30, 50);
            FuzzyTermSet awake = sleep.AddRightShoulderSet("awake", 30, 50, 100);

            FuzzyVariable desirability = fuzzyModule.CreateFlv("desirability");
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("undesirable", 0, 25, 50);
            FuzzyTermSet desirable = desirability.AddTriangleSet("desirable", 25, 50, 75);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("veryDesirable", 50, 75, 100);

            // Act
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyLow, tired), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyDecent, sleepy), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyFull, awake), veryDesirable);

            fuzzyModule.Fuzzify("energy", energyInput);
            fuzzyModule.Fuzzify("sleep", sleepInput);
            double result = fuzzyModule.DeFuzzify("desirability");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 0)]
        [TestCase(9, 9, 0)]
        [TestCase(10, 9, 0)]
        [TestCase(19, 10, 0)]
        [TestCase(55, 12, 0)]
        [TestCase(65, 10, 0)]
        [TestCase(75, 10, 0)]
        [TestCase(76, 10, 37.5)]
        [TestCase(76, 15, 37.5)]
        [TestCase(80, 19, 37.5)]
        [TestCase(99, 13, 37.5)]
        [TestCase(51, 31, 50)]
        [TestCase(53, 44, 50)]
        [TestCase(75, 34, 50)]
        [TestCase(85, 45, 50)]
        [TestCase(78, 59, 87.5)]
        [TestCase(86, 51, 87.5)]
        [TestCase(90, 65, 87.5)]
        [TestCase(97, 65, 87.5)]
        public void FuzzifyAndDefuzzyify_01_CombinedOperators_TwoAntecedents_Ok(double energyInput, double sleepInput, double expectedResult)
        {
            // Arrange
            FuzzyModule fuzzyModule = new();

            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet energyLow = energy.AddLeftShoulderSet("low", 0, 10, 30);
            FuzzyTermSet energyDecent = energy.AddTriangleSet("content", 10, 50, 75);
            FuzzyTermSet energyFull = energy.AddRightShoulderSet("high", 50, 75, 100);

            FuzzyVariable sleep = fuzzyModule.CreateFlv("sleep");
            FuzzyTermSet tired = sleep.AddLeftShoulderSet("tired", 0, 10, 30);
            FuzzyTermSet sleepy = sleep.AddTriangleSet("sleepy", 10, 30, 50);
            FuzzyTermSet awake = sleep.AddRightShoulderSet("awake", 30, 50, 100);

            FuzzyVariable desirability = fuzzyModule.CreateFlv("desirability");
            FuzzyTermSet undesirable = desirability.AddLeftShoulderSet("undesirable", 0, 25, 50);
            FuzzyTermSet desirable = desirability.AddTriangleSet("desirable", 25, 50, 75);
            FuzzyTermSet veryDesirable = desirability.AddRightShoulderSet("veryDesirable", 50, 75, 100);

            // Act
            fuzzyModule.AddRule(new FuzzyOperatorOr(energyLow, tired), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyFull, tired), undesirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyDecent, awake), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyDecent, sleepy), desirable);
            fuzzyModule.AddRule(new FuzzyOperatorAnd(energyFull, awake), veryDesirable);

            fuzzyModule.Fuzzify("energy", energyInput);
            fuzzyModule.Fuzzify("sleep", sleepInput);
            double result = fuzzyModule.DeFuzzify("desirability");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Defuzzyify_01_AndOperator_NonExisting_Ok()
        {
            // Arrange & act
            FuzzyModule fuzzyModule = new();
            double result = fuzzyModule.DeFuzzify("non-existing-key");

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
