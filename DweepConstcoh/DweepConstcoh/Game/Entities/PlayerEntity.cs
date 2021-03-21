using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Entities
{
    public class PlayerEntity : BaseEntity
    {
        private readonly PlayerState _state;

        public PlayerEntity(int x, int y)
            : base(
                  EntityType.Player,
                  x,
                  y,
                  MapLayer.PlayerBody)
        {
            this._state = PlayerState.Live;
        }

        public void GoTo(MapPoint point)
        {
            Condition.Requires(point, nameof(point)).IsNotNull();

            this.X = point.X;
            this.Y = point.Y;
        }

        public bool Is(PlayerState state) => _state == state;
    }
}
