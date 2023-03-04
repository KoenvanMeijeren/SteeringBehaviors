﻿using System;
using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class WanderingBehavior : SteeringBehavior
    {
        public Vector TargetCircle { get; private set; }
        public Vector SelectedPoint { get; private set; }

        private const double WanderDistance = 0.3;
        private const int WanderJitter = 5;

        public const int CircleRadius = 20,
            CircleSize = CircleRadius * 2;

        private readonly int _randomClampedXPosition, _randomClampedYPosition;
        private double _wanderTheta = Math.PI / 2;

        public WanderingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
            _randomClampedXPosition = RandomClamped();
            _randomClampedYPosition = RandomClamped();
        }

        public override Vector Calculate()
        {
            Vector randomNewPosition = new Vector(_randomClampedXPosition * WanderJitter, _randomClampedYPosition * WanderJitter);
            TargetCircle = MovingEntity.Position.Clone().Add(randomNewPosition);
            SelectedPoint = TargetCircle.Clone();

            double xPosition = CircleRadius * Math.Cos(_wanderTheta);
            double yPosition = CircleRadius * Math.Sin(_wanderTheta);
            _wanderTheta += GetRandomNumber(-WanderDistance, WanderDistance);
            SelectedPoint.Add(xPosition, yPosition);

            return ArrivingBehavior.Calculate(MovingEntity, SelectedPoint);
        }
    }
}