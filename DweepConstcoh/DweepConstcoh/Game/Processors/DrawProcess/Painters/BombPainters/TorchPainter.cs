using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.BombPainters
{
    public class TorchPainter : IPainter
    {
        private readonly Pen _firePen;

        private readonly Pen _stickPen;

        private readonly IDrawSettings _drawSettings;


        public TorchPainter(IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            this._drawSettings = drawSettings;

            var fireColor = Color.FromArgb(255, 255, 34, 34);
            this._firePen = new Pen(fireColor, 9);

            var stickColor = Color.FromArgb(255, 148, 73, 8);
            this._stickPen = new Pen(stickColor, 5);
        }

        public EntityType EntityType => EntityType.Torch;

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
            this.DrawStick(gc, helper);
            this.DrawFire(gc, helper);
        }

        private void DrawFire(
            Graphics gc,
            PointDrawingHelper helper)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();

            gc.DrawLine(this._firePen,
                helper.GetPoint(0.2, 0.2),
                helper.GetPoint(0.4, 0.4));
        }

        private void DrawStick(
            Graphics gc,
            PointDrawingHelper helper)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();

            gc.DrawLine(this._stickPen,
                helper.GetPoint(0.3, 0.3),
                helper.GetPoint(0.9, 0.9));
        }
    }
}
