﻿using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.util;

namespace SteeringCS.entity
{
    public abstract class MovingEntityVisualization : MovingEntity, IRender
    {
        private readonly Color _shadowColor = Color.FromArgb(100, Color.Black);
        protected const double _movementMargin = 0.5;
        protected int _graphicIterator = 0;
        protected const int _graphicIteratorLimit = 3;
        protected bool _isDrawDirectionRight;

        protected Image _currentGraphics;

        protected MovingEntityVisualization(Vector position, IWorld world, float height, float width, float mass = MassDefault, float maxSpeed = MaxSpeedDefault) : base(position, world, height, width, mass, maxSpeed)
        {
        }

        public void Render(Graphics graphic)
        {
            CalculateDirection();
            CalculateGraphic();
            RenderCurrentGraphic(graphic);
        }

        private void CalculateDirection()
        {
            IsDirectionLeft = Velocity.X < -_movementMargin;
            IsDirectionRight = Velocity.X > _movementMargin;
            IsDirectionUpwards = Velocity.Y < -_movementMargin;
            IsDirectionDownwards = Velocity.Y > _movementMargin;

            if (Velocity.X > _movementMargin)
            {
                _isDrawDirectionRight = true;
            }

            if (Velocity.X < -_movementMargin)
            {
                _isDrawDirectionRight = false;
            }
        }

        protected abstract void CalculateGraphic();

        private void RenderCurrentGraphic(Graphics graphic)
        {
            Brush brush = new SolidBrush(_shadowColor);
            graphic.FillEllipse(brush, (int)Position.X - Width / 2, (int)Position.Y + Height / 5, Width, Height / 2);

            graphic.DrawImage(_currentGraphics, (int)Position.X - Width / 2, (int)Position.Y - (int)(Height * 1.5));
        }
    }
}
