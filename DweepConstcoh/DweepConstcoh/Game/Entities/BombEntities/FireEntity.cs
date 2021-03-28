using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.BombEntities.Tasks;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Processors.TaskProcess.Tasks;

namespace DweepConstcoh.Game.Entities.BombEntities
{
    public class FireEntity : BaseEntity
    {
        private readonly IMap _map;

        private readonly ITaskProcessor _taskProcessor;

        public FireEntity(
            int x,
            int y,
            IEntityFactory entityFactory,
            IMap map,
            ITaskProcessor taskProcessor)
            : base(
                  EntityType.Fire,
                  x,
                  y,
                  MapLayer.PlayerBody)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            var mapPoint = map.At(this.X, this.Y);
            taskProcessor.Add(
                new BombMapPointTask(mapPoint));

            taskProcessor.Add(
                new RemoveEntityFromMapTask(
                    this, 
                    map, 
                    delayInMilliseconds: 300));
        }
    }
}
