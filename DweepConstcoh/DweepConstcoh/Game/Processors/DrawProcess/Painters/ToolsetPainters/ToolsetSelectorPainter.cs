using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.ToolsetPainters
{
    public class ToolsetSelectorPainter : IPainter
    {
        private readonly IDrawSettings _drawSettings;

        private readonly Pen _pen;

        public ToolsetSelectorPainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            var color = Color.FromArgb(255, 214, 0, 24);
            var brush = new SolidBrush(color);
            this._pen = new Pen(brush, 4);
            this._drawSettings = drawSettings;
        }

        public EntityType EntityType => EntityType.ToolsetSelector;

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
            gc.DrawRectangle(
                _pen,
                helper.GetPointRectangle());
        }
    }
}
