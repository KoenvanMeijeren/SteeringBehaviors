using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class FleeingBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        public FleeingBehavior SteeringBehavior { get; private set; }

        public FleeingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new FleeingBehavior(movingEntity);
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
