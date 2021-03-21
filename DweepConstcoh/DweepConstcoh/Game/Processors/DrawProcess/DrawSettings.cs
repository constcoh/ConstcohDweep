using System.Drawing;

namespace DweepConstcoh.Game.Processors.DrawProcess
{
    public class DrawSettings : IDrawSettings
    {
        public Color BackgroundColor => Color.Black;
        public int PointSize => 40;

        public int GameTime { get; set; } = 0;
    }
}
