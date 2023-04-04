using System.Collections.Generic;
using System.Linq;
using Src.entity;
using Src.graph;
using Src.grid;
using Src.util;
using Src.world;

namespace Src.behavior
{
    public class PathfindingBehavior : SteeringBehavior
    {
        private const int MaximumPathFindingVelocity = 30;
        private Vertex _closestVertex;
        private Vertex _targetVertex;
        public Stack<Vertex> Path { get; private set; }
        public List<Vertex> SearchedVertices { get; private set; }

        public PathfindingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            UpdatePathIfNecessary();

            Vector targetPosition = MovingEntity.World.Player.Position;
            // Only allow path finding when moving entity is one tile further away.
            if (Path != null && Path.Count > 1)
            {
                targetPosition = Path.First().Position;
            }

            Vector desiredVelocity = targetPosition - MovingEntity.Position;
            Vector actualVelocity = desiredVelocity - MovingEntity.Velocity;

            return actualVelocity.Truncate(MaximumPathFindingVelocity);
        }

        private void UpdatePathIfNecessary()
        {
            IWorld world = MovingEntity.World;
            IGrid grid = world.Grid;

            int vectorX = grid.GetCoordinateOfTile((int)MovingEntity.Position.X);
            int vectorY = grid.GetCoordinateOfTile((int)MovingEntity.Position.Y);
            Vertex newClosestVertex = grid.Graph.GetVertex(vectorX, vectorY);

            Vector targetPosition = world.Player.Position;
            int targetVectorX = grid.GetCoordinateOfTile((int)targetPosition.X);
            int targetVectorY = grid.GetCoordinateOfTile((int)targetPosition.Y);
            Vertex newTargetVertex = grid.Graph.GetVertex(targetVectorX, targetVectorY);

            if (Path != null && Path.Count > 0 && Path.Peek() == newClosestVertex)
            {
                _closestVertex = newClosestVertex;
                Path.Pop();
            }

            if (_targetVertex == newTargetVertex)
            {
                return;
            }

            _closestVertex = newClosestVertex;
            _targetVertex = newTargetVertex;
            ShortestPathResult result = grid.Graph.GetShortestPath(_closestVertex, _targetVertex);
            if (result == null)
            {
                return;
            }

            Path = result.Path;
            SearchedVertices = result.SearchedVertices;
        }
    }
}
