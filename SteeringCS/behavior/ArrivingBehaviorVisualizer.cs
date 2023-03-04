using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class ArrivingBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        public ArrivingBehavior SteeringBehavior { get; private set; }

        public ArrivingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new ArrivingBehavior(movingEntity);
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
