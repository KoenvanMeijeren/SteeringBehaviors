using Visualization.behavior;
using Visualization.state;
using Visualization.util;
using Visualization.world;

namespace Visualization.entity
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
        ISteeringBehavior SteeringBehavior { get; }
        ISteeringBehavior CollisionAvoidingBehavior { get; }
        IState State { get; }
        void Update(float timeElapsed);
        void SetSteeringBehavior(ISteeringBehavior steeringBehavior, ISteeringBehavior collisionAvoidingBehavior);
        void ChangeState(IState state);
    }
}
