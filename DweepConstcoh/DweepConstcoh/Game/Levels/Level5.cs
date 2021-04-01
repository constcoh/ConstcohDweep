using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Entities.LazerEntities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Levels
{
    public class Level5 : ILevel
    {
        private readonly int[,] _ground = new int[12, 18]
        {
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 2, 2 },
            { 2, 2, 2, 1, 1, 2, 2, 1, 1, 1, 2, 2, 1, 1, 2, 1, 2, 2 },
            { 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 2, 2, 1, 2, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 2, 2 },
            { 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 2, 1, 2 },
            { 2, 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
        };

        private readonly IEntityFactory _entityFactory;

        public Level5(IEntityFactory entityFactory)
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

            map.AddEntity(_entityFactory.Create(EntityType.Player, 8, 5));

            map.AddEntity(_entityFactory.Create(EntityType.LazerRight, 1, 2));
            map.AddEntity(_entityFactory.Create(EntityType.LazerTop, 2, 10));

            map.AddEntity(_entityFactory.Create(EntityType.MirrorMainDiagonal, 4, 2));
            map.AddEntity(_entityFactory.Create(EntityType.MirrorMainDiagonal, 12, 10));

            map.AddEntity(_entityFactory.Create(EntityType.Bomb, 12, 4));
            map.AddEntity(_entityFactory.Create(EntityType.Bomb, 12, 5));
            map.AddEntity(_entityFactory.Create(EntityType.Bomb, 12, 6));
            map.AddEntity(_entityFactory.Create(EntityType.Bomb, 15, 4));
            map.AddEntity(_entityFactory.Create(EntityType.Bomb, 15, 10));
            map.AddEntity(_entityFactory.Create(EntityType.Bomb, 16, 7));

            map.AddEntity(_entityFactory.CreateToolOnMapEntity(EntityType.Torch, 1, 6));
            map.AddEntity(_entityFactory.CreateToolOnMapEntity(EntityType.RotateToLeft, 7, 7));
            map.AddEntity(_entityFactory.CreateToolOnMapEntity(EntityType.MirrorMainDiagonal, 8, 7));
            map.AddEntity(_entityFactory.CreateToolOnMapEntity(EntityType.Bomb, 9, 7));
            map.AddEntity(_entityFactory.CreateToolOnMapEntity(EntityType.Torch, 13, 5));
            map.AddEntity(_entityFactory.CreateToolOnMapEntity(EntityType.RotateToRight, 16, 10));
        }

        public void FillToolset(IToolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();
        }
    }
}
