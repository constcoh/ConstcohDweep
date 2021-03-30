using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.BombEntities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.BombPainters
{
    public class BombPainter : IPainter
    {
        private readonly Brush _activatedWickBrush;

        private readonly Brush _blackBrush;

        private readonly IDrawSettings _drawSettings;

        private readonly Brush _normalWickBrush;

        public BombPainter(
            IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            this._drawSettings = drawSettings;

            var blackcolor = Color.FromArgb(255, 57, 60, 57);
            this._blackBrush = new SolidBrush(blackcolor);

            var activatedWickColor = Color.FromArgb(255, 255, 34, 34);
            this._activatedWickBrush = new SolidBrush(activatedWickColor);
             
            var normalWickColor = Color.FromArgb(255, 198, 190, 189);
            this._normalWickBrush = new SolidBrush(normalWickColor);
        }

        public EntityType EntityType => EntityType.Bomb;

        public void Draw(IEntity entity, Graphics gc)
        {
            Condition.Requires(entity, nameof(entity)).IsNotNull();
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            if (entity.Type != this.EntityType)
            {
                return;
            }

            var bomb = (BombEntity)entity;
            var helper = new PointDrawingHelper(this._drawSettings, entity.X, entity.Y);
            this.DrawMainRectangle(gc, helper);
            this.DrawWickRectangle(bomb, gc, helper);
        }

        private void DrawMainRectangle(
            Graphics gc,
            PointDrawingHelper helper)
        {
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();

            var mainRectangle = helper.GetPointRectangle();
            gc.FillEllipse(this._blackBrush, mainRectangle);
        }

        private void DrawWickRectangle(
            BombEntity bomb,
            Graphics gc,
            PointDrawingHelper helper)
        {
            Condition.Requires(bomb, nameof(bomb)).IsNotNull();
            Condition.Requires(gc, nameof(gc)).IsNotNull();
            Condition.Requires(helper, nameof(helper)).IsNotNull();

            var wickRectangle = helper.GetPointRectangle(0.1);
            gc.FillEllipse(
                this.GetWickBruch(bomb), 
                wickRectangle);
        }

        private Brush GetWickBruch(BombEntity bomb)
        {
            Condition.Requires(bomb, nameof(bomb)).IsNotNull();

            switch(bomb.State)
            {
                case BombState.Normal:
                    return this._normalWickBrush;
                case BombState.Activated:
                default:
                    return this._activatedWickBrush;
            }
        }
    }
}
