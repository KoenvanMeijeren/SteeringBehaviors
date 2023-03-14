using System.Drawing;
using Src.grid;
using SteeringCS.graph;

namespace SteeringCS.grid
{
    public static class GridVisualizer
    {
        private static readonly Color s_renderColor = Color.SeaGreen;

        public static void Render(Graphics graphic, IGrid grid)
        {
            for (int row = 0; row < grid.Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < grid.Tiles.GetLength(1); column++)
                {
                    GridTile gridTile = grid.Tiles[row, column];
                    switch (gridTile)
                    {
                        case PathTile pathTile:
                            PathTileVisualizer.Render(graphic, pathTile);
                            break;
                        case WallTile wallTile:
                            WallTileVisualizer.Render(graphic, wallTile);
                            break;
                    }
                }
            }
        }

        public static void RenderOutline(Graphics graphic, IGrid grid)
        {
            Pen penDefault = new Pen(s_renderColor);
            Pen penActive = new Pen(s_renderColor, 3);
            Rectangle rectangle = new Rectangle(0, 0, grid.TileSize, grid.TileSize);

            for (int row = 0; row < grid.Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < grid.Tiles.GetLength(1); column++)
                {
                    GridTile gridTile = grid.Tiles[row, column];

                    rectangle.X = (int)gridTile.Position.X;
                    rectangle.Y = (int)gridTile.Position.Y;

                    if (gridTile is PathTile pathTile && !pathTile.IsEmpty())
                    {
                        graphic.DrawRectangle(penActive, rectangle);
                        continue;
                    }

                    graphic.DrawRectangle(penDefault, rectangle);
                }
            }
        }

        public static void RenderGraph(Graphics graphic, IGrid grid)
        {
            GraphVisualizer.Render(graphic, grid.Graph);
        }
    }
}
