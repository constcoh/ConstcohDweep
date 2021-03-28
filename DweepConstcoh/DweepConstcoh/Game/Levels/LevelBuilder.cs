using System.Collections.Generic;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public class LevelBuilder : ILevelBuilder
    {
        private IDictionary<LevelNumber, ILevel> _levels;

        public LevelBuilder(
            IEntityFactory entityFactory)
        {
            Condition.Requires(entityFactory, nameof(entityFactory)).IsNotNull();

            _levels = new Dictionary<LevelNumber, ILevel>()
            {
                {
                    LevelNumber.Level1,
                    new Level1(entityFactory)
                }
            };
        }

        public void Build(
            LevelNumber levelNumber, 
            IMap map, 
            IToolset toolset)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            var level = _levels[levelNumber];
            level.FillMap(map);
            level.FillToolset(toolset);
        }
    }
}
