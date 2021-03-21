using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;

namespace DweepConstcoh.Game.Processors.TaskProcess
{
    public class TaskProcessResponse
    {
        public TaskProcessResponse()
            : this(Enumerable.Empty<ITask>())
        {
        }

        public TaskProcessResponse(IEnumerable<ITask> newTasks)
        {
            Condition.Requires(newTasks, nameof(newTasks)).IsNotNull();

            this.NewTasks = newTasks;
        }

        public IEnumerable<ITask> NewTasks { get; }
    }
}
