using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.RotateEntities
{
    public class RotateToRightEntity : BaseEntity
    {
        public RotateToRightEntity(int x, int y)
            : base(
                  EntityType.RotateToRight,
                  x,
                  y,
                  MapLayer.OnGround)
        {
        }
    }
}
