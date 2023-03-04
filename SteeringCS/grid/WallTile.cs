﻿using SteeringCS.world;
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
        private readonly Image _image = Image.FromFile("grid/wall.png");

        public WallTile(int size, int x, int y) : base(size, x, y)
        {

        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawImage(_image, Position.X, Position.Y);
        }
    }
}
