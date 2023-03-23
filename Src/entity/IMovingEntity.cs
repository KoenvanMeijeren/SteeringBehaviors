using Src.behavior;
using Src.util;

namespace Src.entity
{
    public interface IMovingEntity : IGameEntity
    {
        Vector Velocity { get; set; }
        float Mass { get; set; }
        float MaxSpeed { get; set; }
        bool IsDirectionRight { get; set; }
        bool IsDirectionUpwards { get; set; }
        bool IsDirectionDownwards { get; set; }
        void SetSteeringBehavior(ISteeringBehavior steeringBehavior, ISteeringBehavior collisionAvoidingBehavior);
    }
}
