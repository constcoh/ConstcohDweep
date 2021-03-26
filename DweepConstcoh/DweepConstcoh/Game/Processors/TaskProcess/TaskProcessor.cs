using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;

namespace DweepConstcoh.Game.Processors.TaskProcess
{
    public class TaskProcessor : ITaskProcessor
    {
        private List<ITask> _tasks;

        public TaskProcessor()
        {
            this._tasks = new List<ITask>();
        }

        public void Add(ITask task)
        {
            Condition.Requires(task, nameof(task)).IsNotNull();
            this._tasks.Add(task);
        }

        public void RemoveAll(TaskType type)
        {
            this._tasks.RemoveAll(task => task.Type == type);
        }

        public void Process(int passedIntervalInMilliseconds)
        {
            this.ReduceDelay(passedIntervalInMilliseconds);
            this.ProcessTasks();
        }

        private List<ITask> ListTasksToProcess()
        {
            var tasksToProcess = this._tasks
                .Where(task => task.CanBeProcessed())
                .ToList();

            this._tasks = this._tasks
                .Where(task => task.CanBeProcessed() == false)
                .ToList();

            return tasksToProcess;
        }

        private void ProcessTasks()
        {
            var tasksToProcess = this.ListTasksToProcess();

            while (tasksToProcess.Count > 0)
            {
                var newTasks = new List<ITask>();

                tasksToProcess.ForEach(task =>
                {
                    var response = task.Process();
                    newTasks.AddRange(response.NewTasks);
                });

                this._tasks.AddRange(newTasks);

                tasksToProcess = this.ListTasksToProcess();
            }
        }

        private void ReduceDelay(int passedIntervalInMilliseconds)
        {
            this._tasks.ForEach(task => task.ReduceDelay(passedIntervalInMilliseconds));
        }
    }
}
