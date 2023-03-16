using Src.entity;
using Src.util;
using Src.world;

namespace Tests.fixtures.entity
{
    public class VehicleTest : MovingEntity
    {
        public const int DefaultHeight = 10, DefaultWidth = 10;
        private const float DefaultMass = 30, DefaultMaxSpeed = 150;
        public VehicleTest(Vector position, IWorld world) : base(position, world, DefaultHeight, DefaultWidth)
        {
            Velocity = new Vector(0, 0);
            Mass = DefaultMass;
            MaxSpeed = DefaultMaxSpeed;
        }
    }
}
