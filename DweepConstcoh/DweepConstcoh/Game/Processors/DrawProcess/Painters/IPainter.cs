using System.Drawing;
using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Processors.DrawProcess.Painters
{
    public interface IPainter
    {
        EntityType EntityType { get; }

        void Draw(
            IEntity entity,
            Graphics gc);
    }
}
