using Src.grid;
using Src.world;

namespace Src.util
{
    public static class CollisionHandler
    {
        public static Vector AlterVectorToStayInsideOfWorld(Vector position, Vector vector, IWorld world)
        {
            if (vector.ToString() == "(0,0)")
            {
                return vector;
            }

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
            if (vector.ToString() == "(0,0)")
            {
                return vector;
            }

            Vector alteredVector = vector.Clone();

            // Check if target position is in a wall tile
            Vector targetPosition = position.Clone().Add(vector);

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
                    ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from south east
            if (southDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileEast is WallTile)
                {
                    ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from south west
            if (southDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileWest is WallTile)
                {
                    ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from north west
            if (northDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileWest is WallTile)
                {
                    ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                    return alteredVector;
                }

                ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from north
            if (northDistanceFromWallTileCenter > halfWallTileSize)
            {
                ShortenVectorToNorthSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from east
            if (eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                ShortenVectorToEastSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from south
            if (southDistanceFromWallTileCenter > halfWallTileSize)
            {
                ShortenVectorToSouthSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            // Handle encountering wall from west
            if (westDistanceFromWallTileCenter > halfWallTileSize)
            {
                ShortenVectorToWestSideOfGridTile(alteredVector, targetPosition, wallTile);
                return alteredVector;
            }

            return alteredVector;
        }

        private static void ShortenVectorToNorthSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractY(targetPosition.Y - gridTile.Position.Y - 1);
        }

        private static void ShortenVectorToEastSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractX(targetPosition.X - (gridTile.Position.X + gridTile.Size + 1));
        }

        private static void ShortenVectorToSouthSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractY(targetPosition.Y - (gridTile.Position.Y + gridTile.Size + 1));
        }

        private static void ShortenVectorToWestSideOfGridTile(Vector vector, Vector targetPosition, GridTile gridTile)
        {
            vector.SubtractX(targetPosition.X - gridTile.Position.X - 1);
        }
    }
}
