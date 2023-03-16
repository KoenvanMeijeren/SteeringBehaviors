using Src.entity;

namespace Src.util
{
    public class HitBox
    {
        private readonly IGameEntity _entity;

        public VectorImmutable UpperLeftCorner => _entity.Position + new VectorImmutable(-_entity.Width / 2, -_entity.Height / 2);
        public VectorImmutable UpperRightCorner => _entity.Position + new VectorImmutable(_entity.Width / 2, -_entity.Height / 2);
        public VectorImmutable LowerLeftCorner => _entity.Position + new VectorImmutable(-_entity.Width / 2, _entity.Height / 2);
        public VectorImmutable LowerRightCorner => _entity.Position + new VectorImmutable(_entity.Width / 2, _entity.Height / 2);

        public HitBox(IGameEntity entity)
        {
            _entity = entity;
        }
    }
}
