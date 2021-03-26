using CuttingEdge.Conditions;
using DweepConstcoh.Game.Processors.DrawProcess;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Controllers.Tools
{
    public class ToolsLeftButtonMouseController : IMouseController
    {
        private readonly IDrawSettings _drawSettings;

        private readonly IToolset _toolset;

        public ToolsLeftButtonMouseController(
            IDrawSettings drawSettings,
            IToolset toolset)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            this._toolset = toolset;
            this._drawSettings = drawSettings;
        }

        public void Click(int pixel_x, int pixel_y)
        {
            int x = pixel_x / this._drawSettings.PointSize;
            this._toolset.Select(x);
        }
    }
}
