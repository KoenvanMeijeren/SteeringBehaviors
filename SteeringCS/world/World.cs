using System.Collections.Generic;
using System.Drawing;
using Src.util;
using SteeringCS.behavior;
using SteeringCS.entity;
using SteeringCS.grid;

namespace SteeringCS.world
{
    public class World
    {
        private readonly List<MovingEntity> _entities = new List<MovingEntity>();
        public readonly Grid Grid;
        public Vehicle Target { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Populate();
            Grid = new Grid(width, height, _entities);
        }

        private void Populate()
        {
            Vehicle vehicle = new Vehicle(new Vector(Width / 2, Height / 2), this)
            {
                Color = Color.Blue,
            };

            vehicle.AddSeekingBehavior();
            _entities.Add(vehicle);

            Target = new Vehicle(new Vector(100, 60), this)
            {
                Color = Color.DarkRed,
                Position = new Vector(100, 40)
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
                Vector oldPos = entity.Position.Clone();
                entity.Update(timeElapsed);
                Vector newPos = entity.Position.Clone();
                Grid.MoveEntityIfInDifferentTile(oldPos, newPos, entity);
            }
        }

        public void Render(Graphics graphics)
        {
            _entities.ForEach(entity => entity.Render(graphics));
            Target.Render(graphics);
        }

        public void RenderGrid(Graphics graphics)
        {
            Grid.Render(graphics);
        }

        public void RenderGridOutline(Graphics graphics)
        {
            Grid.RenderOutline(graphics);
        }

        public void RenderGraph(Graphics graphics)
        {
            Grid.RenderGraph(graphics);
        }
    }
}
