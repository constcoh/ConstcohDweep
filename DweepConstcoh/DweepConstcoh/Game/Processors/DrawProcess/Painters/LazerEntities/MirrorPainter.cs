using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.LazerEntities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters.LazerEntities
{
    public class MirrorPainter : IPainter
    {
        private readonly Pen _bluePen;

        private readonly Pen _brownPen;

        private readonly IDrawSettings _drawSettings;


        public MirrorPainter(IDrawSettings drawSettings)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            this._drawSettings = drawSettings;

            var blueColor = Color.FromArgb(255, 198, 227, 225);
            this._bluePen = new Pen(blueColor, 3);

            var brownColor = Color.FromArgb(255, 148, 73, 8);
            this._brownPen = new Pen(brownColor, 5);
        }

        public EntityType EntityType => EntityType.Mirror;

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

            var mirror = (MirrorEntity)entity;


            var helper = new PointDrawingHelper(this._drawSettings, mirror.X, mirror.Y);
            this.DrawDirection(gc, helper, mirror);
        }

        private void DrawDirection(
            Graphics gc,
            PointDrawingHelper drawingHelper,
            MirrorEntity mirror)
        {
            var rectangle = drawingHelper.GetPointRectangle();

            var point1 = mirror.Position == MirrorPosition.MainDiagonal
                ? drawingHelper.GetCornerPointLeftTop()
                : drawingHelper.GetCornerPointRightTop();

            var point2 = mirror.Position == MirrorPosition.MainDiagonal
                ? drawingHelper.GetCornerPointRightDown()
                : drawingHelper.GetCornerPointLeftDown();

            gc.DrawLine(this._brownPen, point1, point2);
            gc.DrawLine(this._bluePen, point1, point2);
        }
    }
}
