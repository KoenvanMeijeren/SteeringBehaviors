using Src.util;
using System.Drawing;
using Src.behavior;
using Src.entity;

namespace SteeringCS.behavior
{
    public class MosquitoBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        private readonly MosquitoBehavior _steeringBehavior;

        public MosquitoBehaviorVisualizer(IMovingEntity movingEntity)
        {
            _steeringBehavior = new MosquitoBehavior(movingEntity);
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
