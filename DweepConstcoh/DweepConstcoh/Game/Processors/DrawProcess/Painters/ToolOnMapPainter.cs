using System.Collections.Generic;
using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters
{
    public class ToolOnMapPainter : IPainter
    {
        private readonly Brush _backgroundBrush;

        private readonly IDrawSettings _drawSettings;

        private readonly Pen _outlinePen;

        private readonly IEnumerable<IPainter> _painters;

        public ToolOnMapPainter(
            IDrawSettings drawSettings,
            IEnumerable<IPainter> painters)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            Condition.Requires(painters, nameof(painters)).IsNotNull();
            this._drawSettings = drawSettings;
            this._painters = painters;

            var backgroundColor = Color.FromArgb(255, 24, 146, 222);
            this._backgroundBrush = new SolidBrush(backgroundColor);

            var greenColor = Color.FromArgb(255, 115, 178, 49);
            this._outlinePen = new Pen(greenColor, 2);
        }

        public EntityType EntityType => EntityType.ToolOnMap;


        public void Draw(
            IEntity entity,
            Graphics gc)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(entity, nameof(entity)).IsNotNull();
            if (entity.Type != this.EntityType)
            {
                return;
            }

            var toolOnMap = (ToolOnMapEntity)entity;

            var helper = new PointDrawingHelper(this._drawSettings, entity.X, entity.Y);

            this.DrawBackground(gc, helper);
            this.DrawInnerEntity(gc, helper, toolOnMap);
            this.DrawOutline(gc, helper);
        }

        private void DrawBackground(
            Graphics gc,
            PointDrawingHelper helper)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();

            gc.FillRectangle(
                _backgroundBrush,
                helper.GetPointRectangle());
        }

        private void DrawInnerEntity(
            Graphics gc,
            PointDrawingHelper helper,
            ToolOnMapEntity toolOnMap)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();
            Condition.Requires(toolOnMap, nameof(toolOnMap)).IsNotNull();

            this._painters
                    .ForEach(painter => painter.Draw(toolOnMap.InnerEntity, gc));
        }

        private void DrawOutline(
            Graphics gc,
            PointDrawingHelper helper)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();

            gc.DrawRectangle(
                _outlinePen,
                helper.GetPointRectangle(offsetFromSide: 1));
        }
    }
}
