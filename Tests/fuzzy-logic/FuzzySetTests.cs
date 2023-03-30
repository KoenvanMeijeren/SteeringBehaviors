using System.Globalization;
using NUnit.Framework;
using Src.fuzzy_logic.Set;

namespace Tests.fuzzy_logic
{
    public class FuzzySetLeftShoulderTests
    {
        [TestCase(0, 0, 0, 0, 0.0, "1.00")]
        [TestCase(0, 0, 0.5, 0, 0.0, "1.00")]
        [TestCase(0, 0.3, 0, 0, -0.14999999999999999d, "1.00")]
        [TestCase(0, 0.25, 0.5, 0, -0.125, "1.00")]
        [TestCase(0, 0.25, 0.5, 0.1, -0.125, "0.80")]
        [TestCase(0, 0.25, 0.5, 0.2, -0.125, "0.60")]
        [TestCase(0, 0.25, 0.5, 0.3, -0.125, "0.40")]
        [TestCase(0, 0.25, 0.5, 0.4, -0.125, "0.20")]
        [TestCase(0, 0.25, 0.5, 0.5, -0.125, "0.00")]
        [TestCase(0, 0.25, 0.5, 0.6, -0.125, "0.00")]
        [TestCase(0, 0.25, 0.5, 0.7, -0.125, "0.00")]
        [TestCase(0, 0.25, 0.5, 0.8, -0.125, "0.00")]
        [TestCase(0, 0.25, 0.5, 0.9, -0.125, "0.00")]
        [TestCase(0, 0.25, 0.5, 1.0, -0.125, "0.00")]
        [TestCase(0.25, 0.75, 0.5, 0.20, -0.125, "1.00")]
        public void Create_01_Ok(double peak, double leftOffset, double rightOffset, double dom, double expectedRepresentativeValue, string expectedResult)
        {
            // Arrange
            FuzzySetLeftShoulder leftShoulder = new(peak, rightOffset, leftOffset);
            
            // Act
            string result = leftShoulder.CalculateDom(dom).ToString("N2", CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual(peak, leftShoulder.PeakPoint);
            Assert.AreEqual(leftOffset, leftShoulder.LeftOffset);
            Assert.AreEqual(rightOffset, leftShoulder.RightOffset);
            Assert.AreEqual(0, leftShoulder.DegreeOfMembership);
            Assert.AreEqual(expectedRepresentativeValue, leftShoulder.RepresentativeValue);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySetLeftShoulder leftShoulder = new(15, 30, 0);

            // Act & assert
            leftShoulder.OrWithDom(10);
            Assert.AreEqual(10, leftShoulder.DegreeOfMembership);
            leftShoulder.OrWithDom(5);
            Assert.AreEqual(10, leftShoulder.DegreeOfMembership);
            leftShoulder.OrWithDom(30);
            Assert.AreEqual(30, leftShoulder.DegreeOfMembership);
        }
        
        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySetLeftShoulder leftShoulder = new(15, 30, 0);

            // Act & assert
            leftShoulder.OrWithDom(10);
            Assert.AreEqual(10, leftShoulder.DegreeOfMembership);
            leftShoulder.ResetDom();
            Assert.AreEqual(0, leftShoulder.DegreeOfMembership);
        }
    }
    
    public class FuzzySetRightShoulderTests
    {
        [TestCase(0, 0, 0, 0, 0.0, "1.00")]
        [TestCase(0, 0, 0.5, 0, 0.25, "1.00")]
        [TestCase(0, 0.3, 0, 0, 0.0, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0, 0.8, "0.40")]
        [TestCase(0.3, 0.5, 1.0, 0.1, 0.8, "0.60")]
        [TestCase(0.3, 0.5, 1.0, 0.2, 0.8, "0.80")]
        [TestCase(0.3, 0.5, 1.0, 0.3, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0.4, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0.5, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0.6, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0.7, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0.8, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 0.9, 0.8, "1.00")]
        [TestCase(0.3, 0.5, 1.0, 1.0, 0.8, "1.00")]
        public void Create_01_Ok(double peak, double leftOffset, double rightOffset, double dom, double expectedRepresentativeValue, string expectedResult)
        {
            // Arrange
            FuzzySetRightShoulder rightShoulder = new(peak, rightOffset, leftOffset);
            
            // Act
            string result = rightShoulder.CalculateDom(dom).ToString("N2", CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual(peak, rightShoulder.PeakPoint);
            Assert.AreEqual(leftOffset, rightShoulder.LeftOffset);
            Assert.AreEqual(rightOffset, rightShoulder.RightOffset);
            Assert.AreEqual(0, rightShoulder.DegreeOfMembership);
            Assert.AreEqual(expectedRepresentativeValue, rightShoulder.RepresentativeValue);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySetRightShoulder rightShoulder = new(15, 30, 0);

            // Act & assert
            rightShoulder.OrWithDom(10);
            Assert.AreEqual(10, rightShoulder.DegreeOfMembership);
            rightShoulder.OrWithDom(5);
            Assert.AreEqual(10, rightShoulder.DegreeOfMembership);
            rightShoulder.OrWithDom(30);
            Assert.AreEqual(30, rightShoulder.DegreeOfMembership);
        }
        
        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySetRightShoulder rightShoulder = new(15, 30, 0);

            // Act & assert
            rightShoulder.OrWithDom(10);
            Assert.AreEqual(10, rightShoulder.DegreeOfMembership);
            rightShoulder.ResetDom();
            Assert.AreEqual(0, rightShoulder.DegreeOfMembership);
        }
    }
    
    public class FuzzySetTriangleTests
    {
        [TestCase(0, 0, 0.0, 0, 0.0, "1.00")]
        [TestCase(0, 0, 0.5, 0, 0.0, "1.00")]
        [TestCase(0, 0.3, 0, 0, 0.0, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0, 0.1, "0.67")]
        [TestCase(0.1, 0.3, 0.5, 0.1, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.2, 0.1, "0.80")]
        [TestCase(0.1, 0.3, 0.5, 0.3, 0.1, "0.60")]
        [TestCase(0.1, 0.3, 0.5, 0.4, 0.1, "0.40")]
        [TestCase(0.1, 0.3, 0.5, 0.5, 0.1, "0.20")]
        [TestCase(0.1, 0.3, 0.5, 0.6, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 0.7, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 0.8, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 0.9, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 1.0, 0.1, "0.00")]
        public void Create_01_Ok(double midPoint, double leftOffset, double rightOffset, double dom, double expectedRepresentativeValue, string expectedResult)
        {
            // Arrange
            FuzzySetTriangle triangle = new(midPoint, rightOffset, leftOffset);
            
            // Act
            string result = triangle.CalculateDom(dom).ToString("N2", CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual(midPoint, triangle.MidPoint);
            Assert.AreEqual(leftOffset, triangle.LeftOffset);
            Assert.AreEqual(rightOffset, triangle.RightOffset);
            Assert.AreEqual(0, triangle.DegreeOfMembership);
            Assert.AreEqual(expectedRepresentativeValue, triangle.RepresentativeValue);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySetTriangle triangle = new(15, 30, 0);

            // Act & assert
            triangle.OrWithDom(10);
            Assert.AreEqual(10, triangle.DegreeOfMembership);
            triangle.OrWithDom(5);
            Assert.AreEqual(10, triangle.DegreeOfMembership);
            triangle.OrWithDom(30);
            Assert.AreEqual(30, triangle.DegreeOfMembership);
        }
        
        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySetTriangle triangle = new(15, 30, 0);

            // Act & assert
            triangle.OrWithDom(10);
            Assert.AreEqual(10, triangle.DegreeOfMembership);
            triangle.ResetDom();
            Assert.AreEqual(0, triangle.DegreeOfMembership);
        }
    }
    
    public class FuzzySetSingletonTests
    {
        [TestCase(0, 0, 0, 0, 0.0, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.1, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.2, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.3, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.4, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.5, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.6, 0.1, "1.00")]
        [TestCase(0.1, 0.3, 0.5, 0.7, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 0.8, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 0.9, 0.1, "0.00")]
        [TestCase(0.1, 0.3, 0.5, 1.0, 0.1, "0.00")]
        public void Create_01_Ok(double midPoint, double leftOffset, double rightOffset, double dom, double expectedRepresentativeValue, string expectedResult)
        {
            // Arrange
            FuzzySetSingleton singleton = new(midPoint, rightOffset, leftOffset);
            
            // Act
            string result = singleton.CalculateDom(dom).ToString("N2", CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual(midPoint, singleton.MidPoint);
            Assert.AreEqual(leftOffset, singleton.LeftOffset);
            Assert.AreEqual(rightOffset, singleton.RightOffset);
            Assert.AreEqual(0, singleton.DegreeOfMembership);
            Assert.AreEqual(expectedRepresentativeValue, singleton.RepresentativeValue);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void OrWithDom_01_Ok()
        {
            // Arrange
            FuzzySetSingleton singleton = new(15, 30, 0);

            // Act & assert
            singleton.OrWithDom(10);
            Assert.AreEqual(10, singleton.DegreeOfMembership);
            singleton.OrWithDom(5);
            Assert.AreEqual(10, singleton.DegreeOfMembership);
            singleton.OrWithDom(30);
            Assert.AreEqual(30, singleton.DegreeOfMembership);
        }
        
        [Test]
        public void ResetDom_01_Ok()
        {
            // Arrange
            FuzzySetSingleton singleton = new(15, 30, 0);

            // Act & assert
            singleton.OrWithDom(10);
            Assert.AreEqual(10, singleton.DegreeOfMembership);
            singleton.ResetDom();
            Assert.AreEqual(0, singleton.DegreeOfMembership);
        }
    }
}
