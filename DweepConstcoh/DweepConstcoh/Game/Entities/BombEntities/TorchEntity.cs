using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.BombEntities
{
    public class TorchEntity : BaseEntity
    {
        public TorchEntity(int x, int y)
            : base(
                  EntityType.Torch,
                  x,
                  y,
                  MapLayer.PlayerBody)
        {
        }
    }
}
