using Src.entity;

namespace Src.util
{
    public class HitBox
    {
        private readonly IGameEntity _entity;

        public Vector UpperLeftCorner => _entity.Position + new Vector(-_entity.Width / 2, -_entity.Height / 2);
        public Vector UpperRightCorner => _entity.Position + new Vector(_entity.Width / 2, -_entity.Height / 2);
        public Vector LowerLeftCorner => _entity.Position + new Vector(-_entity.Width / 2, _entity.Height / 2);
        public Vector LowerRightCorner => _entity.Position + new Vector(_entity.Width / 2, _entity.Height / 2);

        public HitBox(IGameEntity entity)
        {
            _entity = entity;
        }
    }
}
