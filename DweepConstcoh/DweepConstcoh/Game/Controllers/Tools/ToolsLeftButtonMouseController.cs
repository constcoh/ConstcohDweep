using CuttingEdge.Conditions;
using DweepConstcoh.Game.Processors.DrawProcess;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Controllers.Tools
{
    public class ToolsLeftButtonMouseController : IMouseController
    {
        private DrawSettings _drawSettings;

        private Toolset _toolset;

        public ToolsLeftButtonMouseController(
            Toolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            this._toolset = toolset;
            this._drawSettings = new DrawSettings();
        }

        public void Click(int pixel_x, int pixel_y)
        {
            int x = pixel_x / this._drawSettings.PointSize;
            this._toolset.Select(x);
        }
    }
}
