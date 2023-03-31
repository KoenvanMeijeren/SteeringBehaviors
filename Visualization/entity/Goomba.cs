using System;
using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;

namespace SteeringCS.entity
{
    public class Goomba : MovingEntityVisualization, IEnemy
    {
        private const int GoombaMass = 45, GoombaMaxSpeed = 150;

        private static readonly Image s_playerGraphicsRight = Image.FromFile("graphics/goomba/goomba-right.png");
        private static readonly Image s_playerGraphicsRightWalk1 = Image.FromFile("graphics/goomba/goomba-right-walk-1.png");
        private static readonly Image s_playerGraphicsRightWalk2 = Image.FromFile("graphics/goomba/goomba-right-walk-2.png");

        private static readonly Image s_playerGraphicsLeft = Image.FromFile("graphics/goomba/goomba-left.png");
        private static readonly Image s_playerGraphicsLeftWalk1 = Image.FromFile("graphics/goomba/goomba-left-walk-1.png");
        private static readonly Image s_playerGraphicsLeftWalk2 = Image.FromFile("graphics/goomba/goomba-left-walk-2.png");

        public Goomba(Vector position, IWorld world, float mass = GoombaMass, float maxSpeed = GoombaMaxSpeed) : base(position, world, s_playerGraphicsRight.Height / 2, s_playerGraphicsRight.Width, mass, maxSpeed)
        {
            Velocity = new Vector(0, 0);
        }

        protected override void CalculateGraphic()
        {
            if (Math.Abs(Velocity.X) < _movementMargin && Math.Abs(Velocity.Y) < _movementMargin)
            {
                if (_isDrawDirectionRight)
                {
                    _currentGraphics = s_playerGraphicsRight;
                    return;
                }

                _currentGraphics = s_playerGraphicsLeft;
                return;
            }

            if (_isDrawDirectionRight)
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
    }
}
