using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.LazerEntities;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Processors.LazerProcess
{
    public class LazerEntityProcessor
    {
        private readonly LazerEntity _lazerEntity;

        private readonly IMap _map;

        public LazerEntityProcessor(
            LazerEntity lazerEntity,
            IMap map)
        {
            Condition.Requires(lazerEntity, nameof(lazerEntity)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._lazerEntity = lazerEntity;
            this._map = map;
        }

        public void Process()
        {

        }
    }
}
