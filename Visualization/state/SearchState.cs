using SteeringCS.behavior;
using Src.behavior;
using Src.entity;
using Src.graph;
using Src.grid;
using Src.state;
using Src.util;
using Src.world;

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
                MovingEntity.ChangeState(new AttackState(MovingEntity));
            }
        }

        private bool IsShortestPathInSearchDistance()
        {
            IWorld world = MovingEntity.World;
            IGrid grid = world.Grid;

            int vectorX = grid.GetCoordinateOfTile((int)MovingEntity.Position.X);
            int vectorY = grid.GetCoordinateOfTile((int)MovingEntity.Position.Y);
            Vertex closestVertex = world.Grid.Graph.GetVertex(vectorX, vectorY);

            Vector targetPosition = world.Player.Position;
            int targetVectorX = grid.GetCoordinateOfTile((int)targetPosition.X);
            int targetVectorY = grid.GetCoordinateOfTile((int)targetPosition.Y);
            Vertex targetVertex = grid.Graph.GetVertex(targetVectorX, targetVectorY);

            ShortestPathResult result = grid.Graph.GetShortestPath(closestVertex, targetVertex);
            if (result == null)
            {
                return false;
            }

            return result.Path.Count < _maxShortestPathDistance;
        }

        public override string ToString() => "Search";
    }
}
