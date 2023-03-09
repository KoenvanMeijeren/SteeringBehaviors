using Src.entity;
using Src.graph;
using Src.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.behavior
{
    public class PathfindingBehavior : SteeringBehavior
    {
        private Vertex ClosestVertex;
        private Vertex TargetVertex;
        public Stack<Vertex> Path;

        public PathfindingBehavior(IMovingEntity movingEntity) : base(movingEntity)
        {
        }

        public override Vector Calculate()
        {
            UpdatePathIfNecessary();

            if (Path == null || Path.Count < 1)
            {
                return new Vector(0,0);
            }

            VectorImmutable targetPositionImmutable = Path.First().Position;
            Vector targetPosition = new Vector(targetPositionImmutable.X, targetPositionImmutable.Y);
            Vector desiredVelocity = targetPosition.Subtract(MovingEntity.Position);

            Vector actualVelocity = desiredVelocity.Subtract(MovingEntity.Velocity);
            return actualVelocity;
        }

        public void UpdatePathIfNecessary()
        {
            int vectorX = MovingEntity.World.Grid.GetCoordinateOfTile((int)MovingEntity.Position.X);
            int vectorY = MovingEntity.World.Grid.GetCoordinateOfTile((int)MovingEntity.Position.Y);
            Vertex newClosestVertex = MovingEntity.World.Grid.Graph.GetVertex(vectorX, vectorY);

            Vector targetPosition = MovingEntity.World.Target.Position.Clone();
            int targetVectorX = MovingEntity.World.Grid.GetCoordinateOfTile((int)targetPosition.X);
            int targetVectorY = MovingEntity.World.Grid.GetCoordinateOfTile((int)targetPosition.Y);
            Vertex newTargetVertex = MovingEntity.World.Grid.Graph.GetVertex(targetVectorX, targetVectorY);

            if (ClosestVertex != newClosestVertex || TargetVertex != newTargetVertex)
            {
                ClosestVertex = newClosestVertex;
                TargetVertex = newTargetVertex;
                Path = MovingEntity.World.Grid.Graph.getShortestPath(ClosestVertex, TargetVertex);
            }
        }
    }
}
