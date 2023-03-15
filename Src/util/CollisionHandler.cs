using Src.grid;
using Src.world;

namespace Src.util
{
    public static class CollisionHandler
    {
        public static Vector AlterVectorToStayInsideOfWorld(Vector position, Vector vector, IWorld world)
        {
            Vector alteredVector = vector.Clone();
            Vector targetPosition = position.Clone().Add(vector);

            int maxY = world.Height;
            int maxX = world.Width;

            if (targetPosition.Y < 0)
            {
                alteredVector.SubtractY(targetPosition.Y);
            }

            if (targetPosition.X < 0)
            {
                alteredVector.SubtractX(targetPosition.X);
            }

            if (targetPosition.Y > maxY)
            {
                alteredVector.SubtractY(targetPosition.Y - maxY);
            }

            if (targetPosition.X > maxX)
            {
                alteredVector.SubtractX(targetPosition.X - maxX);
            }

            return alteredVector;
        }

        public static Vector AlterVectorToStayOutOfWalls(Vector centerPosition, Vector position, Vector vector, IGrid grid)
        {
            Vector alteredVector = vector.Clone();

            // Check if target position is in a wall tile
            Vector targetPosition = position.Clone().Add(vector);

            int tileX = grid.GetCoordinateOfTile((int)targetPosition.X);
            int tileY = grid.GetCoordinateOfTile((int)targetPosition.Y);

            GridTile gridTile = grid.GetTile(tileX, tileY);

            if (gridTile == null || !(gridTile is WallTile))
            {
                return alteredVector;
            }

            WallTile wallTile = (WallTile)gridTile;

            // Calculate distance of every direction from center of encountering block
            int halfWallTileSize = wallTile.Size / 2;
            const int MeasureBuffer = 1;

            int wallTileCenterX = (int)wallTile.Position.X + halfWallTileSize;
            int wallTileCenterY = (int)wallTile.Position.Y + halfWallTileSize;

            double northDistanceFromWallTileCenter = wallTileCenterY - centerPosition.Y + MeasureBuffer;
            double eastDistanceFromWallTileCenter = centerPosition.X - wallTileCenterX + MeasureBuffer;
            double southDistanceFromWallTileCenter = centerPosition.Y - wallTileCenterY + MeasureBuffer;
            double westDistanceFromWallTileCenter = wallTileCenterX - centerPosition.X + MeasureBuffer;

            GridTile gridTileNorth = grid.GetTile(tileX, tileY - 1);
            GridTile gridTileEast = grid.GetTile(tileX + 1, tileY);
            GridTile gridTileSouth = grid.GetTile(tileX, tileY + 1);
            GridTile gridTileWest = grid.GetTile(tileX - 1, tileY);

            // Handle encountering wall from north east
            if (northDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileEast is WallTile)
                {
                    shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                    shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from south east
            if (southDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileEast is WallTile)
                {
                    shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                    shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from south west
            if (southDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileWest is WallTile)
                {
                    shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                    shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from north west
            if (northDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileWest is WallTile)
                {
                    shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                    shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                    return alteredVector;
                }

                shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from north
            if (northDistanceFromWallTileCenter > halfWallTileSize)
            {
                shortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from east
            if (eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                shortenVectorToEastSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from south
            if (southDistanceFromWallTileCenter > halfWallTileSize)
            {
                shortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            // Handle encountering wall from west
            if (westDistanceFromWallTileCenter > halfWallTileSize)
            {
                shortenVectorToWestSideOfGridTile(alteredVector, targetPosition, gridTile);
                return alteredVector;
            }

            return alteredVector;
        }

        private static void shortenVectorToNorthSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractY(targetPosition.Y - gridTile.Position.Y - 1);
        }

        private static void shortenVectorToEastSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
        }

        private static void shortenVectorToSouthSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
        }

        private static void shortenVectorToWestSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractX(targetPosition.X - gridTile.Position.X - 1);
        }
    }
}
