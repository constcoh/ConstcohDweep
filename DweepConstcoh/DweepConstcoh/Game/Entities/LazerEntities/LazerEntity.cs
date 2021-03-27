using DweepConstcoh.Game.Entities.LazerEntities.Rays;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.LazerEntities
{
    public class LazerEntity : BaseEntity
    {
        public LazerEntity(int x, int y, LazerDirection glowDirection)
            : base(
                  EntityType.Lazer,
                  x,
                  y,
                  MapLayer.PlayerBody,
                  EntityProperty.PointIsBusy)
        {
            this.GlowDirection = glowDirection;
        }

        public LazerDirection GlowDirection { get; }

        public IncomingLazerRayEntity CreateProducedRay()
        {
            var outgoingLazerRay = new OutgoingLazerRayEntity(
                this.X,
                this.Y,
                this.GlowDirection);

            return outgoingLazerRay.CreateProducedRay();
        }
    }
}
