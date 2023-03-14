using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.util;
using System;
using System.Drawing;

namespace SteeringCS.entity
{
    public class Mario : MovingEntity, IRender
    {
        private readonly Color _shadowColor = Color.FromArgb(100, Color.Black);
        private const double _movementMargin = 0.1;
        private int _graphicIterator = 0;
        private const int _graphicIteratorLimit = 3;
        private bool _directionIsRight;

        private Image _currentGraphics;

        private static readonly Image _playerGraphicsRight = Image.FromFile("graphics/mario/mario-right.png");
        private static readonly Image _playerGraphicsRightWalk1 = Image.FromFile("graphics/mario/mario-right-walk-1.png");
        private static readonly Image _playerGraphicsRightWalk2 = Image.FromFile("graphics/mario/mario-right-walk-2.png");

        private static readonly Image _playerGraphicsLeft = Image.FromFile("graphics/mario/mario-left.png");
        private static readonly Image _playerGraphicsLeftWalk1 = Image.FromFile("graphics/mario/mario-left-walk-1.png");
        private static readonly Image _playerGraphicsLeftWalk2 = Image.FromFile("graphics/mario/mario-left-walk-2.png");

        public Mario(Vector position, IWorld world) : base(position, world, _playerGraphicsRight.Height/2, _playerGraphicsRight.Width)
        {
            Velocity = new Vector(0, 0);
        }

        public void Render(Graphics graphic)
        {
            CalculateDirection();
            CalculateGraphic();
            RenderCurrentGraphic(graphic);
        }

        public void CalculateDirection()
        {
            if (Velocity.X > _movementMargin)
            {
                _directionIsRight = true;
            }

            if (Velocity.X < -_movementMargin)
            {
                _directionIsRight = false;
            }
        }

        public void CalculateGraphic()
        {
            if (Math.Abs(Velocity.X) < _movementMargin && Math.Abs(Velocity.Y) < _movementMargin) 
            { 
                if (_directionIsRight)
                {
                    _currentGraphics = _playerGraphicsRight;
                    return;
                }

                _currentGraphics = _playerGraphicsLeft;
                return;
            }

            if (_directionIsRight)
            {
                if (_graphicIterator / _graphicIteratorLimit < 1)
                {
                    _currentGraphics = _playerGraphicsRight;
                    _graphicIterator++;
                    return;
                }

                if (_graphicIterator / _graphicIteratorLimit == 1)
                {
                    _currentGraphics = _playerGraphicsRightWalk1;
                    _graphicIterator++;
                    return;
                }

                if (_graphicIterator / _graphicIteratorLimit == 2)
                {
                    _currentGraphics = _playerGraphicsRightWalk2;
                    _graphicIterator++;
                    return;
                }

                if (_graphicIterator / _graphicIteratorLimit == 3)
                {
                    _currentGraphics = _playerGraphicsRightWalk1;
                    _graphicIterator++;
                    return;
                }

                _graphicIterator = 0;
                return;
            }

            if (_graphicIterator / _graphicIteratorLimit == 0)
            {
                _currentGraphics = _playerGraphicsLeft;
                _graphicIterator++;
                return;
            }

            if (_graphicIterator / _graphicIteratorLimit == 1)
            {
                _currentGraphics = _playerGraphicsLeftWalk1;
                _graphicIterator++;
                return;
            }

            if (_graphicIterator / _graphicIteratorLimit == 2)
            {
                _currentGraphics = _playerGraphicsLeftWalk2;
                _graphicIterator++;
                return;
            }

            if (_graphicIterator / _graphicIteratorLimit == 3)
            {
                _currentGraphics = _playerGraphicsLeftWalk1;
                _graphicIterator++;
                return;
            }

            _graphicIterator = 0;
        }

        public void RenderCurrentGraphic(Graphics graphic)
        {
            Brush brush = new SolidBrush(_shadowColor);
            graphic.FillEllipse(brush, (int)Position.X - Width / 2, (int)Position.Y + Height/5, Width, Height/2);

            graphic.DrawImage(_currentGraphics, (int)Position.X - Width / 2, (int)Position.Y - (int)(Height * 1.5));
        }
    }
}
