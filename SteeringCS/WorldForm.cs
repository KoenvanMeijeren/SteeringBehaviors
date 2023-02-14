using System;
using System.Windows.Forms;
using SteeringCS.behaviour;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class WorldForm : Form
    {
        public const SteeringBehaviorOptions SteeringBehaviorOptionDefault = SteeringBehaviorOptions.IdleBehavior;
        private World _world;

        private const float TimeDelta = 0.8f;
        private Timer Timer = new Timer();

        public WorldForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            _world = new World(width: dbPanel.Width, height: dbPanel.Height);

            Timer.Elapsed += Timer_Elapsed;
            Timer.Interval = 20;
            Timer.Enabled = true;
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
            Timer.Interval = (int)UpdateIntervalSelector.Value;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (Timer.Enabled)
            {
                pauseButton.Text = "Unpause";
                nextButton.Enabled = true;
                Timer.Enabled = false;
                return;
            }

            pauseButton.Text = "Pause";
            nextButton.Enabled = false;
            Timer.Enabled = true;
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
            var steeringBehaviourOption = GetSelectedSteeringBehaviour();
            _world.EditPopulation(steeringBehaviourOption, mass, maxSpeed);
        }

        private SteeringBehaviorOptions GetSelectedSteeringBehaviour()
        {
            var selected = SteeringBehaviorOptions.SeekingBehavior;
            if (SteeringBehaviorSelector.SelectedItem!= null)
            {
                selected = (SteeringBehaviorOptions)SteeringBehaviorSelector.SelectedItem;
            }

            return selected;
        }
    }
}
