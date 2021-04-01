using System;
using System.Collections.Generic;

namespace DweepConstcoh.Game.Entities.LazerEntities
{
    public static class LazerDirectionExtensions
    {
        private static IDictionary<LazerDirection, LazerDirection> OppositeDirection =
            new Dictionary<LazerDirection, LazerDirection>()
            {
                { LazerDirection.Down, LazerDirection.Top },
                { LazerDirection.Top, LazerDirection.Down },
                { LazerDirection.Left, LazerDirection.Right },
                { LazerDirection.Right, LazerDirection.Left }
            };

        public static LazerDirection GetOppositeDirection(
            this LazerDirection direction)
        {
            return LazerDirectionExtensions.OppositeDirection[direction];
        }

        public static LazerDirection RotateToLeft(
            this LazerDirection direction)
        {
            switch (direction)
            {
                case LazerDirection.Top: return LazerDirection.Left;
                case LazerDirection.Left: return LazerDirection.Down;
                case LazerDirection.Down: return LazerDirection.Right;
                case LazerDirection.Right: return LazerDirection.Top;
            }

            throw new Exception("unknown lazer direction");
        }

        public static LazerDirection RotateToRight(
            this LazerDirection direction)
        {
            switch (direction)
            {
                case LazerDirection.Top: return LazerDirection.Right;
                case LazerDirection.Right: return LazerDirection.Down;
                case LazerDirection.Down: return LazerDirection.Left;
                case LazerDirection.Left: return LazerDirection.Top;
            }

            throw new Exception("unknown lazer direction");
        }
    }
}
