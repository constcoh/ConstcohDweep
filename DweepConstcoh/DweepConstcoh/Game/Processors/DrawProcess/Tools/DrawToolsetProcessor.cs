using System.Drawing;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Processors.DrawProcess.Map;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Processors.DrawProcess.Tools
{
    public class DrawToolsetProcessor
    {
        private readonly DrawMapProcessor _drawMapProcessor;

        private readonly Toolset _toolset;

        private readonly ToolsetMap _toolsetMap;

        public DrawToolsetProcessor(Toolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();
            this._toolset = toolset;

            this._toolsetMap = new ToolsetMap(this._toolset);
            this._drawMapProcessor = new DrawMapProcessor(this._toolsetMap);
        }

        public void Draw(Graphics graphics, int gameTime)
        {
            this._toolsetMap.RefreshEntities();
            this._drawMapProcessor.Draw(graphics, gameTime);
        }
    }
}
