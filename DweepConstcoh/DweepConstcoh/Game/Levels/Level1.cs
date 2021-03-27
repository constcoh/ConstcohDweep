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

        public Level1()
        {
            this._entityFactory = new EntityFactory();
        }

        public IMap CreateMap()
        {
            var map = new Map();

            for (int x = 0; x < map.Width; ++x)
                for (int y = 0; y < map.Height; ++y)
                {
                    EntityType type = (EntityType)this._ground[y, x];

                    map.AddEntity(_entityFactory.Create(type, x, y));
                }

            map.AddEntity(_entityFactory.Create(EntityType.Player, 1, 3));

            map.AddEntity(new LazerEntity(3, 1, LazerDirection.Down));
            map.AddEntity(new LazerEntity(4, 10, LazerDirection.Top));
            map.AddEntity(new LazerEntity(8, 4, LazerDirection.Right));
            map.AddEntity(new LazerEntity(9, 7, LazerDirection.Down));
            map.AddEntity(new LazerEntity(16, 4, LazerDirection.Left));
            map.AddEntity(new LazerEntity(13, 8, LazerDirection.Right));
            
            return map;
        }

        public IToolset CreateToolset()
        {
            var toolset = new Toolset();
            toolset.Add(EntityType.MirrowMainDiagonal);
            toolset.Add(EntityType.MirrowMainDiagonal);
            toolset.Add(EntityType.MirrowMainDiagonal);
            toolset.Add(EntityType.MirrowSideDiagonal);
            toolset.Add(EntityType.MirrowSideDiagonal);
            toolset.Add(EntityType.MirrowSideDiagonal);

            return toolset;
        }
    }
}
