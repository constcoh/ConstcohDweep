using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.LazerProcess
{
    public static class IEntityExtensions
    {
        public static IEnumerable<T> As<T>(
            this IEnumerable<IEntity> entities)
            where T : IEntity
        {
            Condition.Requires(entities, nameof(entities)).IsNotNull();

            return entities.Select(e => (T)e).ToList();
        }

        public static T GetIntersectWithPositionOf<T>(
            this IEnumerable<T> entities,
            IEntity entity)
            where T : IEntity
        {
            Condition.Requires(entities, nameof(entities)).IsNotNull();
            Condition.Requires(entity, nameof(entity)).IsNotNull();

            return entities.FirstOrDefault(e => e.X == entity.X && e.Y == entity.Y);
        }

        public static bool IntersectWithPositionOf(
            this IEnumerable<IEntity> entities,
            IEntity entity)
        {
            Condition.Requires(entities, nameof(entities)).IsNotNull();
            Condition.Requires(entity, nameof(entity)).IsNotNull();

            return entities.Any(e => e.X == entity.X && e.Y == entity.Y);
        }
    }
}
