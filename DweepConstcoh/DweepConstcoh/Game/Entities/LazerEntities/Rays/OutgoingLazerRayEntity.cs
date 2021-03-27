using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.LazerEntities.Rays
{
    public class OutgoingLazerRayEntity : LazerRayEntity
    {
        public OutgoingLazerRayEntity(int x, int y, LazerDirection direction)
            : base(
                  x,
                  y,
                  direction)
        {
        }

        public IncomingLazerRayEntity CreateProducedRay()
        {
            (int x, int y) = this.GetProducedRayCoordinates();

            return new IncomingLazerRayEntity(
                x, 
                y,
                this.Direction.GetOppositeDirection());
        }

        private (int x, int y) GetProducedRayCoordinates()
        {
            int x = this.X;
            int y = this.Y;
            switch (this.Direction)
            {
                case LazerDirection.Right: x += 1; break;
                case LazerDirection.Top: y -= 1; break;
                case LazerDirection.Left: x -= 1; break;
                case LazerDirection.Down:  y += 1; break;
            }

            return (x, y);
        }
    }
}
