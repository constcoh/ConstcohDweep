using System.Drawing;
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
            IGameState gameState,            
            IMap map,
            IToolset toolset,
            IDrawMapProcessor drawMapProcessor,
            IDrawToolsetProcessor drawToolsetProcessor,
            ITaskProcessor taskProcessor,
            IDrawSettings drawSettings,
            IEntityFactory entityFactory)
        {
            this._state = gameState;
            this._map = map;
            this._toolset = toolset;

            this._drawMapProcessor = drawMapProcessor;
            this._drawToolsetProcessor = drawToolsetProcessor;
            this._taskProcessor = taskProcessor;

            var level = new Level1(entityFactory);
            level.FillMap(_map);
            level.FillToolset(_toolset);

            this.MapLeftButtonMouseController = new MapLeftButtonMouseController(
                drawSettings,
                this._map,
                this._taskProcessor,
                this._toolset);

            this.MapRightButtonMouseController = new MapRightButtonMouseController(
                this._toolset);

            this.ToolsLeftButtonMouseController = new ToolsLeftButtonMouseController(
                drawSettings,
                this._toolset);

            this._gameProcessorsBasket = new GameProcessorsBasket(
                this._state,
                this._map,
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
