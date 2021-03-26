using System.Linq;
using System.Windows.Forms;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Processors.GameStatusProcess
{
    public class GameStatusProcessor : IGameProcessor
    {
        private readonly IGameState _gameState;

        private readonly IMap _map;

        private readonly PlayerEntity _player;

        public GameStatusProcessor(
            IGameState gameState,
            IMap map)
        {
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();

            _gameState = gameState;
            _player = (PlayerEntity)map.ListEntitiesOf(EntityType.Player).First();
            _map = map;
        }

        public void Process()
        {
            this.CheckWin();
        }

        public void CheckWin()
        {
            if(_gameState.Status == GameStatus.Win)
            {
                return;
            }

            var isLearnerOnFinish = _map.At(_player.X, _player.Y).Has(EntityType.Finish);
            if (_player.Is(PlayerState.Live) &&
                isLearnerOnFinish)
            {
                this._gameState.Status = GameStatus.Win;
                var result = MessageBox.Show("Win!");
                if(result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
    }
}
