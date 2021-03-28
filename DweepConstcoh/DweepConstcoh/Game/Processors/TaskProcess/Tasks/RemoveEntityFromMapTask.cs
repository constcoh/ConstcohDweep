using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Processors.TaskProcess.Tasks
{
    public class RemoveEntityFromMapTask : BaseTask
    {
        private IEntity _entity;
        private IMap _map;

        public RemoveEntityFromMapTask(
            IEntity entity,
            IMap map,
            int delayInMilliseconds)
            : base(delayInMilliseconds)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._entity = entity;
            this._map = map;
        }

        public override TaskProcessResponse Process()
        {
            this._map.RemoveEntity(this._entity);

            return new TaskProcessResponse();
        }
    }
}
