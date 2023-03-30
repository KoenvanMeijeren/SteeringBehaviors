using NUnit.Framework;
using Visualization.util;

namespace Tests.util
{
    public class KeyHandlerTests
    {
        [Test]
        public void WKeyPressed_01_SingleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.W);
            Assert.AreEqual("(0,-20)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.W);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void WKeyPressed_01_MultipleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.W);
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            Assert.AreEqual("(0,-20)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.W);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void AKeyPressed_01_SingleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.A);
            Assert.AreEqual("(-20,0)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.A);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void AKeyPressed_01_MultipleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.A);
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            Assert.AreEqual("(-20,0)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.A);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void SKeyPressed_01_SingleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.S);
            Assert.AreEqual("(0,20)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.S);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void SKeyPressed_01_MultipleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.S);
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            Assert.AreEqual("(0,20)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.S);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void DKeyPressed_01_SingleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.D);
            Assert.AreEqual("(20,0)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.D);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }

        [Test]
        public void DKeyPressed_02_MultipleOk()
        {
            // Arrange
            KeyHandler.Reset();

            // Act & assert
            KeyHandler.RegisterPressedKeys(PressedKey.D);
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            KeyHandler.GetKeysDirection();
            Assert.AreEqual("(20,0)", KeyHandler.GetKeysDirection().ToString());
            KeyHandler.RegisterUnpressedKeys(PressedKey.D);
            Assert.AreEqual("(0,0)", KeyHandler.GetKeysDirection().ToString());
        }
    }
}
