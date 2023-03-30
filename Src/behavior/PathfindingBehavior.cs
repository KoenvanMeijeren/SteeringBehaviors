using Src.entity;
using Src.graph;
using Src.util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Src.behavior
{
    public class PathfindingBehavior : SteeringBehavior
    {
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
            if (Path != null && Path.Count > 0)
            {
                targetPosition = Path.First().Position;
            }

            Vector desiredVelocity = targetPosition - MovingEntity.Position;
            Vector actualVelocity = desiredVelocity - MovingEntity.Velocity;

            return actualVelocity;
        }

        private void UpdatePathIfNecessary()
        {
            int vectorX = MovingEntity.World.Grid.GetCoordinateOfTile((int)MovingEntity.Position.X);
            int vectorY = MovingEntity.World.Grid.GetCoordinateOfTile((int)MovingEntity.Position.Y);
            Vertex newClosestVertex = MovingEntity.World.Grid.Graph.GetVertex(vectorX, vectorY);

            Vector targetPosition = MovingEntity.World.Player.Position;
            int targetVectorX = MovingEntity.World.Grid.GetCoordinateOfTile((int)targetPosition.X);
            int targetVectorY = MovingEntity.World.Grid.GetCoordinateOfTile((int)targetPosition.Y);
            Vertex newTargetVertex = MovingEntity.World.Grid.Graph.GetVertex(targetVectorX, targetVectorY);

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
            ShortestPathResult result = Graph.GetShortestPath(_closestVertex, _targetVertex);
            if (result == null)
            {
                return;
            }
            
            Path = result.Path;
            SearchedVertices = result.SearchedVertices;
            Console.WriteLine("NEW PATH");
        }
    }
}
