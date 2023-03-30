using System;
using System.Collections.Generic;
using Visualization.entity;
using Visualization.grid;
using Visualization.util;

namespace Visualization.behavior
{
    public class CollisionAvoidingBehavior : SteeringBehavior
    {
        public List<Tuple<Vector, Vector>> MostThreateningObjects { get; private set; }
        public List<Tuple<Vector, Vector>> AheadPositions { get; private set; }
        public Vector AvoidancePosition { get; private set; }
        private const int MaxSeeAhead = 30, MaxSeeAheadHalf = MaxSeeAhead / 2;

        public CollisionAvoidingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
            MostThreateningObjects = new List<Tuple<Vector, Vector>>();
            AheadPositions = new List<Tuple<Vector, Vector>>();
        }

        public override Vector Calculate()
        {
            IGrid grid = MovingEntity.World.Grid;
            Vector currentPosition = MovingEntity.Position;
            Vector currentVelocity = MovingEntity.Velocity;

            Tuple<Vector, Vector, Vector> aheadPositions = AheadPositionsUtil.Generate(
                currentVelocity,
                MovingEntity.IsDirectionRight,
                MovingEntity.IsDirectionUpwards,
                MovingEntity.IsDirectionDownwards
            );

            AheadPositions = new List<Tuple<Vector, Vector>>
            {
                new Tuple<Vector, Vector>(
                    currentPosition + (aheadPositions.Item1.Normalize() * MaxSeeAhead),
                    currentPosition + (aheadPositions.Item1.Normalize() * MaxSeeAheadHalf)
                ),
                new Tuple<Vector, Vector>(
                    currentPosition + (aheadPositions.Item2.Normalize() * MaxSeeAhead),
                    currentPosition + (aheadPositions.Item2.Normalize() * MaxSeeAheadHalf)
                ),
                new Tuple<Vector, Vector>(
                    currentPosition + (aheadPositions.Item3.Normalize() * MaxSeeAhead),
                    currentPosition + (aheadPositions.Item3.Normalize() * MaxSeeAheadHalf)
                ),
            };

            MostThreateningObjects = new List<Tuple<Vector, Vector>>();
            foreach ((_, Vector positionAheadHalf) in AheadPositions)
            {
                FindMostThreateningObjects(grid, positionAheadHalf);
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
                avoidanceVelocity *= 10;
                AvoidancePosition = aheadPosition + avoidanceVelocity;
            }

            return avoidanceVelocity.IsEmpty() ? new Vector(0, 0) : avoidanceVelocity;
        }

        private void FindMostThreateningObjects(IGrid grid, Vector aheadPosition)
        {
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

                    if (aheadPosition.IsInRange(wallTile.Position, wallTile.PositionEnd))
                    {
                        MostThreateningObjects.Add(new Tuple<Vector, Vector>(aheadPosition, wallTile.PositionCenter));
                    }
                }
            }
        }
    }
}
