using CuttingEdge.Conditions;
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

        public void GoTo(MapPoint point)
        {
            Condition.Requires(point, nameof(point)).IsNotNull();

            this.X = point.X;
            this.Y = point.Y;
        }
    }
}
