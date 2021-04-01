using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.LazerEntities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public class Level1 : ILevel
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
            Condition.Requires(entityFactory, nameof(entityFactory));
            this._entityFactory = entityFactory;
        }

        public void FillMap(IMap map)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            for (int x = 0; x < map.Width; ++x)
                for (int y = 0; y < map.Height; ++y)
                {
                    EntityType type = (EntityType)this._ground[y, x];

                    map.AddEntity(_entityFactory.Create(type, x, y));
                }

            map.AddEntity(_entityFactory.Create(EntityType.Player, 1, 3));

            map.AddEntity(_entityFactory.Create(EntityType.LazerDown, 3, 1));
            map.AddEntity(_entityFactory.Create(EntityType.LazerTop, 4, 10));
            map.AddEntity(_entityFactory.Create(EntityType.LazerRight, 8, 4));
            map.AddEntity(_entityFactory.Create(EntityType.LazerDown, 9, 7));
            map.AddEntity(_entityFactory.Create(EntityType.LazerLeft, 16, 4));
            map.AddEntity(_entityFactory.Create(EntityType.LazerRight, 13, 8));
        }

        public void FillToolset(IToolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            toolset.Add(EntityType.MirrorMainDiagonal);
            toolset.Add(EntityType.MirrorMainDiagonal);
            toolset.Add(EntityType.MirrorMainDiagonal);
            toolset.Add(EntityType.MirrorSideDiagonal);
            toolset.Add(EntityType.MirrorSideDiagonal);
            toolset.Add(EntityType.MirrorSideDiagonal);
        }
    }
}
