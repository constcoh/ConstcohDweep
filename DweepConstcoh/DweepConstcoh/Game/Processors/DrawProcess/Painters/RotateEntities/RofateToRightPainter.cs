using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.RotateEntities
{
    public class RofateToRightPainter : IPainter
    {
        private readonly IDrawSettings _drawSettings;

        private readonly Pen _pen;

        public RofateToRightPainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            var color = Color.FromArgb(255, 148, 73, 140);
            var brush = new SolidBrush(color);
            this._pen = new Pen(brush, 3);
            this._drawSettings = drawSettings;
        }


        public EntityType EntityType => EntityType.RotateToRight;

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
            gc.DrawArc(
                _pen,
                helper.GetPointRectangle(0.2),
                0,
                360);

            var points = new[]
            {
                helper.GetPoint(0.35,0.2),
                helper.GetPoint(0.75,0.3),
                helper.GetPoint(0.5,0.5)
            };

            gc.DrawLines(
                _pen,
                points);
        }
    }
}
