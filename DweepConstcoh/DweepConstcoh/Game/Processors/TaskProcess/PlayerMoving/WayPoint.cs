using System.Collections.Generic;

namespace DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving
{
    public class WayPoint
    {
        public WayPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(WayPoint point)
        {
            return this.X == point?.X &&
                   this.Y == point?.Y;
        }

        public IEnumerable<WayPoint> ListDiagonalNeighbors()
        {
            return new[]
            {
                new WayPoint(this.X - 1, this.Y - 1),
                new WayPoint(this.X - 1, this.Y + 1),
                new WayPoint(this.X + 1, this.Y + 1),
                new WayPoint(this.X + 1, this.Y - 1),
            };
        }

        public IEnumerable<WayPoint> ListHorizontalAndVerticalNeighbors()
        {
            return new[]
            {
                new WayPoint(this.X - 1, this.Y    ),
                new WayPoint(this.X    , this.Y + 1),
                new WayPoint(this.X + 1, this.Y    ),
                new WayPoint(this.X    , this.Y - 1)
            };
        }
    }
}
