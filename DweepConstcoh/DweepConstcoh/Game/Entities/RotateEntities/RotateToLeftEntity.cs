using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.RotateEntities
{
    public class RotateToLeftEntity : BaseEntity
    {
        public RotateToLeftEntity(int x, int y)
            : base(
                  EntityType.RotateToLeft,
                  x,
                  y,
                  MapLayer.OnGround)
        {
        }
    }
}
