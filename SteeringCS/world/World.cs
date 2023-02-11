using System.Collections.Generic;
using System.Drawing;
using SteeringCS.behaviour;
using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.world
{
    public class World
    {
        private readonly List<MovingEntity> _entities = new List<MovingEntity>();
        public Vehicle Target { get; private set; }

        private readonly int _width;
        private readonly int _height;

        public World(int width, int height)
        {
            _width = width;
            _height = height;
            Populate();
        }

        private void Populate()
        {
            var vehicle = new Vehicle(new Vector2D(10, 10), this)
            {
                Color = Color.Blue,

            };
            _entities.Add(vehicle);

            Target = new Vehicle(new Vector2D(100, 60), this)
            {
                Color = Color.DarkRed,
                Position = new Vector2D(100, 40)
            };
        }

        public void Update(float timeElapsed)
        {
            foreach (var entity in _entities)
            {
                entity.SteeringBehaviour = new SeekBehaviour(entity);
                entity.Update(timeElapsed);
            }
        }

        public void Render(Graphics graphics)
        {
            _entities.ForEach(entity => entity.Render(graphics));
            Target.Render(graphics);
        }
    }
}
