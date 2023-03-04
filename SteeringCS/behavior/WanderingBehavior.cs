﻿using SteeringCS.entity;
using Src.util;
using System;
using System.Drawing;

namespace SteeringCS.behavior
{
    public class WanderingBehavior : SteeringBehavior
    {
        private Vector _targetCircle, _selectedPoint;

        private const double WanderDistance = 0.3;
        private const int WanderJitter = 5,
            CircleRadius = 20,
            CircleSize = CircleRadius * 2;

        private readonly int _randomClampedXPosition, _randomClampedYPosition;
        private double _wanderTheta = Math.PI / 2;

        public WanderingBehavior(MovingEntity movingEntity) : base(movingEntity)
        {
            _randomClampedXPosition = RandomClamped();
            _randomClampedYPosition = RandomClamped();
        }

        public override Vector Calculate()
        {
            Vector randomNewPosition = new Vector(_randomClampedXPosition * WanderJitter, _randomClampedYPosition * WanderJitter);
            _targetCircle = MovingEntity.Position.Clone().Add(randomNewPosition);
            _selectedPoint = _targetCircle.Clone();

            double xPosition = CircleRadius * Math.Cos(_wanderTheta);
            double yPosition = CircleRadius * Math.Sin(_wanderTheta);
            _wanderTheta += GetRandomNumber(-WanderDistance, WanderDistance);
            _selectedPoint.Add(xPosition, yPosition);

            return ArrivingBehavior.Calculate(MovingEntity, _selectedPoint);
        }

        public override void Render(Graphics graphic)
        {
            base.Render(graphic);

            if (_targetCircle == null)
            {
                return;
            }

            const int CenterRadius = 2, CenterSize = CenterRadius * 2;
            double outerLeftCorner = _targetCircle.X - CircleRadius;
            double outerRightCorner = _targetCircle.Y - CircleRadius;
            double centerLeftCorner = _targetCircle.X - CenterRadius;
            double centerRightCorner = _targetCircle.Y - CenterRadius;
            double selectedLeftCorner = _selectedPoint.X - CenterRadius;
            double selectedRightCorner = _selectedPoint.Y - CenterRadius;

            Pen redPen = new Pen(Color.Red, 2);
            Pen greenPen = new Pen(Color.Green, 2);
            graphic.DrawEllipse(redPen, new Rectangle((int)outerLeftCorner, (int)outerRightCorner, CircleSize, CircleSize));
            graphic.DrawEllipse(greenPen, new Rectangle((int)centerLeftCorner, (int)centerRightCorner, CenterSize, CenterSize));
            graphic.DrawEllipse(greenPen, new Rectangle((int)selectedLeftCorner, (int)selectedRightCorner, CenterSize, CenterSize));
        }
    }
}
