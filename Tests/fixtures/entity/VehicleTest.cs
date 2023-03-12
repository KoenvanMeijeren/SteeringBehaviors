using Src.entity;
using Src.util;
using Src.world;

namespace Tests.fixtures.entity
{
    public class VehicleTest : MovingEntity
    {
        public const int DefaultHeight = 10;
        public const int DefaultWidth = 10;
        public VehicleTest(Vector position, IWorld world) : base(position, world, DefaultHeight, DefaultWidth)
        {
            Velocity = new Vector(0, 0);
        }
    }
}
