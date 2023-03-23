using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.util;
using System;
using System.Drawing;

namespace SteeringCS.entity
{
    public class Goomba : MovingEntity, IRender
    {
        private readonly Color _shadowColor = Color.FromArgb(100, Color.Black);
        private const double _movementMargin = 0.1;
        private int _graphicIterator = 0;
        private const int _graphicIteratorLimit = 3;
        private bool _directionIsRight;

        private Image _currentGraphics;

        private static readonly Image s_playerGraphicsRight = Image.FromFile("graphics/goomba/goomba-right.png");
        private static readonly Image s_playerGraphicsRightWalk1 = Image.FromFile("graphics/goomba/goomba-right-walk-1.png");
        private static readonly Image s_playerGraphicsRightWalk2 = Image.FromFile("graphics/goomba/goomba-right-walk-2.png");

        private static readonly Image s_playerGraphicsLeft = Image.FromFile("graphics/goomba/goomba-left.png");
        private static readonly Image s_playerGraphicsLeftWalk1 = Image.FromFile("graphics/goomba/goomba-left-walk-1.png");
        private static readonly Image s_playerGraphicsLeftWalk2 = Image.FromFile("graphics/goomba/goomba-left-walk-2.png");

        public Goomba(Vector position, IWorld world) : base(position, world, s_playerGraphicsRight.Height / 2, s_playerGraphicsRight.Width)
        {
            Velocity = new Vector(0, 0);
        }

        public void Render(Graphics graphic)
        {
            CalculateDirection();
            CalculateGraphic();
            RenderCurrentGraphic(graphic);
        }

        private void CalculateDirection()
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

        private void CalculateGraphic()
        {
            if (Math.Abs(Velocity.X) < _movementMargin && Math.Abs(Velocity.Y) < _movementMargin)
            {
                if (_directionIsRight)
                {
                    _currentGraphics = s_playerGraphicsRight;
                    return;
                }

                _currentGraphics = s_playerGraphicsLeft;
                return;
            }

            if (_directionIsRight)
            {
                if (_graphicIterator / _graphicIteratorLimit < 1)
                {
                    _currentGraphics = s_playerGraphicsRight;
                    _graphicIterator++;
                    return;
                }

                switch (_graphicIterator / _graphicIteratorLimit)
                {
                    case 1:
                        _currentGraphics = s_playerGraphicsRightWalk1;
                        _graphicIterator++;
                        return;
                    case 2:
                        _currentGraphics = s_playerGraphicsRightWalk2;
                        _graphicIterator++;
                        return;
                    case 3:
                        _currentGraphics = s_playerGraphicsRightWalk1;
                        _graphicIterator++;
                        return;
                    default:
                        _graphicIterator = 0;
                        return;
                }
            }

            switch (_graphicIterator / _graphicIteratorLimit)
            {
                case 0:
                    _currentGraphics = s_playerGraphicsLeft;
                    _graphicIterator++;
                    return;
                case 1:
                    _currentGraphics = s_playerGraphicsLeftWalk1;
                    _graphicIterator++;
                    return;
                case 2:
                    _currentGraphics = s_playerGraphicsLeftWalk2;
                    _graphicIterator++;
                    return;
                case 3:
                    _currentGraphics = s_playerGraphicsLeftWalk1;
                    _graphicIterator++;
                    return;
                default:
                    _graphicIterator = 0;
                    break;
            }
        }

        private void RenderCurrentGraphic(Graphics graphic)
        {
            Brush brush = new SolidBrush(_shadowColor);
            graphic.FillEllipse(brush, (int)Position.X - Width / 2, (int)Position.Y + Height / 5, Width, Height / 2);

            graphic.DrawImage(_currentGraphics, (int)Position.X - Width / 2, (int)Position.Y - (int)(Height * 1.5));
        }
    }
}
