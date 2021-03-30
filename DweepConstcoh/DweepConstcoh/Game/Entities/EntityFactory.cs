using System;
using System.Collections.Generic;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.BombEntities;
using DweepConstcoh.Game.Entities.LazerEntities;
using DweepConstcoh.Game.Entities.ToolsetEntities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.TaskProcess;

namespace DweepConstcoh.Game.Entities
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IGameState _gameState;

        private readonly IMap _map;

        private readonly ITaskProcessor _taskProcessor;

        private readonly IDictionary<EntityType, Type> _types;

        public EntityFactory(
            IGameState gameState,
            IMap map,
            ITaskProcessor taskProcessor)
        {
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            this._gameState = gameState;
            this._map = map;
            this._taskProcessor = taskProcessor;

            this._types = new Dictionary<EntityType, Type>
            {
                { EntityType.Finish, typeof(GroundEntities.FinishEntity) },
                { EntityType.Ground, typeof(GroundEntities.GroundEntity) },
                { EntityType.Wall, typeof(GroundEntities.WallEntity) },
                
                { EntityType.PlayerMover, typeof(PlayerMoverEntity) },
                { EntityType.ToolsetSelector, typeof(ToolsetSelectorEntity) },

                { EntityType.Torch, typeof(TorchEntity) }
            };
        }

        public IEntity Create(EntityType type, int x, int y)
        {
            switch(type)
            {
                case EntityType.Bomb:
                    return this.CreateBomb(x, y);
                case EntityType.Fire:
                    return this.CreateFire(x, y);
                case EntityType.MirrowMainDiagonal:
                case EntityType.MirrowSideDiagonal:
                    return this.CreateMirror(type, x, y);
                case EntityType.Player:
                    return this.CreatePlayer(x, y);
            }

            if (this._types.ContainsKey(type) == false)
            {
                throw new Exception("unknown entity type " + type);
            }

            var typeClass = this._types[type];

            return (IEntity)Activator.CreateInstance(typeClass, x, y);
        }

        public LazerEntity CreateLazer(int x, int y, LazerDirection glowDirection)
        {
            return new LazerEntity(x, y, glowDirection, this._map, this._taskProcessor);
        }

        private BombEntity CreateBomb(int x, int y)
        {
            return new BombEntity(x, y, this, this._map, this._taskProcessor);
        }

        private FireEntity CreateFire(int x, int y)
        {
            return new FireEntity(x, y, this, this._map, this._taskProcessor);
        }

        private MirrorEntity CreateMirror(EntityType type, int x, int y)
        {
            if (type == EntityType.MirrowMainDiagonal)
            {
                return new MirrorEntity(x, y, this._map, MirrorPosition.MainDiagonal);
            }

            if (type == EntityType.MirrowSideDiagonal)
            {
                return new MirrorEntity(x, y, this._map, MirrorPosition.SideDiagonal);
            }

            throw new Exception("unknown entity type " + type);
        }


        private PlayerEntity CreatePlayer(int x, int y)
        {
            return new PlayerEntity(
                x, 
                y,
                this._gameState,
                this._taskProcessor);
        }
    }
}
