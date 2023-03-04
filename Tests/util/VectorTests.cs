using System;
using NUnit.Framework;
using Src.util;

namespace SteeringCSTests.util
{
    public class VectorImmutableTests
    {
        [TestCase(0, 0, "(0,0)")]
        [TestCase(3, 4, "(3,4)")]
        [TestCase(6, 6, "(6,6)")]
        public void Test_Create_01_Ok(double x, double y, string expectedResult)
        {
            // Act
            VectorImmutable vector = new VectorImmutable(x, y);

            // Assert
            Assert.AreEqual(x, vector.X);
            Assert.AreEqual(Math.Round(x, 2), vector.XRounded);
            Assert.AreEqual(y, vector.Y);
            Assert.AreEqual(Math.Round(y, 2), vector.YRounded);
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(0, 0, 0)]
        [TestCase(3, 4, 5.0)]
        [TestCase(6, 6, 8.4852813742385695d)]
        public void Test_Length_01_Ok(double x, double y, double expectedResult)
        {
            // Act
            VectorImmutable vector = new VectorImmutable(x, y);

            // Assert
            Assert.AreEqual(expectedResult, vector.Length);
        }

        [TestCase(0, 0, 0)]
        [TestCase(3, 4, 25.0)]
        [TestCase(6, 6, 72.0)]
        public void Test_LengthSquared_01_Ok(double x, double y, double expectedResult)
        {
            // Act
            VectorImmutable vector = new VectorImmutable(x, y);

            // Assert
            Assert.AreEqual(expectedResult, vector.LengthSquared);
        }

        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, "(0,0)")]
        [TestCase(new double[] { 1, 2 }, new double[] { 2, 1 }, "(3,3)")]
        [TestCase(new double[] { 1, 2 }, new double[] { 3, 5 }, "(4,7)")]
        [TestCase(new double[] { -2, 2 }, new double[] { 3, 5 }, "(1,7)")]
        public void Test_AddWithVector_01_Ok(double[] leftPositions, double[] rightPositions, string expectedResult)
        {
            // Arrange
            VectorImmutable left = new VectorImmutable(leftPositions[0], leftPositions[1]);
            VectorImmutable right = new VectorImmutable(rightPositions[0], rightPositions[1]);

            // Act
            VectorImmutable result = left + right;

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, 0, "(0,0)")]
        [TestCase(new double[] { 0, 0 }, 0, 2, "(0,2)")]
        [TestCase(new double[] { 1, 2 }, 3, 4, "(4,6)")]
        [TestCase(new double[] { 1, 2 }, 3, 3, "(4,5)")]
        [TestCase(new double[] { -2, 2 }, 4, 4, "(2,6)")]
        public void Test_AddWithValues_01_Ok(double[] leftPositions, double leftValue, double rightValue, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable resultWithMethod = vector.Add(leftValue, rightValue);

            // Assert
            Assert.AreEqual(expectedResult, resultWithMethod.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, "(0,0)")]
        [TestCase(new double[] { 1, 2 }, 3, "(4,5)")]
        [TestCase(new double[] { -2, 2 }, 4, "(2,6)")]
        public void Test_AddWithValue_01_Ok(double[] leftPositions, double value, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable resultWithValueRight = vector + value;
            VectorImmutable resultWithValueLeft = value + vector;

            // Assert
            Assert.AreEqual(expectedResult, resultWithValueRight.ToString());
            Assert.AreEqual(expectedResult, resultWithValueLeft.ToString());
        }

        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, "(0,0)")]
        [TestCase(new double[] { 3, 2 }, new double[] { 2, 1 }, "(1,1)")]
        [TestCase(new double[] { 4, 2 }, new double[] { 3, 5 }, "(1,-3)")]
        [TestCase(new double[] { -2, 2 }, new double[] { 3, 5 }, "(-5,-3)")]
        public void Test_SubtractWithVector_01_Ok(double[] leftPositions, double[] rightPositions, string expectedResult)
        {
            // Arrange
            VectorImmutable left = new VectorImmutable(leftPositions[0], leftPositions[1]);
            VectorImmutable right = new VectorImmutable(rightPositions[0], rightPositions[1]);

            // Act
            VectorImmutable result = left - right;

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, 0, "(0,0)")]
        [TestCase(new double[] { 0, 0 }, 0, 2, "(0,-2)")]
        [TestCase(new double[] { 5, 2 }, 3, 4, "(2,-2)")]
        [TestCase(new double[] { 5, 2 }, 3, 3, "(2,-1)")]
        [TestCase(new double[] { 6, 2 }, 4, 4, "(2,-2)")]
        public void Test_SubtractWithValues_01_Ok(double[] leftPositions, double leftValue, double rightValue, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable resultWithMethod = vector.Subtract(leftValue, rightValue);

            // Assert
            Assert.AreEqual(expectedResult, resultWithMethod.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, "(0,0)")]
        [TestCase(new double[] { 6, 2 }, 3, "(3,-1)")]
        [TestCase(new double[] { -2, 2 }, 4, "(-6,-2)")]
        public void Test_SubtractWithValue_01_Ok(double[] leftPositions, double value, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable resultWithValueRight = vector - value;
            VectorImmutable resultWithValueLeft = value - vector;

            // Assert
            Assert.AreEqual(expectedResult, resultWithValueRight.ToString());
            Assert.AreEqual(expectedResult, resultWithValueLeft.ToString());
        }

        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, "(0,0)")]
        [TestCase(new double[] { 3, 2 }, new double[] { 2, 1 }, "(6,2)")]
        [TestCase(new double[] { 4, 2 }, new double[] { 3, 5 }, "(12,10)")]
        [TestCase(new double[] { -2, 2 }, new double[] { 3, 5 }, "(-6,10)")]
        public void Test_MultiplyWithVector_01_Ok(double[] leftPositions, double[] rightPositions, string expectedResult)
        {
            // Arrange
            VectorImmutable left = new VectorImmutable(leftPositions[0], leftPositions[1]);
            VectorImmutable right = new VectorImmutable(rightPositions[0], rightPositions[1]);

            // Act
            VectorImmutable result = left * right;

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, 0, "(0,0)")]
        [TestCase(new double[] { 0, 0 }, 0, 2, "(0,0)")]
        [TestCase(new double[] { 5, 2 }, 3, 4, "(15,8)")]
        [TestCase(new double[] { 5, 2 }, 3, 3, "(15,6)")]
        [TestCase(new double[] { 6, 2 }, 4, 4, "(24,8)")]
        public void Test_MultiplyWithValues_01_Ok(double[] leftPositions, double leftValue, double rightValue, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable resultWithMethod = vector.Multiply(leftValue, rightValue);

            // Assert
            Assert.AreEqual(expectedResult, resultWithMethod.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, "(0,0)")]
        [TestCase(new double[] { 2, 2 }, 3, "(6,6)")]
        [TestCase(new double[] { -2, 2 }, 4, "(-8,8)")]
        public void Test_MultiplyWithValue_01_Ok(double[] leftPositions, double value, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable resultWithValueRight = vector * value;
            VectorImmutable resultWithValueLeft = value * vector;

            // Assert
            Assert.AreEqual(expectedResult, resultWithValueRight.ToString());
            Assert.AreEqual(expectedResult, resultWithValueLeft.ToString());
        }

        [TestCase(new double[] { 9, 18 }, 3, "(3,6)")]
        [TestCase(new double[] { 8, 4 }, 2, "(4,2)")]
        public void Test_DivideWithValue_01_Ok(double[] leftPositions, double value, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable result = vector / value;

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 0, 3)]
        [TestCase(0, 4, 3)]
        [TestCase(5, 4, 0)]
        public void Test_DivideWithValue_02_ThrowsExceptionOnDivideByZero(double x, double y, double divider)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(x, y);

            // Act & assert
            Assert.Throws<ArithmeticException>(() =>
            {
                VectorImmutable result = vector / divider;
            });
        }

        [TestCase(new double[] { 9, 18 }, 3, 4, "(3,4.5)")]
        [TestCase(new double[] { 8, 4 }, 2, 1, "(4,4)")]
        public void Test_DivideWithValues_01_Ok(double[] leftPositions, double dividerX, double dividerY, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(leftPositions[0], leftPositions[1]);

            // Act
            VectorImmutable result = vector.Divide(dividerX, dividerY);

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0, 3, 0)]
        [TestCase(0, 0, 0, 3)]
        [TestCase(0, 4, 3, 3)]
        [TestCase(5, 4, 0, 0)]
        public void Test_DivideWithValues_02_ThrowsExceptionOnDivideByZero(double x, double y, double dividerX, double dividerY)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(x, y);

            // Act & assert
            Assert.Throws<ArithmeticException>(() => vector.Divide(dividerX, dividerY));
        }

        [TestCase(0, 0, "(0,0)")]
        [TestCase(2, 2, "(0.71,0.71)")]
        public void Test_Normalize_01_Ok(double x, double y, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(x, y);

            // Act
            VectorImmutable result = vector.Normalize();

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestCase(0, 0, 0, "(0,0)")]
        [TestCase(2, 2, 1, "(0.71,0.71)")]
        public void Test_Truncate_01_Ok(double x, double y, double maxValue, string expectedResult)
        {
            // Arrange
            VectorImmutable vector = new VectorImmutable(x, y);

            // Act
            VectorImmutable result = vector.Truncate(maxValue);

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [Test]
        public void Test_Truncate_02_DoesNotExecuteWhenLengthIsBelowMax()
        {
            // Mocked values
            const int EastPosition = 2,
                NorthPosition = 2,
                ExpectedEastPosition = 2,
                ExpectedNorthPosition = 2;

            // Arrange
            VectorImmutable vector = new VectorImmutable(EastPosition, NorthPosition);

            // Act
            double length = vector.Length;
            VectorImmutable result = vector.Truncate(length + 1);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, result.X);
            Assert.AreEqual(ExpectedNorthPosition, result.Y);
        }

        [Test]
        public void Test_Truncate_02_Ok()
        {
            // Mocked values
            const int EastPosition = 2,
                NorthPosition = 2;
            const double ExpectedEastPosition = 1.2928932188134525d,
                ExpectedNorthPosition = 1.2928932188134525d;

            // Arrange
            VectorImmutable vector = new VectorImmutable(EastPosition, NorthPosition);

            // Act
            double length = vector.Length;
            VectorImmutable result = vector.Truncate(length - 1);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, result.X);
            Assert.AreEqual(ExpectedNorthPosition, result.Y);
        }
    }

    public class VectorTests
    {
        [TestCase(0, 0, "(0,0)")]
        [TestCase(3, 4, "(3,4)")]
        [TestCase(6, 6, "(6,6)")]
        public void Test_Create_01_Ok(double x, double y, string expectedResult)
        {
            // Act
            Vector vector = new Vector(x, y);

            // Assert
            Assert.AreEqual(x, vector.X);
            Assert.AreEqual(y, vector.Y);
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(0, 0, 0)]
        [TestCase(3, 4, 5.0)]
        [TestCase(6, 6, 8.4852813742385695d)]
        public void Test_Length_01_Ok(double x, double y, double expectedResult)
        {
            // Act
            Vector vector = new Vector(x, y);

            // Assert
            Assert.AreEqual(expectedResult, vector.Length());
        }

        [TestCase(0, 0, 0)]
        [TestCase(3, 4, 25.0)]
        [TestCase(6, 6, 72.0)]
        public void Test_LengthSquared_01_Ok(double x, double y, double expectedResult)
        {
            // Act
            Vector vector = new Vector(x, y);

            // Assert
            Assert.AreEqual(expectedResult, vector.LengthSquared());
        }

        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, "(0,0)")]
        [TestCase(new double[] { 1, 2 }, new double[] { 2, 1 }, "(3,3)")]
        [TestCase(new double[] { 1, 2 }, new double[] { 3, 5 }, "(4,7)")]
        [TestCase(new double[] { -2, 2 }, new double[] { 3, 5 }, "(1,7)")]
        public void Test_AddWithVector_01_Ok(double[] leftPositions, double[] rightPositions, string expectedResult)
        {
            // Arrange
            Vector left = new Vector(leftPositions[0], leftPositions[1]);
            Vector right = new Vector(rightPositions[0], rightPositions[1]);

            // Act
            left.Add(right);

            // Assert
            Assert.AreEqual(expectedResult, left.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, 0, "(0,0)")]
        [TestCase(new double[] { 0, 0 }, 0, 2, "(0,2)")]
        [TestCase(new double[] { 1, 2 }, 3, 4, "(4,6)")]
        [TestCase(new double[] { 1, 2 }, 3, 3, "(4,5)")]
        [TestCase(new double[] { -2, 2 }, 4, 4, "(2,6)")]
        public void Test_AddWithValues_01_Ok(double[] leftPositions, double leftValue, double rightValue, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(leftPositions[0], leftPositions[1]);

            // Act
            vector.Add(leftValue, rightValue);

            // Assert
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, "(0,0)")]
        [TestCase(new double[] { 3, 2 }, new double[] { 2, 1 }, "(1,1)")]
        [TestCase(new double[] { 4, 2 }, new double[] { 3, 5 }, "(1,-3)")]
        [TestCase(new double[] { -2, 2 }, new double[] { 3, 5 }, "(-5,-3)")]
        public void Test_SubtractWithVector_01_Ok(double[] leftPositions, double[] rightPositions, string expectedResult)
        {
            // Arrange
            Vector left = new Vector(leftPositions[0], leftPositions[1]);
            Vector right = new Vector(rightPositions[0], rightPositions[1]);

            // Act
            left.Subtract(right);

            // Assert
            Assert.AreEqual(expectedResult, left.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, 0, "(0,0)")]
        [TestCase(new double[] { 0, 0 }, 0, 2, "(0,-2)")]
        [TestCase(new double[] { 5, 2 }, 3, 4, "(2,-2)")]
        [TestCase(new double[] { 5, 2 }, 3, 3, "(2,-1)")]
        [TestCase(new double[] { 6, 2 }, 4, 4, "(2,-2)")]
        public void Test_SubtractWithValues_01_Ok(double[] leftPositions, double leftValue, double rightValue, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(leftPositions[0], leftPositions[1]);

            // Act
            vector.Subtract(leftValue, rightValue);

            // Assert
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0, "(0,0)")]
        [TestCase(new double[] { 6, 2 }, 3, "(3,-1)")]
        [TestCase(new double[] { -2, 2 }, 4, "(-6,-2)")]
        public void Test_SubtractWithValue_01_Ok(double[] leftPositions, double value, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(leftPositions[0], leftPositions[1]);

            // Act
            vector.SubtractX(value);
            vector.SubtractY(value);

            // Assert
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 3, "(0,0)")]
        [TestCase(new double[] { 3, 2 }, 3, "(9,6)")]
        [TestCase(new double[] { 4, 2 }, 3, "(12,6)")]
        [TestCase(new double[] { -2, 2 }, 3, "(-6,6)")]
        public void Test_MultiplyWithValue_01_Ok(double[] positions, double multiplyValue, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(positions[0], positions[1]);

            // Act
            vector.Multiply(multiplyValue);

            // Assert
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 3, "(0,0)")]
        [TestCase(new double[] { 0, 3 }, 3, "(0,1)")]
        [TestCase(new double[] { 4, 0 }, 3, "(1.33,0)")]
        [TestCase(new double[] { 3, 2 }, 3, "(1,0.67)")]
        [TestCase(new double[] { 4, 2 }, 3, "(1.33,0.67)")]
        [TestCase(new double[] { -2, 2 }, 3, "(-0.67,0.67)")]
        public void Test_DivideWithValue_01_Ok(double[] positions, double divider, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(positions[0], positions[1]);

            // Act
            vector.Divide(divider);

            // Assert
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(new double[] { 0, 0 }, 0)]
        public void Test_DivideWithValue_01_ThrowsOnDivideByZero(double[] positions, double divider)
        {
            // Arrange
            Vector vector = new Vector(positions[0], positions[1]);

            // Act & assert
            Assert.Throws<ArithmeticException>(() =>
            {
                Vector result = vector.Divide(divider);
            });
        }

        [TestCase(0, 0, "(0,0)")]
        [TestCase(2, 2, "(0.71,0.71)")]
        public void Test_Normalize_01_Ok(double x, double y, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(x, y);

            // Act
            vector.Normalize();

            // Assert
            Assert.AreEqual(expectedResult, vector.ToString());
        }

        [TestCase(0, 0, 0, "(0,0)")]
        [TestCase(2, 2, 1, "(0.71,0.71)")]
        public void Test_Truncate_01_Ok(double x, double y, double maxValue, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(x, y);

            // Act
            Vector result = vector.Truncate(maxValue);

            // Assert
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [Test]
        public void Test_Truncate_02_DoesNotExecuteWhenLengthIsBelowMax()
        {
            // Mocked values
            const int EastPosition = 2,
                NorthPosition = 2,
                ExpectedEastPosition = 2,
                ExpectedNorthPosition = 2;

            // Arrange
            Vector vector = new Vector(EastPosition, NorthPosition);

            // Act
            double length = vector.Length();
            vector.Truncate(length + 1);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.X);
            Assert.AreEqual(ExpectedNorthPosition, vector.Y);
        }

        [Test]
        public void Test_Truncate_02_Ok()
        {
            // Mocked values
            const int EastPosition = 2,
                NorthPosition = 2;
            const double ExpectedEastPosition = 1.2928932188134525d,
                ExpectedNorthPosition = 1.2928932188134525d;

            // Arrange
            Vector vector = new Vector(EastPosition, NorthPosition);

            // Act
            double length = vector.Length();
            vector.Truncate(length - 1);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.X);
            Assert.AreEqual(ExpectedNorthPosition, vector.Y);
        }

        [Test]
        public void Test_Clone_01_Ok()
        {
            // Arrange
            const double ExpectedEastPosition = 3.0d;
            const double ExpectedNorthPosition = 4.0d;

            // Act
            Vector vector = new Vector(ExpectedEastPosition, ExpectedNorthPosition);
            Vector newVector = vector.Clone();
            newVector.Multiply(2);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.X);
            Assert.AreEqual(ExpectedNorthPosition, vector.Y);
        }
    }
}
