using Src.grid;
using Src.world;

namespace Src.util
{
    public static class CollisionHandler
    {
        public static Vector AlterVectorToStayInsideOfWorld(Vector position, Vector vector, IWorld world)
        {
            if (vector.IsEmpty())
            {
                return vector;
            }

            Vector alteredVector = vector;
            Vector targetPosition = position + vector;

            int maxY = world.Height;
            int maxX = world.Width;

            if (targetPosition.Y < 0)
            {
                alteredVector = alteredVector.SubtractY(targetPosition.Y);
            }

            if (targetPosition.X < 0)
            {
                alteredVector = alteredVector.SubtractX(targetPosition.X);
            }

            if (targetPosition.Y > maxY)
            {
                alteredVector = alteredVector.SubtractY(targetPosition.Y - maxY);
            }

            if (targetPosition.X > maxX)
            {
                alteredVector = alteredVector.SubtractX(targetPosition.X - maxX);
            }

            return alteredVector;
        }

        public static Vector AlterVectorToStayOutOfWalls(Vector centerPosition, Vector position, Vector vector, IGrid grid)
        {
            if (vector.IsEmpty())
            {
                return vector;
            }

            Vector alteredVector = vector;

            // Check if target position is in a wall tile
            Vector targetPosition = position + vector;

            int tileRow = grid.GetCoordinateOfTile((int)targetPosition.X);
            int tileColumn = grid.GetCoordinateOfTile((int)targetPosition.Y);

            GridTile gridTile = grid.GetTile(tileRow, tileColumn);
            if (!(gridTile is WallTile wallTile))
            {
                return alteredVector;
            }

            // Calculate distance of every direction from center of encountering block
            int halfWallTileSize = wallTile.Size / 2;
            const int MeasureBuffer = 1;

            int wallTileCenterX = (int)wallTile.Position.X + halfWallTileSize;
            int wallTileCenterY = (int)wallTile.Position.Y + halfWallTileSize;

            double northDistanceFromWallTileCenter = wallTileCenterY - centerPosition.Y + MeasureBuffer;
            double eastDistanceFromWallTileCenter = centerPosition.X - wallTileCenterX + MeasureBuffer;
            double southDistanceFromWallTileCenter = centerPosition.Y - wallTileCenterY + MeasureBuffer;
            double westDistanceFromWallTileCenter = wallTileCenterX - centerPosition.X + MeasureBuffer;

            GridTile gridTileNorth = grid.GetTile(tileRow, tileColumn - 1);
            GridTile gridTileEast = grid.GetTile(tileRow + 1, tileColumn);
            GridTile gridTileSouth = grid.GetTile(tileRow, tileColumn + 1);
            GridTile gridTileWest = grid.GetTile(tileRow - 1, tileColumn);

            // Handle encountering wall from north east
            if (northDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileEast is WallTile)
                {
                    alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from south east
            if (southDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileEast is WallTile)
                {
                    alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from south west
            if (southDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileWest is WallTile)
                {
                    alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from north west
            if (northDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileWest is WallTile)
                {
                    alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from north
            if (northDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector = ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from east
            if (eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector = ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from south
            if (southDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector = ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from west
            if (westDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector = ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            return alteredVector;
        }

        private static Vector ShortenVectorToNorthSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            return vector.SubtractY(targetPosition.Y - gridTile.Position.Y - 1);
        }

        private static Vector ShortenVectorToEastSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            return vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
        }

        private static Vector ShortenVectorToSouthSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            return vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
        }

        private static Vector ShortenVectorToWestSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            return vector.SubtractX(targetPosition.X - gridTile.Position.X - 1);
        }
    }
}
