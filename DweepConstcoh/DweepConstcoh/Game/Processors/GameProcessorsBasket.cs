using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.GameStatusProcess;
using DweepConstcoh.Game.Processors.LazerProcess;
using DweepConstcoh.Game.Tools;
using MoreLinq;

namespace DweepConstcoh.Game.Processors
{
    public class GameProcessorsBasket : IGameProcessorsBasket
    {
        private readonly IGameProcessor[] _gameProcessors;

        public GameProcessorsBasket(
            IGameState gameState,
            IMap map,
            IToolset toolset)
        {
            this._gameProcessors = new IGameProcessor[] {
                new LazerProcessor(
                    map),
                new GameStatusProcessor(
                    gameState,
                    map)
            };
        }

        public void Process()
        {
            _gameProcessors.ForEach(processor => processor.Process());
        }
    }
}
