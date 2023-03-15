﻿using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class IdlingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly IdlingBehavior _steeringBehavior;

        public IdlingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new IdlingBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return _steeringBehavior.Calculate();
        }

        public override VectorImmutable CalculateImmutable()
        {
            return _steeringBehavior.CalculateImmutable();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, _steeringBehavior.GetEntityPosition(), _steeringBehavior.GetEntityVelocity());
        }
    }
}
