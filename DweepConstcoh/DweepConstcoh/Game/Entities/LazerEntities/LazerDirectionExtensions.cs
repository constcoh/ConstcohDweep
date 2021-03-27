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
    }
}
