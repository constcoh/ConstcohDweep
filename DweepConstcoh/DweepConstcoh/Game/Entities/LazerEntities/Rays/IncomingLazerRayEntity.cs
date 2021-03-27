using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.LazerEntities.Rays
{
    public class IncomingLazerRayEntity : LazerRayEntity
    {
        public IncomingLazerRayEntity(int x, int y, LazerDirection direction)
            : base(
                  x,
                  y,
                  direction)
        {
        }
        
        public OutgoingLazerRayEntity CreateProducedRay()
        {
            return new OutgoingLazerRayEntity(
                this.X,
                this.Y,
                this.Direction.GetOppositeDirection());
        }
    }
}
