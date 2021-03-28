using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters
{
    public class PlayerPainter : IPainter
    {
        private readonly Brush _blackBrush;

        private readonly Brush _blueBrush;

        private readonly IDrawSettings _drawSettings;

        private readonly IGameState _gameState;

        public PlayerPainter(
            IDrawSettings drawSettings,
            IGameState gameState)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();

            var blackColor = Color.FromArgb(255, 0, 0, 0);
            this._blackBrush = new SolidBrush(blackColor);

            var blueColor = Color.FromArgb(255, 148, 73, 140);
            this._blueBrush = new SolidBrush(blueColor);
            this._drawSettings = drawSettings;
            this._gameState = gameState;
        }

        public EntityType EntityType => EntityType.Player;

        public void Draw(
            IEntity entity,
            Graphics gc)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            if (entity.Type != this.EntityType)
            {
                return;
            }

            var helper = new PointDrawingHelper(this._drawSettings, entity.X, entity.Y);
            var rectangle = helper.GetPointRectangle();

            var player = (PlayerEntity)entity;
            if (player.Is(PlayerState.Died))
            {
                gc.FillEllipse(this._blackBrush, rectangle);
                return;
            }

            var shift = this.GetJumpPhaseShift();
            rectangle.Offset(new Point(0, -shift));

            gc.FillEllipse(this._blueBrush, rectangle);
        }

        private int GetJumpPhaseShift()
        {
            const int jumpPeriodInMilliseconds = 500;

            int maxJumpShift = this._drawSettings.PointSize / 3;

            int phase = this._gameState.Time % jumpPeriodInMilliseconds;

            if(phase > jumpPeriodInMilliseconds /2)
            {
                phase = jumpPeriodInMilliseconds - phase;
            }

            return phase * maxJumpShift / (jumpPeriodInMilliseconds / 2);
        }
    }
}
