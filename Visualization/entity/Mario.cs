using System;
using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;

namespace SteeringCS.entity
{
    public class Mario : MovingEntityVisualization, IPlayer
    {
        public int Health { get; set; } = 2;
        private static readonly Image s_marioBigGraphicsRight = Image.FromFile("graphics/mario/mario-big/mario-right.png");
        private static readonly Image s_marioBigGraphicsRightWalk1 = Image.FromFile("graphics/mario/mario-big/mario-right-walk-1.png");
        private static readonly Image s_marioBigGraphicsRightWalk2 = Image.FromFile("graphics/mario/mario-big/mario-right-walk-2.png");

        private static readonly Image s_marioBigGraphicsLeft = Image.FromFile("graphics/mario/mario-big/mario-left.png");
        private static readonly Image s_marioBigGraphicsLeftWalk1 = Image.FromFile("graphics/mario/mario-big/mario-left-walk-1.png");
        private static readonly Image s_marioBigGraphicsLeftWalk2 = Image.FromFile("graphics/mario/mario-big/mario-left-walk-2.png");

        private static readonly Image s_marioSmallGraphicsRight = Image.FromFile("graphics/mario/mario-small/mario-right.png");
        private static readonly Image s_marioSmallGraphicsRightWalk1 = Image.FromFile("graphics/mario/mario-small/mario-right-walk-1.png");

        private static readonly Image s_marioSmallGraphicsLeft = Image.FromFile("graphics/mario/mario-small/mario-left.png");
        private static readonly Image s_marioSmallGraphicsLeftWalk1 = Image.FromFile("graphics/mario/mario-small/mario-left-walk-1.png");

        public Mario(Vector position, IWorld world) : base(position, world, s_marioBigGraphicsRight.Height / 2, s_marioBigGraphicsRight.Width)
        {
            Velocity = new Vector(0, 0);
        }

        public void TakeDamage()
        {
            Health -= 1;
            Height = s_marioSmallGraphicsRight.Height / 2;
            Width = s_marioSmallGraphicsRight.Width;
        }

        protected override void CalculateGraphic()
        {
            if (Health > 1)
            {
                CalculateWalkingBigGraphic();
                return;
            }

            CalculateWalkingSmallGraphic();
        }
        private void CalculateWalkingBigGraphic()
        {
            if (Math.Abs(Velocity.X) < _movementMargin && Math.Abs(Velocity.Y) < _movementMargin)
            {
                if (_isDrawDirectionRight)
                {
                    _currentGraphics = s_marioBigGraphicsRight;
                    return;
                }

                _currentGraphics = s_marioBigGraphicsLeft;
                return;
            }

            if (_isDrawDirectionRight)
            {
                switch (_graphicIterator / _graphicIteratorLimit)
                {
                    case 0:
                        _currentGraphics = s_marioBigGraphicsRight;
                        _graphicIterator++;
                        return;
                    case 1:
                        _currentGraphics = s_marioBigGraphicsRightWalk1;
                        _graphicIterator++;
                        return;
                    case 2:
                        _currentGraphics = s_marioBigGraphicsRightWalk2;
                        _graphicIterator++;
                        return;
                    case 3:
                        _currentGraphics = s_marioBigGraphicsRightWalk1;
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
                    _currentGraphics = s_marioBigGraphicsLeft;
                    _graphicIterator++;
                    return;
                case 1:
                    _currentGraphics = s_marioBigGraphicsLeftWalk1;
                    _graphicIterator++;
                    return;
                case 2:
                    _currentGraphics = s_marioBigGraphicsLeftWalk2;
                    _graphicIterator++;
                    return;
                case 3:
                    _currentGraphics = s_marioBigGraphicsLeftWalk1;
                    _graphicIterator++;
                    return;
                default:
                    _graphicIterator = 0;
                    break;
            }
        }
        private void CalculateWalkingSmallGraphic()
        {
            if (Math.Abs(Velocity.X) < _movementMargin && Math.Abs(Velocity.Y) < _movementMargin)
            {
                if (_isDrawDirectionRight)
                {
                    _currentGraphics = s_marioSmallGraphicsRight;
                    return;
                }

                _currentGraphics = s_marioSmallGraphicsLeft;
                return;
            }

            if (_isDrawDirectionRight)
            {
                switch (_graphicIterator / _graphicIteratorLimit)
                {
                    case 0:
                        _currentGraphics = s_marioSmallGraphicsRight;
                        _graphicIterator++;
                        return;
                    case 1:
                        _currentGraphics = s_marioSmallGraphicsRightWalk1;
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
                    _currentGraphics = s_marioSmallGraphicsLeft;
                    _graphicIterator++;
                    return;
                case 1:
                    _currentGraphics = s_marioSmallGraphicsLeftWalk1;
                    _graphicIterator++;
                    return;
                default:
                    _graphicIterator = 0;
                    break;
            }
        }
    }
}
