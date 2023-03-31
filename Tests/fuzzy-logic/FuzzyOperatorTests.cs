using NUnit.Framework;
using Src.fuzzy_logic;
using Src.fuzzy_logic.Operator;
using Src.fuzzy_logic.Term;

namespace Tests.fuzzy_logic
{
    public class FuzzyOperatorOrTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorOr(low, decent);

            // Assert
            Assert.AreEqual(0, fuzzyOperator.GetDom());
            Assert.AreNotEqual(fuzzyOperator, fuzzyOperator.Clone());
        }

        [Test]
        public void GetDom_01_Ok()
        {
            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            low.OrWithDom(10);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);
            decent.OrWithDom(30);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorOr(low, decent);

            // Assert
            Assert.AreEqual(30, fuzzyOperator.GetDom());
        }

        [Test]
        public void OrWithDom_01_Ok()
        {
            // Mocked values
            const double Dom = 30;

            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorOr(low, decent);
            fuzzyOperator.OrWithDom(Dom);

            // Assert
            Assert.AreEqual(Dom, fuzzyOperator.GetDom());
        }

        [Test]
        public void ResetDom_01_Ok()
        {
            // Mocked values
            const double Dom = 30;

            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorOr(low, decent);
            fuzzyOperator.OrWithDom(Dom);
            fuzzyOperator.ResetDom();

            // Assert
            Assert.AreNotEqual(Dom, fuzzyOperator.GetDom());
            Assert.AreEqual(0, fuzzyOperator.GetDom());
        }
    }

    public class FuzzyOperatorAndTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorAnd(low, decent);

            // Assert
            Assert.AreEqual(0, fuzzyOperator.GetDom());
            Assert.AreNotEqual(fuzzyOperator, fuzzyOperator.Clone());
        }

        [Test]
        public void GetDom_01_Ok()
        {
            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            low.OrWithDom(10);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);
            decent.OrWithDom(30);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorAnd(low, decent);

            // Assert
            Assert.AreEqual(10, fuzzyOperator.GetDom());
        }

        [Test]
        public void OrWithDom_01_Ok()
        {
            // Mocked values
            const double Dom = 30;

            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorAnd(low, decent);
            fuzzyOperator.OrWithDom(Dom);

            // Assert
            Assert.AreEqual(Dom, fuzzyOperator.GetDom());
        }

        [Test]
        public void ResetDom_01_Ok()
        {
            // Mocked values
            const double Dom = 30;

            // Arrange
            FuzzyModule fuzzyModule = new();
            FuzzyVariable energy = fuzzyModule.CreateFlv("energy");
            FuzzyTermSet low = energy.AddLeftShoulderSet("low", 0, 15, 30);
            FuzzyTermSet decent = energy.AddTriangleSet("decent", 10, 50, 75);

            // Act
            FuzzyTerm fuzzyOperator = new FuzzyOperatorAnd(low, decent);
            fuzzyOperator.OrWithDom(Dom);
            fuzzyOperator.ResetDom();

            // Assert
            Assert.AreNotEqual(Dom, fuzzyOperator.GetDom());
            Assert.AreEqual(0, fuzzyOperator.GetDom());
        }
    }
}
