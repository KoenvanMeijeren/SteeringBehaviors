using SteeringCS.entity;
using Src.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
