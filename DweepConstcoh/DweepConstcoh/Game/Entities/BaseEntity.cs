using System.Collections.Generic;
using System.Linq;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities
{
    public abstract class BaseEntity : IEntity
    {
        private readonly List<EntityProperty> _properties;

        public BaseEntity(
            EntityType type,
            int x,
            int y,
            MapLayer mapLayer)
            : this(
                  type,
                  x,
                  y,
                  mapLayer,
                  new EntityProperty[0])
        {
        }

        public BaseEntity(
            EntityType type,
            int x,
            int y,
            MapLayer mapLayer,
            EntityProperty property)
            : this(
                  type,
                  x,
                  y,
                  mapLayer,
                  new[] { property })
        {
        }

        public BaseEntity(
            EntityType type,
            int x,
            int y,
            MapLayer mapLayer,
            EntityProperty[] properties)
        {
            this.Type = type;
            this.X = x;
            this.Y = y;
            this.MapLayer = mapLayer;
            this._properties = properties.ToList();
        }

        public EntityType Type { get; }

        public MapLayer MapLayer { get; protected set; }

        public int X { get; protected set; }

        public int Y { get; protected set; }

        public bool Has(EntityProperty property)
        {
            return this._properties.Contains(property);
        }

        public virtual bool ApplyTool(EntityType entityType)
        {
            return false;
        }

        public virtual void Bomb()
        {
        }
        
        public virtual void Lazer()
        {
        }

        protected bool Remove(EntityProperty property)
        {
            return this._properties.Remove(property);
        }
    }
}
