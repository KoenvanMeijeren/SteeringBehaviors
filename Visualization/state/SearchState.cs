using SteeringCS.behavior;
using System.Collections.Generic;
using Src.behavior;
using Src.entity;
using Src.graph;
using Src.state;
using Src.util;

namespace SteeringCS.state
{
    public class SearchState : IState
    {
        public IMovingEntity MovingEntity { get; }
        private const int _searchDistance = 80;
        private const int _maxShortestPathDistance = 3;

        public SearchState(IMovingEntity movingEntity)
        {
            MovingEntity = movingEntity;
        }

        public void Enter()
        {
            MovingEntity.SetSteeringBehavior(SteeringBehaviorVisualizationFactory.CreateFromEnum(
                SteeringBehaviorOptions.WanderingBehavior, MovingEntity), null);
        }

        public void Execute()
        {
            double distanceFromPlayer = MovingEntity.Position.DistanceBetween(MovingEntity.World.Player.Position);

            bool isPlayerClose = distanceFromPlayer < _searchDistance;

            if (isPlayerClose && IsShortestPathInSearchDistance())
            {
                MovingEntity.ChangeState(new ChaseState(MovingEntity));
            }
        }

        public bool IsShortestPathInSearchDistance()
        {
            int vectorX = MovingEntity.World.Grid.GetCoordinateOfTile((int)MovingEntity.Position.X);
            int vectorY = MovingEntity.World.Grid.GetCoordinateOfTile((int)MovingEntity.Position.Y);
            Vertex closestVertex = MovingEntity.World.Grid.Graph.GetVertex(vectorX, vectorY);

            Vector targetPosition = MovingEntity.World.Player.Position;
            int targetVectorX = MovingEntity.World.Grid.GetCoordinateOfTile((int)targetPosition.X);
            int targetVectorY = MovingEntity.World.Grid.GetCoordinateOfTile((int)targetPosition.Y);
            Vertex targetVertex = MovingEntity.World.Grid.Graph.GetVertex(targetVectorX, targetVectorY);

            Stack<Vertex> path = Graph.GetShortestPath(closestVertex, targetVertex);
            if (path == null)
            {
                return false;
            }

            return path.Count < _maxShortestPathDistance;
        }
    }
}
