﻿using System.Collections.Generic;
using System.Drawing;
using Src.behavior;
using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.behavior;
using SteeringCS.entity;
using SteeringCS.grid;
using SteeringCS.util;

namespace SteeringCS.world
{
    public class WorldVisualization : WorldBase
    {
        public WorldVisualization(int width, int height): base(width, height)
        {
        }

        protected override List<IMovingEntity> GetPopulation()
        {
            List<IMovingEntity> entities = new List<IMovingEntity>();
            Vehicle vehicle = new Vehicle(new Vector(Width / 2, Height / 2), this)
            {
                Color = Color.Blue,
            };
            entities.Add(vehicle);

            Target = new Vehicle(new Vector(100, 60), this)
            {
                Color = Color.DarkRed,
                Position = new Vector(100, 40)
            };

            return entities;
        }

        public void EditPopulation(SteeringBehaviorOptions selectedOption, int mass, int maxSpeed)
        {
            foreach (IMovingEntity entity in Entities)
            {
                entity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(selectedOption, entity));
                entity.Mass = mass;
                entity.MaxSpeed = maxSpeed;
            }
        }

        public void Render(Graphics graphics)
        {
            Entities.ForEach(entity =>
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