using System.Collections.Generic;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

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

        public MapPoint At(int x, int y)
        {
            Condition.Requires(x, nameof(x)).IsGreaterOrEqual(0).IsLessThan(this.Width);
            Condition.Requires(y, nameof(y)).IsGreaterOrEqual(0).IsLessThan(this.Height);

            return this._points[x, y];
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
    }
}
