using System.Collections.Generic;
using Src.entity;
using Src.graph;

namespace Src.grid
{
    public class PathTile : GridTile
    {
        public readonly Vertex Vertex;
        private readonly List<IMovingEntity> _entities = new List<IMovingEntity>();

        public PathTile(int size, int x, int y) : base(size, x, y)
        {
            Vertex = new Vertex(x + (size / 2), y + (size / 2));
        }

        public void AddEntity(IMovingEntity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(IMovingEntity entity)
        {
            _entities.Remove(entity);
        }

        public bool IsEmpty()
        {
            return _entities.Count == 0;
        }
    }
}
