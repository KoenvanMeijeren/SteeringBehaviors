using Src.entity;

namespace Src.util
{
    public class HitBox
    {
        private readonly IGameEntity _entity;

        public Vector UpperLeftCorner => _entity.Position.Clone().Add(-_entity.Width / 2, -_entity.Height / 2);
        public VectorImmutable UpperLeftCornerImmutable => _entity.PositionImmutable + new VectorImmutable(-_entity.Width / 2, -_entity.Height / 2);
        public Vector UpperRightCorner => _entity.Position.Clone().Add(_entity.Width / 2, -_entity.Height / 2);
        public VectorImmutable UpperRightCornerImmutable => _entity.PositionImmutable + new VectorImmutable(_entity.Width / 2, -_entity.Height / 2);
        public Vector LowerLeftCorner => _entity.Position.Clone().Add(-_entity.Width / 2, _entity.Height / 2);
        public VectorImmutable LowerLeftCornerImmutable => _entity.PositionImmutable + new VectorImmutable(-_entity.Width / 2, _entity.Height / 2);
        public Vector LowerRightCorner => _entity.Position.Clone().Add(_entity.Width / 2, _entity.Height / 2);
        public VectorImmutable LowerRightCornerImmutable => _entity.PositionImmutable + new VectorImmutable(_entity.Width / 2, _entity.Height / 2);

        public HitBox(IGameEntity entity)
        {
            _entity = entity;
        }
    }
}
