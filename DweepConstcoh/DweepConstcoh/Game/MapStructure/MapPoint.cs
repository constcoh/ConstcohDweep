using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.MapStructure
{
    public class MapPoint
    {
        private readonly List<IEntity> _entities;

        public MapPoint(int x, int y)
        {
            this._entities = new List<IEntity>();
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public IReadOnlyCollection<IEntity> Entities => this._entities.ToList();

        public void AddEntity(IEntity entity)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();

            this._entities.Add(entity);
        }

        public void ClearEntitires()
        {
            this._entities.Clear();
        }

        public bool Has(EntityProperty property)
        {
            return this.Entities.Any(entity => entity.Has(property));
        }

        public bool Has(EntityType type)
        {
            return this.Entities.Any(entity => entity.Type == type);
        }

        public bool RemoveEntity(IEntity entity)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();

            return this._entities.Remove(entity);
        }
    }
}
