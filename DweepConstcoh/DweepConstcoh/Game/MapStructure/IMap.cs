using System.Collections.Generic;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.MapStructure
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }
        
        MapPoint At(int x, int y);

        bool IsOnMap(int x, int y);

        void AddEntity(IEntity entity);

        IEnumerable<IEntity> ListEntities();

        IEnumerable<IEntity> ListEntitiesOf(EntityType type);

        IEnumerable<IEntity> ListEntitiesWith(EntityProperty property);

        void RemoveEntities(IEnumerable<IEntity> entities);

        void RemoveEntity(IEntity entity);
    }
}
