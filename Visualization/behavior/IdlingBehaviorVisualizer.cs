using System.Drawing;
using Visualization.behavior;
using Visualization.entity;
using Visualization.util;

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
