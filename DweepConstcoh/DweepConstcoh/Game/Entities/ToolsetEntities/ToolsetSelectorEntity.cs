using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.ToolsetEntities
{
    public class ToolsetSelectorEntity : BaseEntity
    {
        public ToolsetSelectorEntity(int x, int y)
            : base(
                  EntityType.ToolsetSelector,
                  x,
                  y,
                  MapLayer.ToolsetSelector)
        {
        }
    }
}
