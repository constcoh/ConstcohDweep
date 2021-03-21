using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.GroundPainters
{
    public class WallPainter : IPainter
    {
        private readonly Brush _brush;

        private readonly IDrawSettings _drawSettings;

        private readonly Pen _pen;

        public WallPainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            var color = Color.FromArgb(255, 214, 117, 99);
            this._brush = new SolidBrush(color);
            this._drawSettings = drawSettings;
            this._pen = new Pen(Color.FromArgb(255, 132, 85, 74), 2);
        }

        public EntityType EntityType => EntityType.Wall;

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

            gc.DrawLine(
                this._pen,
                helper.GetCornerPointLeftTop(),
                helper.GetCornerPointRightDown());

            gc.DrawLine(
                this._pen,
                helper.GetCornerPointRightTop(),
                helper.GetCornerPointLeftDown());
        }
    }
}
