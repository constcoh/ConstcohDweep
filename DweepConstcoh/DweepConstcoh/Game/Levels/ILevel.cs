using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public interface ILevel
    {
        IMap CreateMap();
        IToolset CreateToolset();
    }
}