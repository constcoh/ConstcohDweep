using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public PlayerEntity(int x, int y)
            : base(
                  EntityType.Player,
                  x,
                  y,
                  MapLayer.PlayerBody)
        {
        }
    }
}
