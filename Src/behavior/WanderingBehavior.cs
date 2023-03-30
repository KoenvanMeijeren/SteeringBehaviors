using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Visualization.entity;
using Visualization.grid;
using Visualization.util;

namespace Visualization.behavior
{
    [ExcludeFromCodeCoverage]
    public class WanderingBehavior : SteeringBehavior
    {
        public Vector TargetCircle { get; private set; }
        public Vector SelectedPoint { get; private set; }

        private const double WanderDistance = 0.3;
        private const int WanderJitter = 5;

        public const int CircleRadius = 20, CircleSize = CircleRadius * 2;

        private int _randomClampedXPosition, _randomClampedYPosition;
        private double _wanderTheta = Math.PI / 2;

        private List<Tuple<Vector, Vector>> _mostThreateningObjects;

        public WanderingBehavior(IMovingEntity movingEntity, bool shouldAvoidObstacles = false) : base(movingEntity, shouldAvoidObstacles)
        {
            _randomClampedXPosition = Randomizer.RandomClamped();
            _randomClampedYPosition = Randomizer.RandomClamped();
            _mostThreateningObjects = new List<Tuple<Vector, Vector>>();
        }

        public override Vector Calculate()
        {
            while (true)
            {
                Vector randomNewPosition = new Vector(_randomClampedXPosition * WanderJitter, _randomClampedYPosition * WanderJitter);
                TargetCircle = MovingEntity.Position + randomNewPosition;

                double xPosition = CircleRadius * Math.Cos(_wanderTheta);
                double yPosition = CircleRadius * Math.Sin(_wanderTheta);
                _wanderTheta += Randomizer.GetRandomNumber(-WanderDistance, WanderDistance);
                SelectedPoint = TargetCircle.Add(xPosition, yPosition);

                _mostThreateningObjects = new List<Tuple<Vector, Vector>>();
                FindMostThreateningObjects(MovingEntity.World.Grid, SelectedPoint);
                if (_mostThreateningObjects.Count <= 0)
                {
                    return ArrivingBehavior.Calculate(MovingEntity, SelectedPoint);
                }

                _wanderTheta += 1;
                _randomClampedXPosition = _randomClampedXPosition == -1 ? 1 : -1;
                _randomClampedYPosition = _randomClampedYPosition == -1 ? 1 : -1;
            }
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
                        _mostThreateningObjects.Add(new Tuple<Vector, Vector>(aheadPosition, wallTile.PositionCenter));
                    }
                }
            }
        }
    }
}
