using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public class Level1
    {
        private readonly int[,] _ground = new int[12, 18]
        {
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 1, 2 },
            { 2, 1, 1, 1, 1, 2, 1, 2, 1, 2, 2, 2, 2, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 2, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 2, 1, 2, 1, 1, 1, 1, 2, 2, 1, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 2, 1, 2, 1, 1, 1, 2, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 2 },
            { 2, 1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 2, 2, 2, 2, 1, 2 },
            { 2, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 1, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
        };

        private readonly IEntityFactory _entityFactory;

        public Level1(IEntityFactory entityFactory)
        {
            Condition.Requires(entityFactory, nameof(entityFactory)).IsNotNull();

            this._entityFactory = entityFactory;
        }

        public void FillMap(IMap map)
        {
            for (int x = 0; x < map.Width; ++x)
                for (int y = 0; y < map.Height; ++y)
                {
                    EntityType type = (EntityType)this._ground[y, x];

                    map.At(x, y).AddEntity(_entityFactory.Create(type, x, y));
                }

            map.At(1, 3).AddEntity(_entityFactory.Create(EntityType.Player, 1, 3));
        }

        public void FillToolset(IToolset toolset)
        {
            toolset.Add(EntityType.Ground);
            toolset.Add(EntityType.Finish);
            toolset.Add(EntityType.Wall);
            toolset.Add(EntityType.Wall);
        }
    }
}
