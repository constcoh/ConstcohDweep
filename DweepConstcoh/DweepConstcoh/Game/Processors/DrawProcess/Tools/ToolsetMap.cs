using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.GroundEntities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.DrawProcess.Tools
{
    public class ToolsetMap : IMap
    {
        private readonly IEntityFactory _entityFactory;

        private readonly MapPoint[] _points;

        private readonly IToolset _toolset;

        public ToolsetMap(
            IToolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            this._toolset = toolset;
            _points = new MapPoint[this.Width];

            for (int x = 0; x < this.Width; ++x)
            {
                _points[x] = new MapPoint(x, 0);
            }

            this._entityFactory = new EntityFactory();
        }

        public int Width => 10;
        public int Height => 1;

        public bool IsOnMap(int x, int y)
        {
            return x >= 0 && x < this.Width &&
                   y >= 0 && y < this.Height;
        }

        public MapPoint At(int x, int y)
        {
            Condition.Requires(x, nameof(x)).IsGreaterOrEqual(0).IsLessThan(this.Width);
            Condition.Requires(y, nameof(y)).IsGreaterOrEqual(0).IsLessThan(this.Height);

            return this._points[x];
        }


        public void AddEntity(IEntity entity)
        {
            this.At(entity.X, entity.Y).AddEntity(entity);
        }

        public IEnumerable<IEntity> ListEntities()
        {
            return this._points
                .SelectMany(point => point.Entities)
                .ToList();
        }

        public IEnumerable<IEntity> ListEntitiesOf(EntityType type)
        {
            return this._points
                .SelectMany(point => point.Entities)
                .Where(entity => entity.Type == type)
                .ToList();
        }

        public IEnumerable<IEntity> ListEntitiesWith(EntityProperty property)
        {
            return this._points
                .SelectMany(point => point.Entities)
                .Where(entity => entity.Has(property))
                .ToList();
        }

        public void RefreshEntities()
        {
            this._points.ForEach((point, index) =>
            {
                point.ClearEntitires();
                point.AddEntity(new GroundEntity(index, 0));

                var toolsetItemType = this._toolset.Get(index);

                if (index == this._toolset.IndexOfSelectedItem)
                {
                    var entity = this._entityFactory.Create(EntityType.ToolsetSelector, index, 0);
                    point.AddEntity(entity);
                }

                if (toolsetItemType != EntityType.None)
                {
                    var entity = this._entityFactory.Create(toolsetItemType, index, 0);
                    point.AddEntity(entity);
                }
            });
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
