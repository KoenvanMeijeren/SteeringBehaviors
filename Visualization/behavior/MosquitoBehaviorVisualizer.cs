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

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, _steeringBehavior.GetEntityPosition(), _steeringBehavior.GetEntityTargetPosition());
        }
    }
}
