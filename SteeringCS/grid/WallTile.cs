using SteeringCS.world;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.grid
{
    public class WallTile : GridTile
    {
        private Image image = Image.FromFile("C:\\Users\\jobva\\OneDrive\\Bureaublad\\School\\Leerjaar 3\\AAI\\Week 1\\SteeringBehaviors\\SteeringCS\\grid\\testtile.png");

        public WallTile(int size, int x, int y) : base(size, x, y)
        {

        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawImage(image, Position.X, Position.Y);
        }
    }
}
