using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities
{
    public class ToolOnMapEntity : BaseEntity
    {
        public ToolOnMapEntity(
            int x,
            int y,
            EntityFactory entityFactory,
            EntityType toolEntityType)
            : base(
                  EntityType.ToolOnMap,
                  x,
                  y,
                  MapLayer.OnGround)
        {
            Condition.Requires(entityFactory, nameof(entityFactory)).IsNotNull();

            this.FullToolEntityType = toolEntityType;
            this.InnerEntity = entityFactory.Create(toolEntityType, x, y);
        }

        public EntityType FullToolEntityType { get; }

        public IEntity InnerEntity { get; }
    }
}
