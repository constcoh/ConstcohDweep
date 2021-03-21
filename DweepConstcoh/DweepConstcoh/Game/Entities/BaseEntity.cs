using System.Linq;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities
{
    public abstract class BaseEntity : IEntity
    {
        private readonly EntityProperty[] _properties;

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
            EntityProperty[] properties)
        {
            this.Type = type;
            this.X = x;
            this.Y = y;
            this.MapLayer = mapLayer;
            this._properties = properties;
        }

        public EntityType Type { get; }

        public MapLayer MapLayer { get; }

        public int X { get; protected set; }

        public int Y { get; protected set; }

        public bool Has(EntityProperty property)
        {
            return this._properties.Contains(property);
        }
    }
}
