using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters
{
    public class PlayerPainter : IPainter
    {
        private readonly Brush _brush;

        private readonly IDrawSettings _drawSettings;

        public PlayerPainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            var color = Color.FromArgb(255, 148, 73, 140);
            this._brush = new SolidBrush(color);
            this._drawSettings = drawSettings;
        }

        public EntityType EntityType => EntityType.Player;

        public void Draw(
            IEntity entity,
            Graphics gc)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();
            if (entity.Type != this.EntityType)
            {
                return;
            }

            Condition.Requires(gc, nameof(gc)).IsNotNull();
            var helper = new PointDrawingHelper(this._drawSettings, entity.X, entity.Y);
            var rectangle = helper.GetPointRectangle();

            var shift = this.GetJumpPhaseShift();
            rectangle.Offset(new Point(0, -shift));

            gc.FillEllipse(this._brush, rectangle);
        }

        private int GetJumpPhaseShift()
        {
            const int jumpPeriodInMilliseconds = 500;

            int maxJumpShift = this._drawSettings.PointSize / 3;

            int phase = this._drawSettings.GameTime % jumpPeriodInMilliseconds;

            if(phase > jumpPeriodInMilliseconds /2)
            {
                phase = jumpPeriodInMilliseconds - phase;
            }

            return phase * maxJumpShift / (jumpPeriodInMilliseconds / 2);
        }
    }
}
