using System.ComponentModel;
using Src.entity;

namespace Src.behavior
{
    public enum SteeringBehaviorOptions
    {
        IdlingBehavior,
        ArrivingBehavior,
        SeekingBehavior,
        FleeingBehavior,
        MosquitoBehavior,
        WanderingBehavior,
        PathfindingBehavior,
        KeyboardBehavior,
        NotImplementedBehavior
    }

    public static class SteeringBehaviorFactory
    {
        public static ISteeringBehavior CreateFromEnum(SteeringBehaviorOptions selectedOption, IMovingEntity movingEntity)
        {
            switch (selectedOption)
            {
                case SteeringBehaviorOptions.IdlingBehavior:
                    {
                        return new IdlingBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.ArrivingBehavior:
                    {
                        return new ArrivingBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.SeekingBehavior:
                    {
                        return new SeekingBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.FleeingBehavior:
                    {
                        return new FleeingBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.MosquitoBehavior:
                    {
                        return new MosquitoBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.WanderingBehavior:
                    {
                        return new WanderingBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.PathfindingBehavior:
                    {
                        return new PathfindingBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.KeyboardBehavior:
                    {
                        return new KeyboardBehavior(movingEntity);
                    }
                case SteeringBehaviorOptions.NotImplementedBehavior:
                default: throw new InvalidEnumArgumentException("Could not create steering behavior for the selected option.");
            }
        }
    }
}
