using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using MoreLinq;

namespace DweepConstcoh.Game.MapStructure
{
    public class Map : IMap
    {
        private readonly MapPoint[,] _points; 
        
        public Map()
        {
            _points = new MapPoint[this.Width, this.Height];

            for (int x = 0; x < this.Width; ++x)
                for (int y = 0; y < this.Height; ++y)
                {
                    _points[x, y] = new MapPoint(x, y);
                }
        }

        public int Width => 18;
        public int Height => 12;

        public bool IsOnMap(int x, int y)
        {
            return x >= 0 && x < this.Width &&
                   y >= 0 && y < this.Height;
        }

        public MapPoint At(int x, int y)
        {
            Condition.Requires(x, nameof(x)).IsGreaterOrEqual(0).IsLessThan(this.Width);
            Condition.Requires(y, nameof(y)).IsGreaterOrEqual(0).IsLessThan(this.Height);

            return this._points[x, y];
        }

        public void AddEntity(IEntity entity)
        {
            this.At(entity.X, entity.Y).AddEntity(entity);
        }

        public IEnumerable<IEntity> ListEntities()
        {
            var entities = new List<IEntity>();

            for (int x = 0; x < this.Width; ++x)
                for (int y = 0; y < this.Height; ++y)
                {
                    entities.AddRange(_points[x, y].Entities);
                }

            return entities;
        }

        public IEnumerable<IEntity> ListEntitiesOf(EntityType type)
        {
            var entities = new List<IEntity>();

            for (int x = 0; x < this.Width; ++x)
                for (int y = 0; y < this.Height; ++y)
                {
                    var pointEntities = _points[x, y]
                        .Entities
                        .Where(entity => entity.Type == type);

                    entities.AddRange(pointEntities);
                }

            return entities;
        }

        public IEnumerable<IEntity> ListEntitiesWith(EntityProperty property)
        {
            var entities = new List<IEntity>();

            for (int x = 0; x < this.Width; ++x)
                for (int y = 0; y < this.Height; ++y)
                {
                    var pointEntities = _points[x, y]
                        .Entities
                        .Where(entity => entity.Has(property));

                    entities.AddRange(pointEntities);
                }

            return entities;
        }

        public void RemoveEntities(IEnumerable<IEntity> entities)
        {
            Condition.Requires(entities, nameof(entities)).IsNotNull();

            entities.ForEach(entity =>
            {
                var mapPoint = this.At(entity.X, entity.Y);
                mapPoint.RemoveEntity(entity);
            });
        }
    }
}
