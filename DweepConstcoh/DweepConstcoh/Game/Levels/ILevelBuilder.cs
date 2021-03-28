using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public interface ILevelBuilder
    {
        void Build(LevelNumber levelNumber, IMap map, IToolset toolset);
    }
}