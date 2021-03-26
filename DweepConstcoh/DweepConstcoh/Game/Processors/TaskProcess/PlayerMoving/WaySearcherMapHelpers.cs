using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving
{
    public static class WaySearcherMapHelpers
    {
        public static bool[,] CreateBusyPointsMatrix(
            this IMap map)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            var walls = new bool[map.Width, map.Height];
            var busyPoints = map.ListEntitiesWith(EntityProperty.PointIsBusy);

            busyPoints.ForEach(point =>
            {
                walls[point.X, point.Y] = true;
            });

            return walls;
        }

        public static float[,] CreateInitialWayLength(
            this IMap map,
            float infinityWayLength)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            var wayLength = new float[map.Width, map.Height];
            for (int x = 0; x < map.Width; ++x)
                for (int y = 0; y < map.Height; ++y)
                {
                    wayLength[x, y] = infinityWayLength;
                }

            return wayLength;
        }

        public static WayPoint GetPlayerPoint(
            this IMap map)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            var player = (PlayerEntity)map.ListEntitiesOf(EntityType.Player).FirstOrDefault();

            return new WayPoint(player.X, player.Y);
        }
    }
}
