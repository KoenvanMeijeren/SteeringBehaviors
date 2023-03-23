using System;
using NUnit.Framework;
using Src.util;

namespace Tests.util
{
    public class AheadPositionsUtilTests
    {
        [TestCase(new double[] { 150, 100 }, true, true, true, "((150,100), (118,132), (182,132))")]
        [TestCase(new double[] { 150, 100 }, true, true, false, "((150,100), (182,68), (182,132))")]
        [TestCase(new double[] { 150, 100 }, true, false, false, "((150,100), (182,68), (182,132))")]
        [TestCase(new double[] { 150, 100 }, true, false, true, "((150,100), (118,132), (182,132))")]
        [TestCase(new double[] { 150, 100 }, false, true, true, "((150,100), (182,132), (118,132))")]
        [TestCase(new double[] { 150, 100 }, false, true, false, "((150,100), (182,68), (118,68))")]
        [TestCase(new double[] { 150, 100 }, false, false, true, "((150,100), (182,132), (118,132))")]
        [TestCase(new double[] { 150, 100 }, false, false, false, "((150,100), (118,68), (118,132))")]
        public void Generate_01_Ok(double[] positions, bool isDirectionRight, bool isDirectionUpwards, bool isDirectionDownwards, string expectedResult)
        {
            // Arrange
            Vector vector = new Vector(positions[0], positions[1]);

            // Act
            Tuple<Vector, Vector, Vector> result = AheadPositionsUtil.Generate(vector, isDirectionRight, isDirectionUpwards, isDirectionDownwards);

            // Assert
            Assert.That(result.ToString(), Is.EqualTo(expectedResult));
        }
    }
}
