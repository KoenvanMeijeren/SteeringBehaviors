using Src.entity;

namespace Src.util
{
    public class HitBox
    {
        private readonly IGameEntity _entity;

        public Vector UpperLeftCorner
        {
            get
            {
                if (_entity == null)
                {
                    return null;
                }

                return _entity.Position + new Vector(-_entity.Width / 2, -_entity.Height / 2);
            }
        }

        public Vector UpperRightCorner
        {
            get
            {
                if (_entity == null)
                {
                    return null;
                }
                
                return _entity.Position + new Vector(_entity.Width / 2, -_entity.Height / 2);
            }
        }

        public Vector LowerLeftCorner
        {
            get
            {
                if (_entity == null)
                {
                    return null;
                }
                
                return _entity.Position + new Vector(-_entity.Width / 2, _entity.Height / 2);
            }
        }

        public Vector LowerRightCorner
        {
            get
            {
                if (_entity == null)
                {
                    return null;
                }
                
                return _entity.Position + new Vector(_entity.Width / 2, _entity.Height / 2);
            }
        }

        public HitBox(IGameEntity entity)
        {
            _entity = entity;
        }
    }
}
