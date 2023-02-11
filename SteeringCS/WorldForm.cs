using System;
using System.Windows.Forms;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class WorldForm : Form
    {
        private readonly World _world;

        private const float TimeDelta = 0.8f;

        public WorldForm()
        {
            InitializeComponent();

            _world = new World(width: dbPanel.Width, height: dbPanel.Height);

            var timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 20;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs eventArgs)
        {
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        private void dbPanel1_Paint(object sender, PaintEventArgs eventArgs)
        {
            _world.Render(eventArgs.Graphics);
        }

        private void dbPanel1_MouseClick(object sender, MouseEventArgs eventArgs)
        {
            _world.Target.Position = new Vector2D(eventArgs.X, eventArgs.Y);
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
