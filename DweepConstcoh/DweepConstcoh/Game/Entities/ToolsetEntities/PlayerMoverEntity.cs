using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.ToolsetEntities
{
    public class PlayerMoverEntity : BaseEntity
    {
        public PlayerMoverEntity(int x, int y)
            : base(
                  EntityType.PlayerMover,
                  x,
                  y,
                  MapLayer.Air)
        {
        }
    }
}
