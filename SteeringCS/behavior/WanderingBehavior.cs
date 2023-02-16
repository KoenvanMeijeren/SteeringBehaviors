﻿using SteeringCS.entity;
using SteeringCS.util;
using System;
using System.Drawing;

namespace SteeringCS.behavior
{
    public class WanderingBehavior : SteeringBehavior
    {
        private Vector2D _targetCircle, _selectedPoint;

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

        public override Vector2D Calculate()
        {
            var randomNewPosition = new Vector2D(_randomClampedXPosition * WanderJitter, _randomClampedYPosition * WanderJitter);
            _targetCircle = MovingEntity.Position.Clone().Add(randomNewPosition);
            _selectedPoint = _targetCircle.Clone();
            
            var xPosition = CircleRadius * Math.Cos(_wanderTheta);
            var yPosition = CircleRadius * Math.Sin(_wanderTheta);
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
            var outerLeftCorner = _targetCircle.XPosition - CircleRadius;
            var outerRightCorner = _targetCircle.YPosition - CircleRadius;
            var centerLeftCorner = _targetCircle.XPosition - CenterRadius;
            var centerRightCorner = _targetCircle.YPosition - CenterRadius;
            var selectedLeftCorner = _selectedPoint.XPosition - CenterRadius;
            var selectedRightCorner = _selectedPoint.YPosition - CenterRadius;

            var redPen = new Pen(Color.Red, 2);
            var greenPen = new Pen(Color.Green, 2);
            graphic.DrawEllipse(redPen, new Rectangle((int)outerLeftCorner, (int)outerRightCorner, CircleSize, CircleSize));
            graphic.DrawEllipse(greenPen, new Rectangle((int)centerLeftCorner, (int)centerRightCorner, CenterSize, CenterSize));
            graphic.DrawEllipse(greenPen, new Rectangle((int)selectedLeftCorner, (int)selectedRightCorner, CenterSize, CenterSize));
        }
    }
}
