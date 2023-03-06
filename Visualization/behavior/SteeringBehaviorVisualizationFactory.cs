using System.ComponentModel;
using Src.behavior;
using Src.entity;

namespace SteeringCS.behavior
{
    public static class SteeringBehaviorVisualizationFactory
    {
        public static ISteeringBehaviorVisualizer CreateFromEnum(SteeringBehaviorOptions selectedOption, IMovingEntity movingEntity)
        {
            switch (selectedOption)
            {
                case SteeringBehaviorOptions.IdlingBehavior:
                    {
                        return new IdlingBehaviorVisualizer(movingEntity);
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
                default: throw new InvalidEnumArgumentException("Could not create steering behavior for the selected option.");
            }
        }
    }
}
