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
            for (int y = 0; y < grid.Tiles.GetLength(0); y++)
            {
                for (int x = 0; x < grid.Tiles.GetLength(1); x++)
                {
                    GridTile gridTile = grid.Tiles[x, y];

                    if (gridTile is PathTile pathTile)
                    {
                        PathTileVisualizer.Render(graphic, pathTile);
                    }
                }
            }

            for (int y = 0; y < grid.Tiles.GetLength(0); y++)
            {
                for (int x = 0; x < grid.Tiles.GetLength(1); x++)
                {
                    GridTile gridTile = grid.Tiles[x, y];

                    if (gridTile is WallTile wallTile)
                    {
                        WallTileVisualizer.Render(graphic, wallTile);
                    }
                }

                for (int x = 0; x < grid.Tiles.GetLength(1); x++)
                {
                    GridTile gridTile = grid.Tiles[x, y];

                    if (gridTile is PathTile pathTile)
                    {
                        PathTileVisualizer.RenderEntities(graphic, pathTile);
                    }
                }
            }
        }

        public static void RenderOutline(Graphics graphic, IGrid grid)
        {
            Pen penDefault = new Pen(s_renderColor);
            Pen penActive = new Pen(s_renderColor, 3);
            Rectangle rectangle = new Rectangle(0, 0, grid.TileSize, grid.TileSize);

            for (int x = 0; x < grid.Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < grid.Tiles.GetLength(1); y++)
                {
                    GridTile gridTile = grid.Tiles[x, y];

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
