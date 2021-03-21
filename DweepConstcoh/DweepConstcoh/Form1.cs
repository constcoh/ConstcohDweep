using System;
using System.Drawing;
using System.Windows.Forms;
using DweepConstcoh.Game.Levels;

namespace DweepConstcoh
{
    public partial class frmMain : Form
    {
        private Game.Game _game;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._game = new Game.Game();
        }
        private int _gameTime = 0;
        private void tmrGameProcesses_Tick(object sender, EventArgs e)
        {
            _game.ProcessTasks(this.tmrGameProcesses.Interval);

            _gameTime += this.tmrGameProcesses.Interval;
            using (var graphics = this.pnlGameSpace.CreateGraphics())
            {
                this._game.Redraw(graphics, _gameTime);
            }

            using (var graphics = this.pnlToolset.CreateGraphics())
            {
                this._game.RedrawToolset(graphics, _gameTime);
            }
        }

        private void pnlToolset_MouseDown(object sender, MouseEventArgs e)
        {
            this._game.ToolsLeftButtonMouseController.Click(e.X, e.Y);
        }

        private void pnlGameSpace_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    this._game.MapLeftButtonMouseController.Click(e.X, e.Y);
                    return;
                case MouseButtons.Right:
                    this._game.MapRightButtonMouseController.Click(e.X, e.Y);
                    return;
            }
        }
    }
}
