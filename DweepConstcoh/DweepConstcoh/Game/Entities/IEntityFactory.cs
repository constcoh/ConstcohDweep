using DweepConstcoh.Game.Entities.LazerEntities;

namespace DweepConstcoh.Game.Entities
{
    public interface IEntityFactory
    {
        IEntity Create(EntityType type, int x, int y);

        LazerEntity CreateLazer(int x, int y, LazerDirection glowDirection);
    }
}