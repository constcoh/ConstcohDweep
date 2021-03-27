using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.DrawProcess;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Controllers.MapStructure
{
    public class MapLeftButtonMouseController : IMouseController
    {
        private readonly IDrawSettings _drawSettings;

        private readonly IEntityFactory _entityFactory;

        private readonly IMap _map;

        private readonly ITaskProcessor _taskProcessor;

        private readonly IToolset _toolset;

        public MapLeftButtonMouseController(
            IDrawSettings drawSettings,
            IEntityFactory entityFactory,
            IMap map,
            ITaskProcessor taskProcessor,
            IToolset toolset)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            Condition.Requires(entityFactory, nameof(entityFactory)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            this._drawSettings = drawSettings;
            this._entityFactory = entityFactory;
            this._map = map;
            this._taskProcessor = taskProcessor;
            this._toolset = toolset;
        }

        public void Click(int pixel_x, int pixel_y)
        {
            int x = pixel_x / this._drawSettings.PointSize;
            int y = pixel_y / this._drawSettings.PointSize;

            this.ClickOnPoint(x, y);
        }

        public void ClickOnPoint(int x, int y)
        {
            if (this._map.IsOnMap(x, y) == false)
            {
                return;
            }

            var point = this._map.At(x, y);
            if (this._toolset.SelectedType == EntityType.PlayerMover)
            {
                // go to point:
                this._taskProcessor.RemoveAll(TaskType.PlayerMoving);

                var task = new PlayerGoToTargetTask(_map, x, y);
                this._taskProcessor.Add(task);
                return;
            } 

            if (point.Has(EntityProperty.PointIsBusy))
            {
                // apply to point
                return;
            }

            // put new entity on free space:
            this.AddToolsetSelectedEntityToMap(point);
        }

        private void AddToolsetSelectedEntityToMap(MapPoint mapPoint)
        {
            var selectedEntityType = this._toolset.SelectedType;
            var newEntity = this._entityFactory.Create(
                selectedEntityType,
                mapPoint.X,
                mapPoint.Y);

            mapPoint.AddEntity(newEntity);
            this._toolset.RemoveSelected();
        }
    }
}
