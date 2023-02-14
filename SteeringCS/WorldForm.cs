using System;
using System.Windows.Forms;
using SteeringCS.behavior;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class WorldForm : Form
    {
        private const SteeringBehaviorOptions SteeringBehaviorOptionDefault = SteeringBehaviorOptions.IdlingBehavior;
        private World _world;

        private const float TimeDelta = 0.8f;
        private readonly Timer _timer = new Timer();

        public WorldForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _world = new World(width: dbPanel.Width, height: dbPanel.Height);

            _timer.Elapsed += Timer_Elapsed;
            _timer.Interval = 20;
            _timer.Enabled = true;
            InitializeSteeringBehaviorSelector();
        }

        private void InitializeSteeringBehaviorSelector()
        {
            foreach (SteeringBehaviorOptions option in Enum.GetValues(typeof(SteeringBehaviorOptions)))
            {
                SteeringBehaviorSelector.Items.Add(option);
            }
            SteeringBehaviorSelector.SelectedItem = SteeringBehaviorOptionDefault;
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
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        private void updateIntervalSelector_ValueChanged(object sender, EventArgs e)
        {
            _timer.Interval = (int)UpdateIntervalSelector.Value;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                pauseButton.Text = "Unpause";
                nextButton.Enabled = true;
                _timer.Enabled = false;
                return;
            }

            pauseButton.Text = "Pause";
            nextButton.Enabled = false;
            _timer.Enabled = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _world.Update(TimeDelta);
            dbPanel.Invalidate();
        }

        private void MassSelector_ValueChanged(object sender, EventArgs e)
        {
            UpdateEntityValues();
        }

        private void MaxSpeedSelector_ValueChanged(object sender, EventArgs e)
        {
            UpdateEntityValues();
        }

        private void SteeringBehaviorSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEntityValues();
        }

        private void UpdateEntityValues()
        {
            var mass = (int)MassSelector.Value;
            var maxSpeed = (int)MaxSpeedSelector.Value;
            var steeringBehaviorOption = GetSelectedSteeringBehavior();
            _world.EditPopulation(steeringBehaviorOption, mass, maxSpeed);
        }

        private SteeringBehaviorOptions GetSelectedSteeringBehavior()
        {
            var selected = SteeringBehaviorOptions.SeekingBehavior;
            if (SteeringBehaviorSelector.SelectedItem != null)
            {
                selected = (SteeringBehaviorOptions)SteeringBehaviorSelector.SelectedItem;
            }

            return selected;
        }
    }
}
