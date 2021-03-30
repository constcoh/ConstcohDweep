using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Processors.TaskProcess.Tasks;

namespace DweepConstcoh.Game.Entities
{
    public class PlayerEntity : BaseEntity
    {
        private readonly IGameState _gameState;

        private PlayerState _state;

        private readonly ITaskProcessor _taskProcessor;

        public PlayerEntity(
            int x,
            int y, 
            IGameState gameState,
            ITaskProcessor taskProcessor)
            : base(
                  EntityType.Player,
                  x,
                  y,
                  MapLayer.Player,
                  new[] {
                      EntityProperty.PointIsBusy,
                    EntityProperty.StopLazerRay
                  })
        {
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            this._state = PlayerState.Live;

            this._gameState = gameState;
            this._taskProcessor = taskProcessor;
        }

        public override void Bomb()
        {
            this.Kill();
        }

        public void GoTo(MapPoint point)
        {
            Condition.Requires(point, nameof(point)).IsNotNull();

            this.CheckWin(point);

            this.X = point.X;
            this.Y = point.Y;
        }

        public bool Is(PlayerState state) => _state == state;

        public override void Lazer()
        {
            this.Kill();
        }

        private void CheckWin(MapPoint newMapPoint)
        {
            if (this._state != PlayerState.Live)
            {
                return;
            }

            if (this.X == newMapPoint.X &&
                this.Y == newMapPoint.Y)
            {
                return;
            }

            var finishEntity = newMapPoint.Entities.FirstOrDefault(e => e.Type == EntityType.Finish);
            if (finishEntity == null)
            {
                return;
            }

            this._taskProcessor.RemoveAll(TaskType.PlayerMoving);
            this._taskProcessor.Add(
                new GameWinTask(this._gameState));
        }

        private void Kill()
        {
            if (this._state != PlayerState.Live)
            {
                return;
            }

            this._state = PlayerState.Died;
            this.MapLayer = MapLayer.OnGround;
            this.Remove(EntityProperty.StopLazerRay);
            this._taskProcessor.RemoveAll(TaskType.GameWin);
            this._taskProcessor.RemoveAll(TaskType.PlayerMoving);
            this._taskProcessor.Add(
                new GameOverTask(this._gameState));
        }
    }
}
