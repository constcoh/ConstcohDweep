using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh.Game.Controllers.MapStructure
{
    public class MapLeftButtonMouseController : IMouseController
    {
        private readonly IMap _map;

        private readonly Toolset _toolset;

        public MapLeftButtonMouseController(
            IMap map,
            Toolset toolset)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(toolset, nameof(toolset)).IsNotNull();

            this._map = map;
            this._toolset = toolset;
        }

        public void Click(int pixel_x, int pixel_y)
        {
            this._toolset.RemoveSelected();
        }
    }
}
