using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.BombEntities.Tasks;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.TaskProcess;
using MoreLinq;

namespace DweepConstcoh.Game.Entities.BombEntities
{
    public class BombEntity : BaseEntity
    {
        private readonly IEntityFactory _entityFactory;

        private readonly IMap _map;

        private readonly ITaskProcessor _taskProcessor;

        public BombEntity(
            int x, 
            int y, 
            IEntityFactory entityFactory,
            IMap map, 
            ITaskProcessor taskProcessor)
            : base(
                  EntityType.Bomb,
                  x,
                  y,
                  MapLayer.PlayerBody,
                  EntityProperty.PointIsBusy)
        {
            Condition.Requires(entityFactory, nameof(entityFactory)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            this._entityFactory = entityFactory;
            this._map = map;
            this._taskProcessor = taskProcessor;
            this.State = BombState.Normal;
        }

        public BombState State { get; private set; }

        public virtual bool ApplyTool(EntityType entityType)
        {
            if (entityType == EntityType.Torch)
            {
                this.Activate();
                return true;
            }

            return false;
        }

        public override void Bomb()
        {
            this.Detonate();
        }

        public void Detonate()
        {
            if (this.State == BombState.Detonated)
            {
                return;
            }

            this.State = BombState.Detonated;
            this._map.RemoveEntity(this);

            var pointsToFire = this.ListPointsToFire();
            pointsToFire.ForEach(point =>
                point.AddEntity(
                    this._entityFactory.Create(
                        EntityType.Fire,
                        point.X,
                        point.Y)));
        }

        public override void Lazer()
        {
            this.Activate();
        }

        private void Activate()
        {
            if (this.State != BombState.Normal)
            {
                return;
            }

            this.State = BombState.Activated;
            this._taskProcessor.Add(new DetonateBombTask(this));
        }

        private IEnumerable<MapPoint> ListPointsToFire()
        {
            var pointsToFire = new[]
            {
                _map.At(this.X-1, this.Y-1),
                _map.At(this.X-1, this.Y),
                _map.At(this.X-1, this.Y+1),
                _map.At(this.X, this.Y-1),
                _map.At(this.X, this.Y),
                _map.At(this.X, this.Y+1),
                _map.At(this.X+1, this.Y-1),
                _map.At(this.X+1, this.Y),
                _map.At(this.X+1, this.Y+1)
            };

            return pointsToFire
                .Where(point => point != null)
                .Where(point => !point.Has(EntityType.Wall))
                .ToList();
        }
    }
}
