using SteeringCS.entity;
using SteeringCS.graph;
using SteeringCS.util;
using SteeringCS.world;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.grid
{
    public class PathTile : GridTile
    {
        public Vertex Vertex;
        private List<MovingEntity> _entities;

        public PathTile(int size, int x, int y) : base (size, x, y)
        {
            Vertex = new Vertex(x + (size / 2), y + (size / 2));
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

        public override void Draw(Graphics graphic)
        {
            Brush Brush = new SolidBrush(Color.AliceBlue);
            Rectangle rectangle = new Rectangle(Position.X, Position.Y, _size, _size);
            graphic.FillRectangle(Brush, rectangle);
        }
    }
}
