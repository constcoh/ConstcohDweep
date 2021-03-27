using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.LazerEntities.Rays
{
    public class LazerRayEntity : BaseEntity
    {
        public LazerRayEntity(int x, int y, LazerDirection direction)
            : base(
                  EntityType.LazerRay,
                  x,
                  y,
                  MapLayer.PlayerBody)
        {
            this.Direction = direction;
        }

        public LazerDirection Direction { get; }
    }
}
