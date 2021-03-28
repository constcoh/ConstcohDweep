using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Controllers;
using DweepConstcoh.Game.Controllers.MapStructure;
using DweepConstcoh.Game.Controllers.Tools;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.Levels;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors;
using DweepConstcoh.Game.Processors.DrawProcess;
using DweepConstcoh.Game.Processors.DrawProcess.Map;
using DweepConstcoh.Game.Processors.DrawProcess.Tools;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game
{
    public class Game : IGame
    {
        #region Game Objects
        
        private readonly IMap _map;

        public readonly IGameState _state;

        private readonly IToolset _toolset;

        #endregion Game Objects

        #region Processors

        private readonly IDrawMapProcessor _drawMapProcessor;

        private readonly IDrawToolsetProcessor _drawToolsetProcessor;

        private readonly IGameProcessorsBasket _gameProcessorsBasket;

        private readonly ITaskProcessor _taskProcessor;

        #endregion Processors
        
        public Game(
            // Game objects:
            IGameState gameState,            
            IMap map,
            IToolset toolset,
            // Processors:
            IDrawMapProcessor drawMapProcessor,
            IDrawToolsetProcessor drawToolsetProcessor,
            ITaskProcessor taskProcessor,
            // Settings:
            IDrawSettings drawSettings,
            IEntityFactory entityFactory,
            
            ILevelBuilder levelBuilder)
        {
            #region Arguments Validation

            Condition.Requires(gameState, nameof(gameState)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            Condition.Requires(drawMapProcessor, nameof(drawMapProcessor)).IsNotNull();
            Condition.Requires(drawToolsetProcessor, nameof(drawToolsetProcessor)).IsNotNull();
            Condition.Requires(taskProcessor, nameof(taskProcessor)).IsNotNull();

            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            Condition.Requires(entityFactory, nameof(entityFactory)).IsNotNull();

            Condition.Requires(levelBuilder, nameof(levelBuilder)).IsNotNull();

            #endregion Arguments Validation

            this._state = gameState;
            this._map = map;
            this._toolset = toolset;

            this._drawMapProcessor = drawMapProcessor;
            this._drawToolsetProcessor = drawToolsetProcessor;
            this._taskProcessor = taskProcessor;

            levelBuilder.Build(LevelNumber.Level2, _map, _toolset);

            this._gameProcessorsBasket = new GameProcessorsBasket(
                this._state,
                this._map,
                this._toolset);

            this.MapLeftButtonMouseController = new MapLeftButtonMouseController(
                drawSettings,
                entityFactory,
                this._map,
                this._taskProcessor,
                this._toolset);

            this.MapRightButtonMouseController = new MapRightButtonMouseController(
                this._toolset);

            this.ToolsLeftButtonMouseController = new ToolsLeftButtonMouseController(
                drawSettings,
                this._toolset);

        }

        public IMouseController MapLeftButtonMouseController { get; }

        public IMouseController MapRightButtonMouseController { get; }

        public IMouseController ToolsLeftButtonMouseController { get; }

        public void ProcessGame(int passedIntervalInMilliseconds)
        {
            this._state.AddInterval(passedIntervalInMilliseconds);
            this._gameProcessorsBasket.Process();
            this._taskProcessor.Process(passedIntervalInMilliseconds);
        }

        public void Redraw(Graphics graphics)
        {
            this._drawMapProcessor.Draw(graphics);
        }

        public void RedrawToolset(Graphics graphics)
        {
            this._drawToolsetProcessor.Draw(graphics);
        }
    }
}
