using Src.util;
using System.Drawing;
using Src.behavior;
using Src.entity;

namespace SteeringCS.behavior
{
    public class MosquitoBehaviorVisualizer : SteeringBehaviorVisualizer
    {
        public MosquitoBehavior SteeringBehavior { get; private set; }

        public MosquitoBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new MosquitoBehavior(movingEntity);
        }

        public override Vector Calculate()
        {
            return SteeringBehavior.Calculate();
        }

        public override void Render(Graphics graphic)
        {
            RenderVelocity(graphic, SteeringBehavior.GetEntityPosition(), SteeringBehavior.GetEntityTargetPosition());
        }
    }
}
