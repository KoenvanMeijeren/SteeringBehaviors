using System;
using System.Collections.Generic;
using Src.entity;
using Src.grid;
using Src.util;

namespace Src.behavior
{
    public class CollisionAvoidingBehavior : SteeringBehavior
    {
        public List<Tuple<Vector, Vector>> MostThreateningObjects { get; private set; }
        public List<Tuple<Vector, Vector>> AheadPositions { get; private set; }
        public Vector AvoidancePosition { get; private set; }
        private const int MaxSeeAhead = 50, MaxSeeAheadHalf = MaxSeeAhead / 2;

        public CollisionAvoidingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            Vector currentPosition = MovingEntity.Position;
            Vector currentVelocity = MovingEntity.Velocity;

            Vector vectorStraightForward = currentVelocity.Normalize();
            AheadPositions = new List<Tuple<Vector, Vector>>
            {
                new Tuple<Vector, Vector>(
                    currentPosition + (vectorStraightForward * MaxSeeAhead),
                    currentPosition + (vectorStraightForward * MaxSeeAheadHalf)
                ),
            };

            MostThreateningObjects = new List<Tuple<Vector, Vector>>();
            foreach ((Vector positionAhead, Vector positionAheadHalf) in AheadPositions)
            {
                FindMostThreateningObjects(positionAhead, positionAheadHalf);
            }

            if (MostThreateningObjects.Count <= 0)
            {
                AvoidancePosition = new Vector(0, 0);
                return new Vector(0, 0);
            }

            Vector avoidanceVelocity = new Vector(0, 0);
            foreach ((Vector aheadPosition, Vector mostThreateningObject) in MostThreateningObjects)
            {
                avoidanceVelocity = aheadPosition - mostThreateningObject;
                avoidanceVelocity.Normalize();
                avoidanceVelocity *= 2;
            }

            if (avoidanceVelocity.IsEmpty())
            {
                return new Vector(0, 0);
            }

            AvoidancePosition = currentPosition - avoidanceVelocity;

            return new Vector(0, 0);

        }

        private void FindMostThreateningObjects(Vector aheadPosition, Vector aheadHalfPosition)
        {
            IGrid grid = MovingEntity.World.Grid;
            int tileRow = grid.GetCoordinateOfTile((int)aheadPosition.X);
            int tileColumn = grid.GetCoordinateOfTile((int)aheadPosition.Y);

            for (int row = -1; row <= 1; row++)
            {
                for (int column = -1; column <= 1; column++)
                {
                    GridTile gridTile = grid.GetTile(tileRow - row, tileColumn - column);
                    if (!(gridTile is WallTile wallTile))
                    {
                        continue;
                    }

                    if (aheadPosition.IsInRange(wallTile.PositionStart, wallTile.PositionEnd))
                    {
                        MostThreateningObjects.Add(new Tuple<Vector, Vector>(aheadPosition, wallTile.PositionCenter));
                    }

                    if (aheadHalfPosition.IsInRange(wallTile.PositionStart, wallTile.PositionEnd))
                    {
                        MostThreateningObjects.Add(new Tuple<Vector, Vector>(aheadHalfPosition, wallTile.PositionCenter));
                    }
                }
            }
        }
    }
}
