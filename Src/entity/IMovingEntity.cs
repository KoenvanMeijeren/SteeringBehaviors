using Src.behavior;
using Src.util;

namespace Src.entity
{
    public interface IMovingEntity : IGameEntity
    {
        Vector Velocity { get; set; }
        float Mass { get; set; }
        float MaxSpeed { get; set; }
        
        void SetSeekingBehavior();
        void SetFleeingBehavior();
        void SetMosquitoBehavior();
        void SetIdlingBehavior();
        void SetWanderingBehavior();
        void SetSteeringBehavior(SteeringBehaviorOptions steeringBehaviorOption);
        void AlterVectorToStayInsideOfWorld(Vector vector);
        void AlterVectorToStayOutOfWalls(Vector vector);
    }
}
