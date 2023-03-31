using System;
using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.state;

namespace SteeringCS.entity
{
    public class Luigi : MovingEntityVisualization, IRescuee
    {
        private static readonly Image s_playerGraphicsScared1 = Image.FromFile("graphics/luigi/scared/luigi-scared-1.png");
        private static readonly Image s_playerGraphicsScared2 = Image.FromFile("graphics/luigi/scared/luigi-scared-2.png");
        private static readonly Image s_playerGraphicsScared3 = Image.FromFile("graphics/luigi/scared/luigi-scared-3.png");
        private static readonly Image s_playerGraphicsScared4 = Image.FromFile("graphics/luigi/scared/luigi-scared-4.png");
        private static readonly Image s_playerGraphicsScared5 = Image.FromFile("graphics/luigi/scared/luigi-scared-5.png");
        private static readonly Image s_playerGraphicsScared6 = Image.FromFile("graphics/luigi/scared/luigi-scared-6.png");

        private static readonly Image s_playerGraphicsRight = Image.FromFile("graphics/luigi/luigi-right.png");
        private static readonly Image s_playerGraphicsRightWalk1 = Image.FromFile("graphics/luigi/walk/luigi-right-walk-1.png");
        private static readonly Image s_playerGraphicsRightWalk2 = Image.FromFile("graphics/luigi/walk/luigi-right-walk-2.png");

        private static readonly Image s_playerGraphicsLeft = Image.FromFile("graphics/luigi/luigi-left.png");
        private static readonly Image s_playerGraphicsLeftWalk1 = Image.FromFile("graphics/luigi/walk/luigi-left-walk-1.png");
        private static readonly Image s_playerGraphicsLeftWalk2 = Image.FromFile("graphics/luigi/walk/luigi-left-walk-2.png");

        public Luigi(Vector position, IWorld world) : base(position, world, s_playerGraphicsRight.Height / 2, s_playerGraphicsRight.Width)
        {
            Velocity = new Vector(0, 0);
        }

        protected override void CalculateGraphic()
        {
            if (State.GetType() == typeof(LostState))
            {
                CalculateScaredGraphic();
                return;
            }

            CalculateWalkingGraphic();
        }

        private void CalculateWalkingGraphic()
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
                switch (_graphicIterator / _graphicIteratorLimit)
                {
                    case 0:
                        _currentGraphics = s_playerGraphicsRight;
                        _graphicIterator++;
                        return;
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

        private void CalculateScaredGraphic()
        {
            const int IteratorBoost = 10;
            switch (_graphicIterator / (_graphicIteratorLimit * IteratorBoost))
            {
                case 0:
                    _currentGraphics = s_playerGraphicsScared1;
                    _graphicIterator++;
                    return;
                case 1:
                    _currentGraphics = s_playerGraphicsScared2;
                    _graphicIterator += IteratorBoost;
                    return;
                case 2:
                    _currentGraphics = s_playerGraphicsScared3;
                    _graphicIterator += IteratorBoost;
                    return;
                case 3:
                    _currentGraphics = s_playerGraphicsScared4;
                    _graphicIterator += IteratorBoost;
                    return;
                case 4:
                    _currentGraphics = s_playerGraphicsScared5;
                    _graphicIterator += IteratorBoost;
                    return;
                case 5:
                    _currentGraphics = s_playerGraphicsScared6;
                    _graphicIterator++;
                    return;
                case 6:
                    _currentGraphics = s_playerGraphicsScared6;
                    _graphicIterator++;
                    return;
                case 7:
                    _currentGraphics = s_playerGraphicsScared6;
                    _graphicIterator++;
                    return;
                case 8:
                    _currentGraphics = s_playerGraphicsScared5;
                    _graphicIterator += IteratorBoost;
                    return;
                case 9:
                    _currentGraphics = s_playerGraphicsScared4;
                    _graphicIterator += IteratorBoost;
                    return;
                case 10:
                    _currentGraphics = s_playerGraphicsScared3;
                    _graphicIterator += IteratorBoost;
                    return;
                case 11:
                    _currentGraphics = s_playerGraphicsScared2;
                    _graphicIterator += IteratorBoost;
                    return;
                case 12:
                    _currentGraphics = s_playerGraphicsScared1;
                    _graphicIterator++;
                    return;
                case 13:
                    _currentGraphics = s_playerGraphicsScared1;
                    _graphicIterator++;
                    return;
                default:
                    _graphicIterator = 0;
                    break;
            }
        }
    }
}
