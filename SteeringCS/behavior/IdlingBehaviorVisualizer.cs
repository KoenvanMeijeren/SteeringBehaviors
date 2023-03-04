using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class IdlingBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        public IdlingBehavior SteeringBehavior { get; private set; }

        public IdlingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new IdlingBehavior(movingEntity);
        }

        public Vector Calculate()
        {
            return SteeringBehavior.Calculate();
        }

        public void Render(Graphics graphic)
        {
            
        }
    }
}
