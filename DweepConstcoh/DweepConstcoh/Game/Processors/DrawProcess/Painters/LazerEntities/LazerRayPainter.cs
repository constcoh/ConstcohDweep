using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.LazerEntities.Rays;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.LazerEntities
{
    public class LazerRayPainter : IPainter
    {
        private readonly IDrawSettings _drawSettings;

        private readonly Pen _greenPen;

        public LazerRayPainter(IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            this._drawSettings = drawSettings;

            var greenColor = Color.FromArgb(255, 115, 178, 49);
            this._greenPen = new Pen(greenColor, 5);
        }

        public EntityType EntityType => EntityType.LazerRay;

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

            var lazerRay = (LazerRayEntity)entity;


            var helper = new PointDrawingHelper(this._drawSettings, lazerRay.X, lazerRay.Y);
            this.DrawDirection(gc, helper, lazerRay);
        }

        private void DrawDirection(
            Graphics gc,
            PointDrawingHelper drawingHelper,
            LazerRayEntity lazerRay)
        {
            var rectangle = drawingHelper.GetPointRectangle();
            var point1 = drawingHelper.GetCentrePoint();
            var point2 = drawingHelper.GetLazerDirectionPoint(lazerRay.Direction);
            gc.DrawLine(this._greenPen, point1, point2);
        }
    }
}
