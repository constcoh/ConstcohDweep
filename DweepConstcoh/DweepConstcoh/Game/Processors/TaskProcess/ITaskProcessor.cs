namespace DweepConstcoh.Game.Processors.TaskProcess
{
    public interface ITaskProcessor
    {
        void Add(ITask task);
        void Process(int passedIntervalInMilliseconds);
        void RemoveAll(TaskType type);
    }
}