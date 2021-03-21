namespace DweepConstcoh.Game.Processors.TaskProcess
{
    public interface ITask
    {
        int DelayInMillisecons { get; }

        TaskType Type { get; }

        void ReduceDelay(int milliseconds);

        bool CanBeProcessed();

        TaskProcessResponse Process();
    }
}
