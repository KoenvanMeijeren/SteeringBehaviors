using System.Drawing;
using Visualization.behavior;
using Visualization.entity;
using Visualization.util;

namespace SteeringCS.behavior
{
    public class FleeingBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly FleeingBehavior _steeringBehavior;

        public FleeingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new FleeingBehavior(movingEntity);
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
