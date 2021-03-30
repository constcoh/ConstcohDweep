using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.BombPainters
{
    public class FirePainter : IPainter
    {
        private readonly Brush _fireBrush;

        private readonly IDrawSettings _drawSettings;

        public FirePainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            this._drawSettings = drawSettings;

            var fireColor = Color.FromArgb(255, 255, 34, 34);
            this._fireBrush = new SolidBrush(fireColor);
        }

        public EntityType EntityType => EntityType.Fire;

        public void Draw(IEntity entity, Graphics gc)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            if (entity.Type != this.EntityType)
            {
                return;
            }

            var helper = new PointDrawingHelper(this._drawSettings, entity.X, entity.Y);

            var fireRectanleSize = new Size(
                (this._drawSettings.PointSize - 2) / 2,
                (this._drawSettings.PointSize - 2) / 2);

            var rectPositions = new[]
            {
                helper.GetCornerPointLeftTop(),
                helper.GetMiddlePointLeft(),
                helper.GetMiddlePointTop(),
                helper.GetCentrePoint()
            };

            rectPositions
                .ForEach(point => 
                    gc.FillEllipse(
                        this._fireBrush,
                        new Rectangle(point, fireRectanleSize)));
        }
    }
}
