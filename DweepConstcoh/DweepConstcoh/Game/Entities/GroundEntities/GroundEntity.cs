using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.GroundEntities
{
    class GroundEntity : BaseEntity
    {
        public GroundEntity(int x, int y)
            : base(
                  EntityType.Ground,
                  x,
                  y,
                  MapLayer.Ground)
        {
        }
    }
}
