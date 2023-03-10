using Src.util;
using System.Drawing;
using Src.behavior;
using Src.entity;

namespace SteeringCS.behavior
{
    public class MosquitoBehaviorVisualizer : ISteeringBehaviorVisualizer
    {
        public MosquitoBehavior SteeringBehavior { get; private set; }

        public MosquitoBehaviorVisualizer(IMovingEntity movingEntity)
        {
            SteeringBehavior = new MosquitoBehavior(movingEntity);
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
