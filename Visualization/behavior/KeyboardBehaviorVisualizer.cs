﻿using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class KeyboardBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly KeyboardBehavior _steeringBehavior;
        public KeyboardBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new KeyboardBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override bool ShouldAvoidObstacles()
        {
            return _steeringBehavior.ShouldAvoidObstacles();
        }

        public override void Render(Graphics graphic) { }

        public override void RenderVelocity(Graphics graphic)
        {
            Vector position = _steeringBehavior.GetEntityPosition();

            RenderVelocity(graphic, position, _steeringBehavior.GetEntityVelocity());
            RenderVelocityText(graphic, position, _steeringBehavior.GetEntityVelocity());
        }
    }
}
