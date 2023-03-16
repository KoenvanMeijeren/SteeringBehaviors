using NUnit.Framework;
using Src.util;
using Tests.fixtures.world;

namespace Tests.util
{
    public class HitBoxTests
    {
        [Test]
        public void Create_01_NotEmptyOk()
        {
            // Arrange
            Vector seekingEntityPosition = new Vector(35, 35);
            Vector targetEntityPosition = new Vector(249, 249);
            WorldTest world = new WorldTest(250, 250, seekingEntityPosition, targetEntityPosition);
            HitBox hitBox = world.SeekingEntity.HitBox;

            // Act & assert
            Assert.AreEqual("(30,30)", hitBox.UpperLeftCorner.ToString());
            Assert.AreEqual("(40,30)", hitBox.UpperRightCorner.ToString());
            Assert.AreEqual("(30,40)", hitBox.LowerLeftCorner.ToString());
            Assert.AreEqual("(40,40)", hitBox.LowerRightCorner.ToString());
        }

        [Test]
        public void Create_02_EmptyOk()
        {
            // Arrange
            HitBox hitBox = new HitBox(null);

            // Act & assert
            Assert.IsNull(hitBox.UpperLeftCorner);
            Assert.IsNull(hitBox.UpperRightCorner);
            Assert.IsNull(hitBox.LowerLeftCorner);
            Assert.IsNull(hitBox.LowerRightCorner);
        }
    }
}
