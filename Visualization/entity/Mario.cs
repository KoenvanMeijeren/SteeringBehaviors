﻿using Src.util;
using Src.world;
using System;
using System.Drawing;

namespace SteeringCS.entity
{
    public class Mario : MovingEntityVisualization
    {
        private static readonly Image s_playerGraphicsRight = Image.FromFile("graphics/mario/mario-right.png");
        private static readonly Image s_playerGraphicsRightWalk1 = Image.FromFile("graphics/mario/mario-right-walk-1.png");
        private static readonly Image s_playerGraphicsRightWalk2 = Image.FromFile("graphics/mario/mario-right-walk-2.png");

        private static readonly Image s_playerGraphicsLeft = Image.FromFile("graphics/mario/mario-left.png");
        private static readonly Image s_playerGraphicsLeftWalk1 = Image.FromFile("graphics/mario/mario-left-walk-1.png");
        private static readonly Image s_playerGraphicsLeftWalk2 = Image.FromFile("graphics/mario/mario-left-walk-2.png");

        public Mario(Vector position, IWorld world) : base(position, world, s_playerGraphicsRight.Height / 2, s_playerGraphicsRight.Width)
        {
            Velocity = new Vector(0, 0);
        }

        protected override void CalculateGraphic()
        {
            if (Math.Abs(Velocity.X) < _movementMargin && Math.Abs(Velocity.Y) < _movementMargin)
            {
                if (IsDirectionRight && !IsDirectionLeft)
                {
                    _currentGraphics = s_playerGraphicsRight;
                    return;
                }

                _currentGraphics = s_playerGraphicsLeft;
                return;
            }

            if (IsDirectionRight && !IsDirectionLeft)
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
