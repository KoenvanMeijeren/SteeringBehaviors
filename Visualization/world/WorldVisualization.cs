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

        protected override List<IEnemy> GetEnemies()
        {
            Goomba goomba = new Goomba(new Vector(Width / 2, Height / 2), this);
            return new List<IEnemy> { goomba };
        }

        protected override IPlayer GetPlayer()
        {
            IPlayer player = new Mario(new Vector(100, 40), this);
            player.SetSteeringBehavior(
                SteeringBehaviorVisualizationFactory.CreateFromEnum(SteeringBehaviorOptions.KeyboardBehavior, player),
                new CollisionAvoidingBehaviorVisualizer(player)
            );

            return player;
        }

        protected override IRescue GetRescue()
        {
            IRescue rescue = new Luigi(new Vector(100, 40), this);
            rescue.SetSteeringBehavior(
                SteeringBehaviorVisualizationFactory.CreateFromEnum(SteeringBehaviorOptions.PathfindingBehavior, rescue),
                new CollisionAvoidingBehaviorVisualizer(rescue)
            );

            return rescue;
        }

        public void EditPopulation(SteeringBehaviorOptions selectedOption, int mass, int maxSpeed)
        {
            foreach (IEnemy enemy in Enemies)
            {
                enemy.SetSteeringBehavior(
                    SteeringBehaviorVisualizationFactory.CreateFromEnum(selectedOption, enemy),
                    new CollisionAvoidingBehaviorVisualizer(enemy)
                );
                enemy.Mass = mass;
                enemy.MaxSpeed = maxSpeed;
            }
        }

        public void RenderHitBox(Graphics graphics)
        {
            Enemies.ForEach(entity =>
            {
                HitBoxVisualizer.Render(graphics, entity.HitBox);
            });

            HitBoxVisualizer.Render(graphics, Player.HitBox);
        }

        public void RenderSteeringBehavior(Graphics graphics)
        {
            Enemies.ForEach(entity =>
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

            if (!(Player is MovingEntity targetRender))
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
            Enemies.ForEach(entity =>
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

            if (!(Player is MovingEntity targetRender))
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
