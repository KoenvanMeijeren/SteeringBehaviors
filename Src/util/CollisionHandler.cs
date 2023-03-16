using Src.grid;
using Src.world;

namespace Src.util
{
    public static class CollisionHandler
    {
        public static VectorImmutable AlterVectorToStayInsideOfWorld(VectorImmutable position, VectorImmutable vector, IWorld world)
        {
            if (vector.ToString() == "(0,0)")
            {
                return vector;
            }

            VectorImmutable alteredVector = vector;
            VectorImmutable targetPosition = position + vector;

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

        public static VectorImmutable AlterVectorToStayOutOfWalls(VectorImmutable centerPosition, VectorImmutable position, VectorImmutable vector, IGrid grid)
        {
            if (vector.ToString() == "(0,0)")
            {
                return vector;
            }

            VectorImmutable alteredVector = vector;

            // Check if target position is in a wall tile
            VectorImmutable targetPosition = position + vector;

            int tileX = grid.GetCoordinateOfTile((int)targetPosition.X);
            int tileY = grid.GetCoordinateOfTile((int)targetPosition.Y);

            GridTile gridTile = grid.GetTile(tileX, tileY);

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

            GridTile gridTileNorth = grid.GetTile(tileX, tileY - 1);
            GridTile gridTileEast = grid.GetTile(tileX + 1, tileY);
            GridTile gridTileSouth = grid.GetTile(tileX, tileY + 1);
            GridTile gridTileWest = grid.GetTile(tileX - 1, tileY);

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

        private static VectorImmutable ShortenVectorToNorthSideOfGridTile(VectorImmutable vector, VectorImmutable targetPosition, GridTile gridTile)
        {
            return vector.SubtractY(targetPosition.Y - gridTile.Position.Y - 1);
        }

        private static VectorImmutable ShortenVectorToEastSideOfGridTile(VectorImmutable vector, VectorImmutable targetPosition, GridTile gridTile)
        {
            return vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
        }

        private static VectorImmutable ShortenVectorToSouthSideOfGridTile(VectorImmutable vector, VectorImmutable targetPosition, GridTile gridTile)
        {
            return vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
        }

        private static VectorImmutable ShortenVectorToWestSideOfGridTile(VectorImmutable vector, VectorImmutable targetPosition, GridTile gridTile)
        {
            return vector.SubtractX(targetPosition.X - gridTile.Position.X - 1);
        }
    }
}
