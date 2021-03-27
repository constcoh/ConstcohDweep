using System;
using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.LazerEntities;
using DweepConstcoh.Game.MapStructure;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.LazerProcess
{
    public class LazerProcessor : IGameProcessor
    {
        private readonly IEnumerable<IEntity> _busyPoints;

        private readonly IMap _map;

        private readonly IEnumerable<MirrorEntity> _mirrors;

        private readonly IEnumerable<IEntity> _walls; 

        public LazerProcessor(
            IMap map)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._map = map;
            this._mirrors = this._map.ListEntitiesOf(EntityType.Mirror).As<MirrorEntity>();
            this._busyPoints = this._map.ListEntitiesWith(EntityProperty.PointIsBusy)
                .Where(entity => entity.Type != EntityType.Mirror);

            this._walls = this._map.ListEntitiesOf(EntityType.Wall);
        }

        public void Process()
        {
            this.RemoveAllRays();
            var lazers = this._map.ListEntitiesOf(EntityType.Lazer).As<LazerEntity>();
            lazers.ForEach(lazer => this.Process(lazer));
        }

        private void Process(LazerEntity lazer)
        {
            var incomingRay = lazer.CreateProducedRay();

            while(incomingRay != null)
            {
                if (_walls.IntersectWithPositionOf(incomingRay))
                {
                    incomingRay = null;
                    continue;
                }

                _map.AddEntity(incomingRay);
                if (_busyPoints.IntersectWithPositionOf(incomingRay))
                {
                    incomingRay = null;
                    continue;
                }

                var mirror = _mirrors.GetIntersectWithPositionOf(incomingRay);
                var outgoingRay = 
                    mirror != null
                    ? mirror.GetReflectedRay(incomingRay)
                    : incomingRay.CreateProducedRay();

                _map.AddEntity(outgoingRay);
                incomingRay = outgoingRay.CreateProducedRay();
            }
        }

        private void RemoveAllRays()
        {
            var rays = this._map.ListEntitiesOf(EntityType.LazerRay);
            this._map.RemoveEntities(rays);
        }
    }
}
