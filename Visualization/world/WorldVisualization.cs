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
using SteeringCS.state;

namespace SteeringCS.world
{
    public class WorldVisualization : WorldBase
    {
        public WorldVisualization(int width, int height) : base(width, height)
        {
        }

        protected override List<IEnemy> GetEnemies()
        {
            List<IEnemy> enemies = new List<IEnemy>();
            for (int index = 0; index < 3; index++)
            {
                Goomba goomba = new Goomba(new Vector(Width / 2, Height / 2), this);
                goomba.ChangeState(new SearchState(goomba));
                enemies.Add(goomba);
            }

            return enemies;
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

        protected override IRescuee GetRescuee()
        {
            IRescuee rescuee = new Luigi(new Vector(400, 40), this);
            rescuee.ChangeState(new LostState(rescuee));

            return rescuee;
        }

        public void RenderHitBox(Graphics graphics)
        {
            Enemies.ForEach(enemy => HitBoxVisualizer.Render(graphics, enemy.HitBox));
            HitBoxVisualizer.Render(graphics, Player.HitBox);
            HitBoxVisualizer.Render(graphics, Rescuee.HitBox);
        }

        public void RenderSteeringBehavior(Graphics graphics)
        {
            Enemies.ForEach(enemy =>
            {
                if (!(enemy is MovingEntity enemyRender))
                {
                    return;
                }

                if (enemyRender.SteeringBehavior is ISteeringBehaviorVisualizer enemySteeringBehaviorVisualizer)
                {
                    enemySteeringBehaviorVisualizer.Render(graphics);
                }

                if (enemyRender.SteeringBehavior.ShouldAvoidObstacles()
                    && enemyRender.CollisionAvoidingBehavior is ISteeringBehaviorVisualizer enemyCollisionBehaviorVisualizer)
                {
                    enemyCollisionBehaviorVisualizer.Render(graphics);
                }
            });

            if (Player is MovingEntity playerRender)
            {
                if (playerRender.SteeringBehavior is ISteeringBehaviorVisualizer playerSteeringVisualizer)
                {
                    playerSteeringVisualizer.Render(graphics);
                }

                if (playerRender.SteeringBehavior.ShouldAvoidObstacles()
                    && playerRender.CollisionAvoidingBehavior is ISteeringBehaviorVisualizer playerCollisionBehaviorVisualizer)
                {
                    playerCollisionBehaviorVisualizer.Render(graphics);
                }
            }

            if (Rescuee is MovingEntity rescueeRender)
            {
                if (rescueeRender.SteeringBehavior is ISteeringBehaviorVisualizer rescueeSteeringBehaviorVisualizer)
                {
                    rescueeSteeringBehaviorVisualizer.Render(graphics);
                }

                if (rescueeRender.SteeringBehavior.ShouldAvoidObstacles()
                    && rescueeRender.CollisionAvoidingBehavior is ISteeringBehaviorVisualizer rescueeCollisionBehaviorVisualizer)
                {
                    rescueeCollisionBehaviorVisualizer.Render(graphics);
                }
            }
        }

        public void RenderVelocity(Graphics graphics)
        {
            Enemies.ForEach(enemy =>
            {
                if (!(enemy is MovingEntity enemyRender))
                {
                    return;
                }

                if (enemyRender.SteeringBehavior is ISteeringBehaviorVisualizer enemySteeringVisualizer)
                {
                    enemySteeringVisualizer.RenderVelocity(graphics);
                }
            });

            if (Player is MovingEntity player && player.SteeringBehavior is ISteeringBehaviorVisualizer playerSteeringVisualizer)
            {
                playerSteeringVisualizer.RenderVelocity(graphics);
            }

            if (Rescuee is MovingEntity rescuee && rescuee.SteeringBehavior is ISteeringBehaviorVisualizer rescueeSteeringVisualizer)
            {
                rescueeSteeringVisualizer.RenderVelocity(graphics);
            }
        }

        public void Render(Graphics graphics) => GridVisualizer.Render(graphics, Grid);

        public void RenderGridOutline(Graphics graphics) => GridVisualizer.RenderOutline(graphics, Grid);

        public void RenderGraph(Graphics graphics) => GridVisualizer.RenderGraph(graphics, Grid);
    }
}
