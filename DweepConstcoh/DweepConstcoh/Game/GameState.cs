namespace DweepConstcoh.Game
{
    public class GameState : IGameState
    {
        public GameState()
        {
            this.Status = GameStatus.InProgress;
            this.Time = 0;
        }

        public GameStatus Status { get; set; }
        public int Time { get; private set; }

        public void AddInterval(int invervalInMilliseconds)
        {
            this.Time += invervalInMilliseconds;
        }
    }
}
