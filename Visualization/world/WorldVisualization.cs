using System.Collections.Generic;
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
        public WorldVisualization(int width, int height) : base(width, height)
        {
        }

        protected override List<IMovingEntity> GetPopulation()
        {
            List<IMovingEntity> entities = new List<IMovingEntity>();

            Luigi vehicle = new Luigi(new Vector(Width / 2, Height / 2), this);
            entities.Add(vehicle);

            Target = new Mario(new Vector(100, 40), this);
            Target.SetSteeringBehavior(
                SteeringBehaviorVisualizationFactory.CreateFromEnum(SteeringBehaviorOptions.KeyboardBehavior, Target),
                new CollisionAvoidingBehaviorVisualizer(Target)
            );

            return entities;
        }

        public void EditPopulation(SteeringBehaviorOptions selectedOption, int mass, int maxSpeed)
        {
            foreach (IMovingEntity entity in Entities)
            {
                entity.SetSteeringBehavior(
                    SteeringBehaviorVisualizationFactory.CreateFromEnum(selectedOption, entity),
                    new CollisionAvoidingBehaviorVisualizer(entity)
                );
                entity.Mass = mass;
                entity.MaxSpeed = maxSpeed;
            }
        }

        public void RenderHitBox(Graphics graphics)
        {
            Entities.ForEach(entity =>
            {
                HitBoxVisualizer.Render(graphics, entity.HitBox);
            });

            HitBoxVisualizer.Render(graphics, Target.HitBox);
        }

        public void RenderSteeringBehavior(Graphics graphics)
        {
            Entities.ForEach(entity =>
            {
                if (!(entity is MovingEntity entityRender))
                {
                    return;
                }

                if (entityRender.SteeringBehavior is ISteeringBehaviorVisualizer steeringBehaviorEntityVisualizer)
                {
                    steeringBehaviorEntityVisualizer.Render(graphics);
                }

                if (entityRender.CollisionAvoidingBehavior is ISteeringBehaviorVisualizer collisionBehaviorEntityVisualizer)
                {
                    collisionBehaviorEntityVisualizer.Render(graphics);
                }
            });

            if (!(Target is MovingEntity targetRender))
            {
                return;
            }

            if (targetRender.SteeringBehavior is ISteeringBehaviorVisualizer steeringBehaviorTargetVisualizer)
            {
                steeringBehaviorTargetVisualizer.Render(graphics);
            }

            if (targetRender.CollisionAvoidingBehavior is ISteeringBehaviorVisualizer collisionBehaviorTargetVisualizer)
            {
                collisionBehaviorTargetVisualizer.Render(graphics);
            }
        }

        public void RenderVelocity(Graphics graphics)
        {
            Entities.ForEach(entity =>
            {
                if (!(entity is MovingEntity entityRender))
                {
                    return;
                }

                if (entityRender.SteeringBehavior is ISteeringBehaviorVisualizer entityVisualizer)
                {
                    entityVisualizer.RenderVelocity(graphics);
                }
            });

            if (!(Target is MovingEntity targetRender))
            {
                return;
            }

            if (targetRender.SteeringBehavior is ISteeringBehaviorVisualizer targetVisualizer)
            {
                targetVisualizer.RenderVelocity(graphics);
            }
        }

        public void Render(Graphics graphics) => GridVisualizer.Render(graphics, Grid);

        public void RenderGridOutline(Graphics graphics) => GridVisualizer.RenderOutline(graphics, Grid);

        public void RenderGraph(Graphics graphics) => GridVisualizer.RenderGraph(graphics, Grid);
    }
}
