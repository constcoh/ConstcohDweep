using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities.LazerEntities.Rays;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Processors.TaskProcess.Tasks;

namespace DweepConstcoh.Game.Entities.LazerEntities
{
    public class LazerEntity : BaseEntity
    {
        private readonly IMap _map;

        private readonly ITaskProcessor _taskProcessor;

        public LazerEntity(
            int x,
            int y, 
            LazerDirection glowDirection,
            IMap map,
            ITaskProcessor taskProcessor)
            : base(
                  EntityType.Lazer,
                  x,
                  y,
                  MapLayer.PlayerBody,
                  new[] {
                      EntityProperty.PointIsBusy,
                      EntityProperty.StopLazerRay
                  })
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            this._map = map;
            this._taskProcessor = taskProcessor;
            
            this.GlowDirection = glowDirection;
            this.State = LazerState.Works;
        }

        public LazerDirection GlowDirection { get; private set; }

        public LazerState State { get; private set; }

        public override bool ApplyTool(EntityType entityType)
        {
            switch (entityType)
            {
                case EntityType.RotateToLeft:
                    this.GlowDirection = this.GlowDirection.RotateToLeft();
                    return true;
                case EntityType.RotateToRight:
                    this.GlowDirection = this.GlowDirection.RotateToRight();
                    return true;
            }

            return false;
        }

        public IncomingLazerRayEntity CreateProducedRay()
        {
            var outgoingLazerRay = new OutgoingLazerRayEntity(
                this.X,
                this.Y,
                this.GlowDirection);

            return outgoingLazerRay.CreateProducedRay();
        }

        public override void Bomb()
        {
            this.Broke();
        }

        public override void Lazer()
        {
            this.Broke();
        }

        private void Broke()
        {
            if (this.State != LazerState.Works)
            {
                return;
            }

            this.State = LazerState.Sparks;
            this._taskProcessor.Add(
                new RemoveEntityFromMapTask(
                    this,
                    _map,
                    delayInMilliseconds: 1000));
        }
    }
}
