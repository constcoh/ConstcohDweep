using System.Drawing;
using CuttingEdge.Conditions;

namespace DweepConstcoh.Game.Processors.DrawProcess
{
    public class PointDrawingHelper
    {
        private readonly IDrawSettings _drawSettings;
        
        private readonly int _x;

        private readonly int _y;

        public PointDrawingHelper(IDrawSettings drawSettings, int x, int y)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();

            this._drawSettings = drawSettings;
            this._x = x;
            this._y = y;
        }

        public Point GetCornerPointLeftTop()
        {
            return new Point(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * _y + 1);
        }

        public Point GetCornerPointLeftDown()
        {
            return new Point(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * (_y + 1) - 2);
        }

        public Point GetCornerPointRightTop()
        {
            return new Point(
                _drawSettings.PointSize * (_x + 1) - 2,
                _drawSettings.PointSize * _y + 1);
        }

        public Point GetCornerPointRightDown()
        {
            return new Point(
                _drawSettings.PointSize * (_x + 1) - 2,
                _drawSettings.PointSize * (_y + 1) - 2);
        }

        public Point GetMiddlePointLeft()
        {
            return new Point(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * _y + _drawSettings.PointSize / 2);
        }

        public Point GetMiddlePointTop()
        {
            return new Point(
                _drawSettings.PointSize * _x + _drawSettings.PointSize / 2,
                _drawSettings.PointSize * _y + 1);
        }

        public Point GetMiddlePointRight()
        {
            return new Point(
                _drawSettings.PointSize * (_x + 1) - 2,
                _drawSettings.PointSize * _y + _drawSettings.PointSize / 2);
        }

        public Point GetMiddlePointDown()
        {
            return new Point(
                _drawSettings.PointSize * _x + _drawSettings.PointSize / 2,
                _drawSettings.PointSize * (_y + 1) - 2);
        }

        public Rectangle GetPointRectangle()
        {
            return new Rectangle(
                _drawSettings.PointSize * _x + 1,
                _drawSettings.PointSize * _y + 1,
                _drawSettings.PointSize - 2,
                _drawSettings.PointSize - 2);
        }
    }
}
