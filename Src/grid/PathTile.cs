using System.Collections.Generic;
using Src.entity;
using Src.graph;

namespace Src.grid
{
    public class PathTile : GridTile
    {
        public readonly Vertex Vertex;
        public readonly List<IMovingEntity> Entities = new List<IMovingEntity>();
        public bool IsFinish;

        public PathTile(int size, int x, int y) : base(size, x, y)
        {
            Vertex = new Vertex(x + (size / 2), y + (size / 2));
        }

        public PathTile(int size, int x, int y, bool isFinish) : base(size, x, y)
        {
            Vertex = new Vertex(x + (size / 2), y + (size / 2));
            IsFinish = isFinish;
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
