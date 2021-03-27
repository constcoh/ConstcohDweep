using System.Collections.Generic;

namespace DweepConstcoh.Game.Entities.LazerEntities
{
    public static class MirrorPositionExtensions
    {
        private static Dictionary<MirrorPosition, Dictionary<LazerDirection, LazerDirection>> ReflectedRay =
            new Dictionary<MirrorPosition, Dictionary<LazerDirection, LazerDirection>>()
            {
                {
                    MirrorPosition.MainDiagonal,
                    new Dictionary<LazerDirection, LazerDirection>()
                    {
                        { LazerDirection.Down, LazerDirection.Left },
                        { LazerDirection.Left, LazerDirection.Down },
                        { LazerDirection.Top, LazerDirection.Right },
                        { LazerDirection.Right, LazerDirection.Top }
                    }
                },
                {
                    MirrorPosition.SideDiagonal,
                    new Dictionary<LazerDirection, LazerDirection>()
                      {
                          { LazerDirection.Top, LazerDirection.Left },
                          { LazerDirection.Left, LazerDirection.Top },
                          { LazerDirection.Right, LazerDirection.Down },
                          { LazerDirection.Down, LazerDirection.Right },
                      }
                }
            };

        public static LazerDirection GetReflectedRay(
            this MirrorPosition position,
            LazerDirection incomingRay)
        {
            return ReflectedRay[position][incomingRay];
        }
    }
}
