namespace DweepConstcoh.Game.Entities
{
    public interface IEntityFactory
    {
        IEntity Create(EntityType type, int x, int y);

        ToolOnMapEntity CreateToolOnMapEntity(EntityType innerEntityType, int x, int y);
    }
}