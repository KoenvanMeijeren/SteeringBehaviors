using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.world
{
    public class GridTile
    {
        private List<MovingEntity> _entities;

        public GridTile()
        {
            _entities = new List<MovingEntity>();
        }

        public void AddEntity(MovingEntity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(MovingEntity entity)
        {
            _entities.Remove(entity);
        }

        public bool IsEmpty()
        {
            return _entities.Count == 0;
        }
    }
}
