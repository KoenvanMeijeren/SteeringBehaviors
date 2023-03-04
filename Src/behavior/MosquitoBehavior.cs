using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class MosquitoBehavior : SteeringBehavior
    {
        public MosquitoBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            return new Vector(Randomizer.Next(-1000, 1000), Randomizer.Next(-1000, 1000));
        }
    }
}
