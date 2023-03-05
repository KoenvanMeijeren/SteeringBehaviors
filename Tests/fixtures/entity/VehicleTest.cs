using Src.entity;
using Src.util;
using Src.world;

namespace Tests.fixtures.entity
{
    public class VehicleTest : MovingEntity
    {
        public const int DefaultScale = 5;
        public VehicleTest(Vector position, IWorld world) : base(position, world)
        {
            Velocity = new Vector(0, 0);
            Scale = DefaultScale;
        }
    }
}
