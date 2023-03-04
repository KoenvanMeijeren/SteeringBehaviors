using System.Drawing;

namespace SteeringCS.grid
{
    public class WallTile : GridTile
    {
        private readonly Image _image = Image.FromFile("grid/wall.png");

        public WallTile(int size, int x, int y) : base(size, x, y)
        {

        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawImage(_image, (int) Position.X, (int) Position.Y);
        }
    }
}
