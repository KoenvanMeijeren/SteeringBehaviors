﻿using System.Drawing;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.behavior;
using SteeringCS.util;

namespace SteeringCS.entity
{
    public class Vehicle : MovingEntity, IRender
    {
        public const int DefaultScale = 5;
        public Color Color { get; set; }

        public Vehicle(Vector position, IWorld world) : base(position, world)
        {
            Velocity = new Vector(0, 0);
            Scale = DefaultScale;
            Color = Color.Black;
        }

        public void Render(Graphics graphic)
        {
            double leftCorner = Position.X - Scale;
            double rightCorner = Position.Y - Scale;
            float size = Scale * 2;

            Pen pen = new Pen(Color, 2);
            graphic.DrawEllipse(pen, new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size));
            graphic.DrawLine(pen, (int)Position.X, (int)Position.Y, (int)Position.X + (int)(Velocity.X * 2), (int)Position.Y + (int)(Velocity.Y * 2));

            if (SteeringBehavior is ISteeringBehaviorVisualizer visualizer)
            {
                visualizer.Render(graphic);
            }
        }
    }
}