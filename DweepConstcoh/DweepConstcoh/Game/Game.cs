using System.Drawing;
using DweepConstcoh.Game.Controllers;
using DweepConstcoh.Game.Controllers.MapStructure;
using DweepConstcoh.Game.Controllers.Tools;
using DweepConstcoh.Game.Levels;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.DrawProcess;
using DweepConstcoh.Game.Processors.DrawProcess.Map;
using DweepConstcoh.Game.Processors.DrawProcess.Tools;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game
{
    public class Game
    {
        #region Game Objects

        private readonly Map _map;

        private readonly Toolset _toolset;

        #endregion Game Objects

        #region Processors

        private readonly DrawMapProcessor _drawProcessor;

        private readonly DrawToolsetProcessor _drawToolsetProcessor;

        private readonly TaskProcessor _taskProcessor;

        #endregion Processors

        public Game()
        {
            var level = new Level1();
            this._map = level.CreateMap();
            this._toolset = level.CreateToolset();

            this._drawProcessor = new DrawMapProcessor(this._map);
            this._drawToolsetProcessor = new DrawToolsetProcessor(this._toolset);
            this._taskProcessor = new TaskProcessor();

            this.MapLeftButtonMouseController = new MapLeftButtonMouseController(this._map, this._toolset);
            this.MapRightButtonMouseController = new MapRightButtonMouseController(this._toolset);
            this.ToolsLeftButtonMouseController = new ToolsLeftButtonMouseController(this._toolset);
        }

        public IMouseController MapLeftButtonMouseController { get; }

        public IMouseController MapRightButtonMouseController { get; }

        public IMouseController ToolsLeftButtonMouseController { get; }

        public void ProcessTasks(int passedIntervalInMilliseconds)
        {
            this._taskProcessor.Process(passedIntervalInMilliseconds);
        }

        public void Redraw(Graphics graphics, int gameTime)
        {
            this._drawProcessor.Draw(graphics, gameTime);
        }

        public void RedrawToolset(Graphics graphics, int gameTime)
        {
            this._drawToolsetProcessor.Draw(graphics, gameTime);
        }
    }
}
