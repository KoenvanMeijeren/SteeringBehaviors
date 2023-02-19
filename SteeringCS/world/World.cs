using System.Collections.Generic;
using System.Drawing;
using SteeringCS.behavior;
using SteeringCS.entity;
using SteeringCS.util;

namespace SteeringCS.world
{
    public class World
    {
        private readonly List<MovingEntity> _entities = new List<MovingEntity>();
        private Grid _grid;
        public Vehicle Target { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Populate();
            _grid = new Grid(width, height, _entities);
        }

        private void Populate()
        {
            Vehicle vehicle = new Vehicle(new Vector2D(Width / 2, Height / 2), this)
            {
                Color = Color.Blue,
            };

            vehicle.AddSeekingBehavior();
            _entities.Add(vehicle);

            Target = new Vehicle(new Vector2D(100, 60), this)
            {
                Color = Color.DarkRed,
                Position = new Vector2D(100, 40)
            };
        }

        public void EditPopulation(SteeringBehaviorOptions steeringBehaviorOption, int mass, int maxSpeed)
        {
            foreach (MovingEntity entity in _entities)
            {
                entity.AddSteeringBehavior(steeringBehaviorOption);
                entity.Mass = mass;
                entity.MaxSpeed = maxSpeed;
            }
        }

        public void Update(float timeElapsed)
        {
            foreach (MovingEntity entity in _entities)
            {
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
