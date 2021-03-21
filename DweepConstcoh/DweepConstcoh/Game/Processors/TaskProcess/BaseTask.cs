namespace DweepConstcoh.Game.Processors.TaskProcess
{
    public abstract class BaseTask : ITask
    {
        public BaseTask()
            : this(0, TaskType.Default)
        {
        }

        public BaseTask(TaskType type)
            : this(0, type)
        {
        }

        public BaseTask(int delayInMilliseconds)
            : this(delayInMilliseconds, TaskType.Default)
        {
        }

        public BaseTask(int delayInMilliseconds, TaskType type)
        {
            this.DelayInMillisecons = delayInMilliseconds;
            this.Type = type;
        }

        public int DelayInMillisecons { get; private set; }

        public TaskType Type { get; }

        public bool CanBeProcessed()
        {
            return this.DelayInMillisecons <= 0;
        }

        public void ReduceDelay(int milliseconds)
        {
            this.DelayInMillisecons -= milliseconds;
        }

        public abstract TaskProcessResponse Process();
    }
}
