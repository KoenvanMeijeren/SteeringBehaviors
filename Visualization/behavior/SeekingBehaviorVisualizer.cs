using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;

namespace SteeringCS.behavior
{
    public class SeekingBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        public SeekingBehavior SteeringBehavior { get; private set; }

        public SeekingBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new SeekingBehavior(movingEntity);
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
