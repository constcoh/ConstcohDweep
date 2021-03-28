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
                  EntityProperty.PointIsBusy)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            this._map = map;
            this._taskProcessor = taskProcessor;
            
            this.GlowDirection = glowDirection;
            this.State = LazerState.Works;
        }

        public LazerDirection GlowDirection { get; }

        public LazerState State { get; private set; }

        public IncomingLazerRayEntity CreateProducedRay()
        {
            var outgoingLazerRay = new OutgoingLazerRayEntity(
                this.X,
                this.Y,
                this.GlowDirection);

            return outgoingLazerRay.CreateProducedRay();
        }

        public override void Lazer()
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
