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
        private readonly IMap _map;

        public LazerProcessor(
            IMap map)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._map = map;
        }

        public void Process()
        {
            this.RemoveAllRays();
            var lazers = this._map.ListEntitiesOf(EntityType.Lazer).As<LazerEntity>();
            lazers.ForEach(lazer => this.Process(lazer));
        }

        private void Process(LazerEntity lazer)
        {
            var walls = this._map.ListEntitiesOf(EntityType.Wall);
            var mirrors = this._map.ListEntitiesOf(EntityType.Mirror).As<MirrorEntity>();
            var stopLazerPoints = this._map.ListEntitiesWith(EntityProperty.StopLazerRay)
                .Where(entity => entity.Type != EntityType.Mirror);

            var incomingRay = lazer.CreateProducedRay();

            while(incomingRay != null)
            {
                if (walls.IntersectWithPositionOf(incomingRay))
                {
                    incomingRay = null;
                    continue;
                }

                _map.AddEntity(incomingRay);
                _map.LazerPoint(incomingRay.X, incomingRay.Y);
                var stopLazerPoint = stopLazerPoints.GetIntersectWithPositionOf(incomingRay);
                if (stopLazerPoint != null)
                {
                    incomingRay = null;
                    continue;
                }

                var mirror = mirrors.GetIntersectWithPositionOf(incomingRay);
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
