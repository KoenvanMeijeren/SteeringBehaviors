using System;
using NUnit.Framework;
using SteeringCS.util;

namespace SteeringCSTests
{
    public class Tests
    {
        [Test]
        public void Test_CreateEmpty_01_Ok()
        {
            // Arrange
            const int ExpectedEastPosition = 0;
            const int ExpectedNorthPosition = 0;

            // Act
            var vector = new Vector2D();

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_CreateNotEmpty_02_Ok()
        {
            // Arrange
            const int ExpectedEastPosition = 4;
            const int ExpectedNorthPosition = 5;

            // Act
            var vector = new Vector2D(ExpectedEastPosition, ExpectedNorthPosition);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_LengthEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0, NorthPosition = 0;

            // Arrange
            const int ExpectedLength = 0;

            // Act
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Assert
            Assert.AreEqual(ExpectedLength, vector.Length());
        }
        
        [Test]
        public void Test_LengthSame_02_Ok()
        {
            // Mocked values
            const int EastPosition = 6, NorthPosition = 6;

            // Arrange
            var expectedLength = Math.Sqrt((EastPosition * EastPosition) + (NorthPosition * NorthPosition));

            // Act
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Assert
            Assert.AreEqual(expectedLength, vector.Length());
        }
        
        [Test]
        public void Test_LengthDifferent_03_Ok()
        {
            // Mocked values
            const int EastPosition = 4, NorthPosition = 6;

            // Arrange
            var expectedLength = Math.Sqrt((EastPosition * EastPosition) + (NorthPosition * NorthPosition));

            // Act
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Assert
            Assert.AreEqual(expectedLength, vector.Length());
        }
        
        [Test]
        public void Test_LengthSquaredEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0, NorthPosition = 0;

            // Arrange
            const double ExpectedLength = (EastPosition * EastPosition) + (NorthPosition * NorthPosition);

            // Act
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Assert
            Assert.AreEqual(ExpectedLength, vector.LengthSquared());
        }
        
        [Test]
        public void Test_LengthSquaredSame_02_Ok()
        {
            // Mocked values
            const int EastPosition = 6, NorthPosition = 6;

            // Arrange
            const double ExpectedLength = (EastPosition * EastPosition) + (NorthPosition * NorthPosition);

            // Act
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Assert
            Assert.AreEqual(ExpectedLength, vector.LengthSquared());
        }
        
        [Test]
        public void Test_LengthSquaredDifferent_03_Ok()
        {
            // Mocked values
            const int EastPosition = 4, NorthPosition = 6;

            // Arrange
            const double ExpectedLength = (EastPosition * EastPosition) + (NorthPosition * NorthPosition);

            // Act
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Assert
            Assert.AreEqual(ExpectedLength, vector.LengthSquared());
        }
        
        [Test]
        public void Test_AddEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0, 
                NorthPosition = 0, 
                AddEastPosition = 0, 
                AddNorthPosition = 0;

            const int ExpectedEastPosition = EastPosition + AddEastPosition;
            const int ExpectedNorthPosition = NorthPosition + AddNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToAdd = new Vector2D(AddEastPosition, AddNorthPosition);

            // Act
            vector.Add(vectorToAdd);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_AddDifferent_02_Ok()
        {
            // Mocked values
            const int EastPosition = 1, 
                NorthPosition = 2, 
                AddEastPosition = 3, 
                AddNorthPosition = 5;

            const int ExpectedEastPosition = EastPosition + AddEastPosition;
            const int ExpectedNorthPosition = NorthPosition + AddNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToAdd = new Vector2D(AddEastPosition, AddNorthPosition);

            // Act
            vector.Add(vectorToAdd);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_AddSame_03_Ok()
        {
            // Mocked values
            const int EastPosition = 2, 
                NorthPosition = 2, 
                AddEastPosition = 2, 
                AddNorthPosition = 2;

            const int ExpectedEastPosition = EastPosition + AddEastPosition;
            const int ExpectedNorthPosition = NorthPosition + AddNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToAdd = new Vector2D(AddEastPosition, AddNorthPosition);

            // Act
            vector.Add(vectorToAdd);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_AddNegative_04_Ok()
        {
            // Mocked values
            const int EastPosition = 2, 
                NorthPosition = 2, 
                AddEastPosition = -3, 
                AddNorthPosition = 5;

            const int ExpectedEastPosition = EastPosition + AddEastPosition;
            const int ExpectedNorthPosition = NorthPosition + AddNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToAdd = new Vector2D(AddEastPosition, AddNorthPosition);

            // Act
            vector.Add(vectorToAdd);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_SubtractEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0, 
                NorthPosition = 0, 
                AddEastPosition = 0, 
                AddNorthPosition = 0;

            const int ExpectedEastPosition = EastPosition + AddEastPosition;
            const int ExpectedNorthPosition = NorthPosition + AddNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToSubtract = new Vector2D(AddEastPosition, AddNorthPosition);

            // Act
            vector.Subtract(vectorToSubtract);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_SubtractDifferent_02_Ok()
        {
            // Mocked values
            const int EastPosition = 1, 
                NorthPosition = 2, 
                SubtractEastPosition = 3, 
                SubtractNorthPosition = 5;

            const int ExpectedEastPosition = EastPosition - SubtractEastPosition;
            const int ExpectedNorthPosition = NorthPosition - SubtractNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToSubtract = new Vector2D(SubtractEastPosition, SubtractNorthPosition);

            // Act
            vector.Subtract(vectorToSubtract);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_SubtractSame_03_Ok()
        {
            // Mocked values
            const int EastPosition = 2, 
                NorthPosition = 2, 
                SubtractEastPosition = 2, 
                SubtractNorthPosition = 2;

            const int ExpectedEastPosition = EastPosition - SubtractEastPosition;
            const int ExpectedNorthPosition = NorthPosition - SubtractNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToSubtract = new Vector2D(SubtractEastPosition, SubtractNorthPosition);

            // Act
            vector.Subtract(vectorToSubtract);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_SubtractNegative_04_Ok()
        {
            // Mocked values
            const int EastPosition = 2, 
                NorthPosition = 2, 
                SubtractEastPosition = -3, 
                SubtractNorthPosition = 5;

            const int ExpectedEastPosition = EastPosition - SubtractEastPosition;
            const int ExpectedNorthPosition = NorthPosition - SubtractNorthPosition;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);
            var vectorToSubtract = new Vector2D(SubtractEastPosition, SubtractNorthPosition);

            // Act
            vector.Subtract(vectorToSubtract);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_MultiplyEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0, 
                NorthPosition = 0, 
                MultipleValue = 0;

            const int ExpectedEastPosition = EastPosition * MultipleValue;
            const int ExpectedNorthPosition = NorthPosition * MultipleValue;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            vector.Multiply(MultipleValue);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_Multiply_02_Ok()
        {
            // Mocked values
            const int EastPosition = 2, 
                NorthPosition = 1, 
                MultipleValue = 2;

            const int ExpectedEastPosition = EastPosition * MultipleValue;
            const int ExpectedNorthPosition = NorthPosition * MultipleValue;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            vector.Multiply(MultipleValue);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_DivideEmpty_01_ThrowsExceptionOnDivideByZero()
        {
            // Mocked values
            const int EastPosition = 0, 
                NorthPosition = 0, 
                DivideValue = 0;

            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act & assert
            Assert.Throws<ArithmeticException>(() => vector.Divide(DivideValue));
        }
        
        [Test]
        public void Test_DivideEmptyVectorWithNonEmptyDivideValue_02_Ok()
        {
            // Mocked values
            const int EastPosition = 0, 
                NorthPosition = 0, 
                DivideValue = 2;

            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act & assert
            vector.Divide(DivideValue);
        }
        
        [Test]
        public void Test_Divide_02_Ok()
        {
            // Mocked values
            const int EastPosition = 2, 
                NorthPosition = 1, 
                MultipleValue = 2;

            const int ExpectedEastPosition = EastPosition * MultipleValue;
            const int ExpectedNorthPosition = NorthPosition * MultipleValue;
            
            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            vector.Multiply(MultipleValue);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_NormalizeEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0,
                NorthPosition = 0,
                ExpectedEastPosition = 0,
                ExpectedNorthPosition = 0;

            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            vector.Normalize();
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_Normalize_02_Ok()
        {
            // Mocked values
            const int EastPosition = 2,
                NorthPosition = 2;
            const double ExpectedEastPosition = 0.70710678118654746d,
                ExpectedNorthPosition = 0.70710678118654746d;

            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            vector.Normalize();
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_TruncateEmpty_01_Ok()
        {
            // Mocked values
            const int EastPosition = 0,
                NorthPosition = 0,
                ExpectedEastPosition = 0,
                ExpectedNorthPosition = 0;

            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            vector.Truncate(0);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_Truncate_01_DoesNotExecuteWhenLengthIsBelowMax()
        {
            // Mocked values
            const int EastPosition = 2,
                NorthPosition = 2,
                ExpectedEastPosition = 2,
                ExpectedNorthPosition = 2;

            // Arrange
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            var length = vector.Length();
            vector.Truncate(length + 1);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
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
            var vector = new Vector2D(EastPosition, NorthPosition);

            // Act
            var length = vector.Length();
            vector.Truncate(length - 1);
            
            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_Clone_01_Ok()
        {
            // Arrange
            const int ExpectedEastPosition = 0;
            const int ExpectedNorthPosition = 0;

            // Act
            var vector = new Vector2D();
            var newVector = vector.Clone();
            newVector.Multiply(2);

            // Assert
            Assert.AreEqual(ExpectedEastPosition, vector.EastPosition);
            Assert.AreEqual(ExpectedNorthPosition, vector.NorthPosition);
        }
        
        [Test]
        public void Test_ToString_01_Ok()
        {
            // Arrange
            const string ExpectedString = "(0,0)";

            // Act
            var vector = new Vector2D();

            // Assert
            Assert.AreEqual(ExpectedString, vector.ToString());
        }
    }
}
