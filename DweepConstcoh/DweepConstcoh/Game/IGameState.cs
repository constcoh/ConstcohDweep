namespace DweepConstcoh.Game
{
    public interface IGameState
    {
        GameStatus Status { get; set; }
        int Time { get; }

        void AddInterval(int invervalInMilliseconds);
    }
}