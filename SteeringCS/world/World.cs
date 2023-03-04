using System.Collections.Generic;
using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.grid;
using Src.util;
using Src.world;
using SteeringCS.behavior;
using SteeringCS.entity;
using SteeringCS.grid;
using SteeringCS.util;

namespace SteeringCS.world
{
    public class World : IWorld
    {
        private readonly List<IMovingEntity> _entities = new List<IMovingEntity>();
        public IGrid Grid { get; }
        public IMovingEntity Target { get; private set; }

        public int Width { get; }
        public int Height { get; }

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
            _entities.Add(vehicle);

            Target = new Vehicle(new Vector(100, 60), this)
            {
                Color = Color.DarkRed,
                Position = new Vector(100, 40)
            };
        }

        public void EditPopulation(SteeringBehaviorOptions selectedOption, int mass, int maxSpeed)
        {
            foreach (IMovingEntity entity in _entities)
            {
                entity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(selectedOption, entity));
                entity.Mass = mass;
                entity.MaxSpeed = maxSpeed;
            }
        }

        public void Update(float timeElapsed)
        {
            foreach (IMovingEntity entity in _entities)
            {
                Vector oldPos = entity.Position.Clone();
                entity.Update(timeElapsed);
                Vector newPos = entity.Position.Clone();
                Grid.MoveEntityIfInDifferentTile(oldPos, newPos, entity);
            }
        }

        public void Render(Graphics graphics)
        {
            _entities.ForEach(entity =>
            {
                if (entity is IRender render)
                {
                    render.Render(graphics);
                }
            });

            if (Target is IRender targetRender)
            {
                targetRender.Render(graphics);
            }
        }

        public void RenderGrid(Graphics graphics) => GridVisualizer.Render(graphics, Grid);

        public void RenderGridOutline(Graphics graphics) => GridVisualizer.RenderOutline(graphics, Grid);

        public void RenderGraph(Graphics graphics) => GridVisualizer.RenderGraph(graphics, Grid);
    }
}
