using NUnit.Framework;
using Src.grid;
using Src.util;

namespace Tests.grid
{
    public class GridTileTests
    {
        [TestCase(3, 5, 5)]
        [TestCase(5, 15, 15)]
        public void Create_PathTile_Ok(int size, int x, int y)
        {
            // Arrange & Act
            PathTile pathTile = new PathTile(size, x, y);
            Vector positionCenter = new Vector(x + size / 2, y + size / 2);
            Vector positionEnd = new Vector(x + size, y + size);

            // Assert
            Assert.That(pathTile.IsEmpty, Is.True);
            Assert.That(pathTile.Entities.Count, Is.EqualTo(0));
            Assert.That(pathTile.Size, Is.EqualTo(size));
            Assert.That(pathTile.Position.X, Is.EqualTo(x));
            Assert.That(pathTile.Position.Y, Is.EqualTo(y));
            Assert.That(pathTile.PositionCenter.ToString(), Is.EqualTo(positionCenter.ToString()));
            Assert.That(pathTile.PositionEnd.ToString(), Is.EqualTo(positionEnd.ToString()));
        }

        [TestCase(3, 5, 5)]
        public void Create_WallTile_Ok(int size, int x, int y)
        {
            // Arrange & Act
            GridTile pathTile = new WallTile(size, x, y);
            Vector positionCenter = new Vector(x + size / 2, y + size / 2);
            Vector positionEnd = new Vector(x + size, y + size);

            // Assert
            Assert.That(pathTile.Size, Is.EqualTo(size));
            Assert.That(pathTile.Position.X, Is.EqualTo(x));
            Assert.That(pathTile.Position.Y, Is.EqualTo(y));
            Assert.That(pathTile.PositionCenter.ToString(), Is.EqualTo(positionCenter.ToString()));
            Assert.That(pathTile.PositionEnd.ToString(), Is.EqualTo(positionEnd.ToString()));
        }
    }
}
