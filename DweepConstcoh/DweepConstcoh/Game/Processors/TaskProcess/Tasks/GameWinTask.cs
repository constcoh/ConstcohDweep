using System.Windows.Forms;
using CuttingEdge.Conditions;

namespace DweepConstcoh.Game.Processors.TaskProcess.Tasks
{
    public class GameWinTask : BaseTask
    {
        private IGameState _gameState;

        public GameWinTask(
            IGameState gameState)
            : base(
                  delayInMilliseconds: 200,
                  type: TaskType.GameWin)
        {
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();

            this._gameState = gameState;
        }

        public override TaskProcessResponse Process()
        {
            if  (this._gameState.Status != GameStatus.InProgress)
            {
                return new TaskProcessResponse();
            }

            this._gameState.Status = GameStatus.Win;
            var result = MessageBox.Show("Game Win!");
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }

            return new TaskProcessResponse();
        }
    }
}
