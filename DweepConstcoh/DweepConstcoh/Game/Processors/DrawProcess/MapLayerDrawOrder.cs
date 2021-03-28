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
            { MapLayer.PlayerBody, 2 },
            { MapLayer.Player, 3 },
            { MapLayer.Air, 4 },
            { MapLayer.ToolsetSelector, 5 }
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
