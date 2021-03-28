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

            map.AddEntity(_entityFactory.CreateLazer(3, 1, LazerDirection.Down));
            map.AddEntity(_entityFactory.CreateLazer(4, 10, LazerDirection.Top));
            map.AddEntity(_entityFactory.CreateLazer(8, 4, LazerDirection.Right));
            map.AddEntity(_entityFactory.CreateLazer(9, 7, LazerDirection.Down));
            map.AddEntity(_entityFactory.CreateLazer(16, 4, LazerDirection.Left));
            map.AddEntity(_entityFactory.CreateLazer(13, 8, LazerDirection.Right));
        }

        public void FillToolset(IToolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            toolset.Add(EntityType.MirrowMainDiagonal);
            toolset.Add(EntityType.MirrowMainDiagonal);
            toolset.Add(EntityType.MirrowMainDiagonal);
            toolset.Add(EntityType.MirrowSideDiagonal);
            toolset.Add(EntityType.MirrowSideDiagonal);
            toolset.Add(EntityType.MirrowSideDiagonal);
        }
    }
}
