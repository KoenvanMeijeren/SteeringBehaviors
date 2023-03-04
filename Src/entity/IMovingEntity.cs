using Src.behavior;
using Src.util;

namespace Src.entity
{
    public interface IMovingEntity : IGameEntity
    {
        Vector Velocity { get; set; }
        float Mass { get; set; }
        float MaxSpeed { get; set; }
        void SetSteeringBehavior(ISteeringBehavior steeringBehavior);
        void AlterVectorToStayInsideOfWorld(Vector vector);
        void AlterVectorToStayOutOfWalls(Vector vector);
    }
}
