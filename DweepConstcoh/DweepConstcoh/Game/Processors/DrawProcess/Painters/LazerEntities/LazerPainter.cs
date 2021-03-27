using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.LazerEntities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.LazerEntities
{
    class LazerPainter : IPainter
    {
        private readonly Brush _blueBrush;

        private readonly IDrawSettings _drawSettings;

        private readonly Pen _redPen;

        public LazerPainter(IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            this._drawSettings = drawSettings;

            var blueColor = Color.FromArgb(255, 49, 52, 189);
            this._blueBrush = new SolidBrush(blueColor);

            var redColor = Color.FromArgb(255, 247, 32, 41);
            this._redPen = new Pen(redColor, 5);
        }

        public EntityType EntityType => EntityType.Lazer;

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

            var lazer = (LazerEntity)entity;


            var helper = new PointDrawingHelper(this._drawSettings, lazer.X, lazer.Y);
            this.DrawMainBlueCircle(gc, helper);
            this.DrawDirection(gc, helper, lazer);
        }

        private void DrawMainBlueCircle(
            Graphics gc,
            PointDrawingHelper drawingHelper)
        {
            var rectangle = drawingHelper.GetPointRectangle();
            gc.FillEllipse(this._blueBrush, rectangle);
        }

        private void DrawDirection(
            Graphics gc,
            PointDrawingHelper drawingHelper,
            LazerEntity lazer)
        {
            var rectangle = drawingHelper.GetPointRectangle();
            var point1 = drawingHelper.GetCentrePoint();
            var point2 = drawingHelper.GetLazerDirectionPoint(lazer.GlowDirection);
            gc.DrawLine(this._redPen, point1, point2);
        }
    }
}
