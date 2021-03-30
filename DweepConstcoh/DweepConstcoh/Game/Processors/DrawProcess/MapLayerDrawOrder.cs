using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Processors.DrawProcess
{
    public static class MapLayerDrawOrder
    {
        private static readonly IDictionary<MapLayer, int> _mapLayerSortedByDrawOrder = new Dictionary<MapLayer, int> 
        {
            { MapLayer.Ground, 0 },
            { MapLayer.OnGround, 1 },
            { MapLayer.PlayerFeets, 2 },
            { MapLayer.PlayerBody, 3 },
            { MapLayer.Player, 4 },
            { MapLayer.Air, 5 },
            { MapLayer.ToolsetSelector, 6 }
        };

        public static IOrderedEnumerable<IEntity> OrderByDrawOrder(
            this IEnumerable<IEntity> entities)
        {
            Condition.Requires(entities, nameof(entities)).IsNotNull();

            return entities
                .OrderBy(entity => _mapLayerSortedByDrawOrder[entity.MapLayer]);
        }
    }
}
