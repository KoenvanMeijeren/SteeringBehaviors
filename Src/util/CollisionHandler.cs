using Src.grid;
using Src.world;

namespace Src.util
{
    public static class CollisionHandler
    {
        public static void AlterVectorToStayInsideOfWorld(Vector position, Vector vector, IWorld world)
        {
            Vector targetPosition = position.Clone().Add(vector);

            int maxY = world.Height;
            int maxX = world.Width;

            if (targetPosition.Y < 0)
            {
                vector.SubtractY(targetPosition.Y);
            }

            if (targetPosition.X < 0)
            {
                vector.SubtractX(targetPosition.X);
            }

            if (targetPosition.Y > maxY)
            {
                vector.SubtractY(targetPosition.Y - maxY);
            }

            if (targetPosition.X > maxX)
            {
                vector.SubtractX(targetPosition.X - maxX);
            }
        }

        public static void AlterVectorToStayOutOfWalls(Vector position, Vector vector, IGrid grid)
        {
            // Check if target position is in a wall tile
            Vector targetPosition = position.Clone().Add(vector);

            int tileX = grid.GetCoordinateOfTile((int)targetPosition.X);
            int tileY = grid.GetCoordinateOfTile((int)targetPosition.Y);

            GridTile gridTile = grid.GetTile(tileX, tileY);

            if (gridTile == null || !(gridTile is WallTile))
            {
                return;
            }

            WallTile wallTile = (WallTile)gridTile;

            // Calculate distance of every direction from center of encountering block
            int halfWallTileSize = wallTile.Size / 2;
            int measureBuffer = 1;

            int wallTileCenterX = (int)wallTile.Position.X + halfWallTileSize;
            int wallTileCenterY = (int)wallTile.Position.Y + halfWallTileSize;

            double northDistanceFromWallTileCenter = wallTileCenterY - position.Y + measureBuffer;
            double eastDistanceFromWallTileCenter = position.X - wallTileCenterX + measureBuffer;
            double southDistanceFromWallTileCenter = position.Y - wallTileCenterY + measureBuffer;
            double westDistanceFromWallTileCenter = wallTileCenterX - position.X + measureBuffer;

            GridTile gridTileNorth = grid.GetTile(tileX, tileY - 1);
            GridTile gridTileEast = grid.GetTile(tileX + 1, tileY);
            GridTile gridTileSouth = grid.GetTile(tileX, tileY + 1);
            GridTile gridTileWest = grid.GetTile(tileX - 1, tileY);

            // Handle encountering north east corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileEast is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (gridTileNorth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    return;
                }

                if (gridTileEast is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (northDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                return;
            }

            // Handle encountering south east corner
            if (southDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileEast is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (gridTileSouth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                    return;
                }

                if (gridTileEast is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (southDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                return;
            }

            // Handle encountering south west corner
            if (southDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileWest is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (gridTileSouth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    return;
                }

                if (gridTileWest is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                if (southDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                    return;
                }

                vector.SubtractX(targetPosition.X - gridTile.Position.X);
                return;
            }

            // Handle encountering north west corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileWest is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (gridTileNorth is WallTile)
                {
                    vector.SubtractX(targetPosition.X - gridTile.Position.X);
                    return;
                }

                if (gridTileWest is WallTile)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                if (northDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                    return;
                }

                vector.SubtractX(targetPosition.X - gridTile.Position.X);
                return;
            }

            // Handle encountering north wall
            if (northDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractY(targetPosition.Y - gridTile.Position.Y);
                return;
            }

            // Handle encountering east wall
            if (eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
                return;
            }

            // Handle encountering south wall
            if (southDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
                return;
            }

            // Handle encountering west wall
            if (westDistanceFromWallTileCenter > halfWallTileSize)
            {
                vector.SubtractX(targetPosition.X - gridTile.Position.X);
                return;
            }
        }
    }
}
