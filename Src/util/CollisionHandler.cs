using Src.grid;
using Src.world;

namespace Src.util
{
    public static class CollisionHandler
    {
        public static Vector AlterVectorToStayInsideOfWorld(Vector position, Vector vector, IWorld world)
        {
            // Do not alter empty vectors.
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
            // Do not alter empty vectors.
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

            // Handle encountering north east corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileEast is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                    alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                    return alteredVector;
                }

                alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                return alteredVector;
            }

            // Handle encountering south east corner
            if (southDistanceFromWallTileCenter > halfWallTileSize && eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileEast is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                    alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                    return alteredVector;
                }

                if (gridTileEast is WallTile)
                {
                    alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > eastDistanceFromWallTileCenter)
                {
                    alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                    return alteredVector;
                }

                alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                return alteredVector;
            }

            // Handle encountering south west corner
            if (southDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileSouth is WallTile && gridTileWest is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                    alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                    return alteredVector;
                }

                if (gridTileSouth is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                    return alteredVector;
                }

                if (southDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                    return alteredVector;
                }

                alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                return alteredVector;
            }

            // Handle encountering north west corner
            if (northDistanceFromWallTileCenter > halfWallTileSize && westDistanceFromWallTileCenter > halfWallTileSize)
            {
                if (gridTileNorth is WallTile && gridTileWest is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                    alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                    return alteredVector;
                }

                if (gridTileNorth is WallTile)
                {
                    alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                    return alteredVector;
                }

                if (gridTileWest is WallTile)
                {
                    alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                    return alteredVector;
                }

                if (northDistanceFromWallTileCenter > westDistanceFromWallTileCenter)
                {
                    alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                    return alteredVector;
                }

                alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                return alteredVector;
            }

            // Handle encountering north wall
            if (northDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector.SubtractY(targetPosition.Y - wallTile.Position.Y);
                return alteredVector;
            }

            // Handle encountering east wall
            if (eastDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector.SubtractX(targetPosition.X - (wallTile.Position.X + wallTile.Size + 1));
                return alteredVector;
            }

            // Handle encountering south wall
            if (southDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector.SubtractY(targetPosition.Y - (wallTile.Position.Y + wallTile.Size + 1));
                return alteredVector;
            }

            // Handle encountering west wall
            if (westDistanceFromWallTileCenter > halfWallTileSize)
            {
                alteredVector.SubtractX(targetPosition.X - wallTile.Position.X);
                return alteredVector;
            }

            return alteredVector;
        }
    }
}
