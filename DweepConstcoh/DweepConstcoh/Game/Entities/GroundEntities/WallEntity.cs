using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.GroundEntities
{
    class WallEntity : BaseEntity
    {
        public WallEntity(int x, int y)
            : base(
                  EntityType.Wall,
                  x,
                  y,
                  MapLayer.Ground,
                  new[] {
                      EntityProperty.PointIsBusy,
                      EntityProperty.StopLazerRay })
        {
        }
    }
}
