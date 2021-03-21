using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving
{
    public class PlayerGoToTargetTask : BaseTask
    {
        private IMap _map;

        private readonly int _targetX;

        private readonly int _targetY;


        public PlayerGoToTargetTask(
            IMap map,
            int targetX, 
            int targetY)
            : base(TaskType.PlayerMoving)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(map.IsOnMap(targetX, targetY), nameof(map)).IsTrue();

            this._map = map;
            this._targetX = targetX;
            this._targetY = targetY;
        }

        public override TaskProcessResponse Process()
        {
            var player = (PlayerEntity)_map.ListEntitiesOf(EntityType.Player).FirstOrDefault();
            var waySearcher = new WaySearcher(_map, new WayPoint(_targetX, _targetY));
            var way = waySearcher.ListWayPoints();
            var movePlayerTask = new MovePlayerTask(
                _map,
                player,
                way);

            return new TaskProcessResponse(movePlayerTask);
        }
    }
}
