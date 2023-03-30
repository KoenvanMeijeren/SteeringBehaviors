using NUnit.Framework;
using Src.fuzzy_logic.Set;
using Src.fuzzy_logic.Term;

namespace Tests.fuzzy_logic
{
    public class FuzzyTermFairlyTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermFairly(fuzzySet);

            // Assert
            Assert.AreEqual(0, fuzzyTerm.GetDom());
            Assert.AreNotEqual(fuzzyTerm, fuzzyTerm.Clone());
        }

        [Test]
        public void GetDom_01_LeftShoulder_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermFairly(fuzzySet);

            // Assert
            Assert.AreEqual(3.1622776601683795d, fuzzyTerm.GetDom());
        }

        [Test]
        public void GetDom_01_RightShoulder_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetRightShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermFairly(fuzzySet);

            // Assert
            Assert.AreEqual(3.1622776601683795d, fuzzyTerm.GetDom());
        }

        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermFairly(fuzzySet);
            fuzzyTerm.ResetDom();

            // Assert
            Assert.AreEqual(0, fuzzyTerm.GetDom());
        }

        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermFairly(fuzzySet);
            fuzzyTerm.OrWithDom(35);

            // Assert
            Assert.AreEqual(2.4322992790977875d, fuzzyTerm.GetDom());
        }
    }

    public class FuzzyTermSetTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermSet(fuzzySet);

            // Assert
            Assert.AreEqual(0, fuzzyTerm.GetDom());
            Assert.AreNotEqual(fuzzyTerm, fuzzyTerm.Clone());
        }

        [Test]
        public void GetDom_01_LeftShoulder_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermSet(fuzzySet);

            // Assert
            Assert.AreEqual(10, fuzzyTerm.GetDom());
        }

        [Test]
        public void GetDom_01_RightShoulder_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetRightShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermSet(fuzzySet);

            // Assert
            Assert.AreEqual(10, fuzzyTerm.GetDom());
        }

        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermSet(fuzzySet);
            fuzzyTerm.ResetDom();

            // Assert
            Assert.AreEqual(0, fuzzyTerm.GetDom());
        }

        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermSet(fuzzySet);
            fuzzyTerm.OrWithDom(35);

            // Assert
            Assert.AreEqual(35, fuzzyTerm.GetDom());
        }
    }

    public class FuzzyTermVeryTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermVery(fuzzySet);

            // Assert
            Assert.AreEqual(0, fuzzyTerm.GetDom());
            Assert.AreNotEqual(fuzzyTerm, fuzzyTerm.Clone());
        }

        [Test]
        public void GetDom_01_LeftShoulder_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermVery(fuzzySet);

            // Assert
            Assert.AreEqual(100, fuzzyTerm.GetDom());
        }

        [Test]
        public void GetDom_01_RightShoulder_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetRightShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermVery(fuzzySet);

            // Assert
            Assert.AreEqual(100, fuzzyTerm.GetDom());
        }

        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);
            fuzzySet.OrWithDom(10);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermVery(fuzzySet);
            fuzzyTerm.ResetDom();

            // Assert
            Assert.AreEqual(0, fuzzyTerm.GetDom());
        }

        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySet fuzzySet = new FuzzySetLeftShoulder(15, 30, 0);

            // Act
            FuzzyTerm fuzzyTerm = new FuzzyTermVery(fuzzySet);
            fuzzyTerm.OrWithDom(35);

            // Assert
            Assert.AreEqual(1500625, fuzzyTerm.GetDom());
        }
    }
}
