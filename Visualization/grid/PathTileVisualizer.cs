using System;
using System.Drawing;
using Src.grid;

namespace SteeringCS.grid
{
    public static class PathTileVisualizer
    {
        private static readonly Image s_image = Image.FromFile("graphics/mario/mario-right.png");
        private static readonly Image s_image2 = Image.FromFile("graphics/mario/mario-right-walk-1.png");
        private static readonly Image s_image3 = Image.FromFile("graphics/mario/mario-right-walk-2.png");
        public static int toggle = 1;
        public static int togglePlus = 2;
        public static int xPlus = 6;


        public static void Render(Graphics graphic, PathTile pathTile)
        {
            /*Brush brush = new SolidBrush(Color.AliceBlue);
            Rectangle rectangle = new Rectangle((int)pathTile.Position.X, (int)pathTile.Position.Y, pathTile.Size, pathTile.Size);
            graphic.FillRectangle(brush, rectangle);*/
            if (pathTile.Position.Y < 50)
            {

                if (toggle / 100 < 1)
                {
                    graphic.DrawImage(s_image, (int)pathTile.Position.X + (toggle / xPlus), (int)pathTile.Position.Y);
                    toggle += togglePlus;
                }

                if (toggle / 100 == 1)
                {
                    graphic.DrawImage(s_image2, (int)pathTile.Position.X + (toggle / xPlus), (int)pathTile.Position.Y);
                    toggle += togglePlus;
                }

                if (toggle / 100 == 2)
                {
                    graphic.DrawImage(s_image3, (int)pathTile.Position.X + (toggle / xPlus), (int)pathTile.Position.Y);
                    toggle += togglePlus;
                }

                if (toggle / 100 == 3)
                {
                    graphic.DrawImage(s_image2, (int)pathTile.Position.X + (toggle / xPlus), (int)pathTile.Position.Y);
                    toggle += togglePlus;
                }

                if (toggle >= 400)
                {
                    toggle = 1;
                }
            }
        }
    }
}
