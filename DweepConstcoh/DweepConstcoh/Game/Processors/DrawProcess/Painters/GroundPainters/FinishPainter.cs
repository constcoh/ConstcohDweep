using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.GroundPainters
{
    public class FinishPainter : IPainter
    {
        private readonly Brush _brush;

        private readonly IDrawSettings _drawSettings;

        public FinishPainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            var color = Color.FromArgb(255, 27, 174, 198);
            this._brush = new SolidBrush(color);
            this._drawSettings = drawSettings;
        }

        public EntityType EntityType => EntityType.Finish;

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
            gc.FillRectangle(this._brush, helper.GetPointRectangle());
        }
    }
}
