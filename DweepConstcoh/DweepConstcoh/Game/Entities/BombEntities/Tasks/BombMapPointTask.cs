using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.TaskProcess;

namespace DweepConstcoh.Game.Entities.BombEntities.Tasks
{
    public class BombMapPointTask : BaseTask
    {
        private MapPoint _mapPoint;

        public BombMapPointTask(MapPoint mapPoint)
            : base(delayInMilliseconds: 300)
        {
            Condition.Requires(mapPoint, nameof(mapPoint)).IsNotNull();

            this._mapPoint = mapPoint;
        }

        public override TaskProcessResponse Process()
        {
            var entities = this._mapPoint.Entities
                .Where(entity => entity.MapLayer != MapLayer.Air)
                .ToList();

            entities.ForEach(entity => entity.Bomb());

            return new TaskProcessResponse();
        }
    }
}
