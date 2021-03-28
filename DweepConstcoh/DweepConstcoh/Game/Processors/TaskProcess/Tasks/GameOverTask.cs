using System.Windows.Forms;
using CuttingEdge.Conditions;

namespace DweepConstcoh.Game.Processors.TaskProcess.Tasks
{
    public class GameOverTask : BaseTask
    {
        private IGameState _gameState;

        public GameOverTask(
            IGameState gameState)
            : base(
                  delayInMilliseconds: 1000,
                  type: TaskType.GameOver)
        {
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();

            this._gameState = gameState;
        }

        public override TaskProcessResponse Process()
        {
            if (this._gameState.Status != GameStatus.InProgress)
            {
                return new TaskProcessResponse();
            }

            this._gameState.Status = GameStatus.GameOver;
            var result = MessageBox.Show("Game Over!");
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            return new TaskProcessResponse();
        }
    }
}
