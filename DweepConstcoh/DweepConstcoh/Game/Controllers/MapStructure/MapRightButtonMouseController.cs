using CuttingEdge.Conditions;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Controllers.MapStructure
{
    public class MapRightButtonMouseController : IMouseController
    {
        private readonly IToolset _toolset;

        public MapRightButtonMouseController(
            IToolset toolset)
        {
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            this._toolset = toolset;
        }

        public void Click(int pixel_x, int pixel_y)
        {
            this._toolset.FlushSelectedType();
        }
    }
}
