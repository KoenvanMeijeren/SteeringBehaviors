using Src.util;
using Src.world;

namespace Src.entity
{
    public interface IGameEntity
    {
        Vector Position { get; set; }
        float Height { get; }
        float Width { get; }
        HitBox HitBox { get; }
        IWorld World { get; }

        void Update(float timeElapsed);
    }
}
