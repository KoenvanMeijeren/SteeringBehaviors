using System.Collections.Generic;
using Visualization.entity;
using Visualization.graph;

namespace Visualization.grid
{
    public class PathTile : GridTile
    {
        public readonly Vertex Vertex;
        public readonly List<IMovingEntity> Entities = new List<IMovingEntity>();

        public PathTile(int size, int x, int y) : base(size, x, y)
        {
            Vertex = new Vertex(x + (size / 2), y + (size / 2));
        }

        public void AddEntity(IMovingEntity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(IMovingEntity entity)
        {
            Entities.Remove(entity);
        }

        public bool IsEmpty()
        {
            return Entities.Count == 0;
        }
    }
}
