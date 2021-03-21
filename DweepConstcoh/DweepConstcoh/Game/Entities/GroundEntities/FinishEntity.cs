using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.GroundEntities
{
    public class FinishEntity : BaseEntity
    {
        public FinishEntity(int x, int y)
            : base(
                  EntityType.Finish,
                  x,
                  y,
                  MapLayer.Ground)
        {
        }
    }
}
