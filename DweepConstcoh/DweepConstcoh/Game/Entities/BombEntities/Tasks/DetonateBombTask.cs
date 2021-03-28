using CuttingEdge.Conditions;
using DweepConstcoh.Game.Processors.TaskProcess;

namespace DweepConstcoh.Game.Entities.BombEntities.Tasks
{
    public class DetonateBombTask : BaseTask
    {
        private BombEntity _bomb;

        public DetonateBombTask(BombEntity bomb)
            : base(
                  delayInMilliseconds: 2000,
                  type: TaskType.GameWin)
        {
            Condition.Requires(bomb, nameof(bomb)).IsNotNull();

            this._bomb = bomb;
        }

        public override TaskProcessResponse Process()
        {
            this._bomb.Detonate();

            return new TaskProcessResponse();
        }
    }
}
