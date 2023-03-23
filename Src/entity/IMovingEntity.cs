using Src.behavior;
using Src.util;
using Src.world;

namespace Src.entity
{
    public interface IMovingEntity
    {
        IWorld World { get; }
        float Height { get; }
        float Width { get; }
        float Mass { get; set; }
        float MaxSpeed { get; set; }
        HitBox HitBox { get; }
        Vector Position { get; set; }
        Vector Velocity { get; }
        bool IsDirectionLeft { get; }
        bool IsDirectionRight { get; }
        bool IsDirectionUpwards { get; }
        bool IsDirectionDownwards { get; }
        void Update(float timeElapsed);
        void SetSteeringBehavior(ISteeringBehavior steeringBehavior, ISteeringBehavior collisionAvoidingBehavior);
    }
}
