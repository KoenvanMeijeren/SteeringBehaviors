using System.ComponentModel;
using Visualization.behavior;
using Visualization.entity;

namespace SteeringCS.behavior
{
    public static class SteeringBehaviorVisualizationFactory
    {
        public static ISteeringBehaviorVisualizer CreateFromEnum(SteeringBehaviorOptions selectedOption, IMovingEntity movingEntity)
        {
            switch (selectedOption)
            {
                case SteeringBehaviorOptions.NotImplementedBehavior:
                case SteeringBehaviorOptions.IdlingBehavior:
                    {
                        return new IdlingBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.ArrivingBehavior:
                    {
                        return new ArrivingBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.SeekingBehavior:
                    {
                        return new SeekingBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.FleeingBehavior:
                    {
                        return new FleeingBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.MosquitoBehavior:
                    {
                        return new MosquitoBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.WanderingBehavior:
                    {
                        return new WanderingBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.PathfindingBehavior:
                    {
                        return new PathfindingBehaviorVisualizer(movingEntity);
                    }
                case SteeringBehaviorOptions.KeyboardBehavior:
                    {
                        return new KeyboardBehaviorVisualizer(movingEntity);
                    }
                default: throw new InvalidEnumArgumentException("Could not create steering behavior for the selected option.");
            }
        }
    }
}
