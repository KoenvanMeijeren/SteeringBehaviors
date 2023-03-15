using Src.entity;
using Src.util;

namespace Src.behavior
{
    public class KeyboardBehavior : SteeringBehavior
    {
        public KeyboardBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            VectorImmutable vectorImmutable = KeyHandler.GetKeysDirection();

            return new Vector(vectorImmutable.X, vectorImmutable.Y);
        }

        public override VectorImmutable CalculateImmutable() => KeyHandler.GetKeysDirection();
    }
}
