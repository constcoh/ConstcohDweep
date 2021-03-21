using System.Collections.Generic;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.MapStructure
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }
        
        MapPoint At(int x, int y);

        IEnumerable<IEntity> ListEntities();
    }
}
