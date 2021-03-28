using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.LazerEntities.Rays;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities.LazerEntities
{
    public class MirrorEntity : BaseEntity
    {
        private IMap _map;

        public MirrorEntity(
            int x,
            int y,
            IMap map,
            MirrorPosition position)
            : base(
                  EntityType.Mirror,
                  x,
                  y,
                  MapLayer.PlayerBody,
                  EntityProperty.PointIsBusy)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._map = map;
            this.Position = position;
        }

        public MirrorPosition Position { get; }

        public override void Bomb()
        {
            this._map.RemoveEntity(this);
        }

        public OutgoingLazerRayEntity GetReflectedRay(IncomingLazerRayEntity incomingRay)
        {
            Condition.Requires(incomingRay, nameof(incomingRay)).IsNotNull();
            Condition.Requires(incomingRay.X, nameof(incomingRay)).IsEqualTo(this.X);
            Condition.Requires(incomingRay.Y, nameof(incomingRay)).IsEqualTo(this.Y);

            return new OutgoingLazerRayEntity(
                this.X,
                this.Y,
                this.Position.GetReflectedRay(incomingRay.Direction));
        }
    }
}
