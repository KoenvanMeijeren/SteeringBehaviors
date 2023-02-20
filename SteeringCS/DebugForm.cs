using System;
using System.Windows.Forms;
using SteeringCS.behavior;
using SteeringCS.util;
using SteeringCS.world;
using Timer = System.Timers.Timer;

namespace SteeringCS
{
    public partial class DebugForm : Form
    {
        private const SteeringBehaviorOptions SteeringBehaviorOptionDefault = SteeringBehaviorOptions.IdlingBehavior;
        WorldForm _worldForm;

        public DebugForm(WorldForm worldForm)
        {
            _worldForm = worldForm;
            InitializeComponent();
            InitializeSteeringBehaviorSelector();
            Text = pauseButton.Text;
        }

        private void InitializeSteeringBehaviorSelector()
        {
            foreach (SteeringBehaviorOptions option in Enum.GetValues(typeof(SteeringBehaviorOptions)))
            {
                SteeringBehaviorSelector.Items.Add(option);
            }

            SteeringBehaviorSelector.SelectedItem = SteeringBehaviorOptionDefault;
        }

        private void updateIntervalSelector_ValueChanged(object sender, EventArgs e)
        {
            _worldForm.UpdateTimerInterval((int)UpdateIntervalSelector.Value);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_worldForm.IsTimerEnabled())
            {
                pauseButton.Text = "Unpause";
                nextButton.Enabled = true;
                _worldForm.DisableTimer();
                return;
            }

            pauseButton.Text = "Pause";
            nextButton.Enabled = false;
            _worldForm.EnableTimer();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _worldForm.UpdateWorld();
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
            int mass = (int)MassSelector.Value;
            int maxSpeed = (int)MaxSpeedSelector.Value;
            SteeringBehaviorOptions steeringBehaviorOption = GetSelectedSteeringBehavior();
            _worldForm.UpdateEntityValues(mass, maxSpeed, steeringBehaviorOption);
        }

        private SteeringBehaviorOptions GetSelectedSteeringBehavior()
        {
            SteeringBehaviorOptions selected = SteeringBehaviorOptions.SeekingBehavior;
            if (SteeringBehaviorSelector.SelectedItem != null)
            {
                selected = (SteeringBehaviorOptions)SteeringBehaviorSelector.SelectedItem;
            }

            return selected;
        }

        private void ShowGridCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowGridCheckbox.Checked)
            {
                _worldForm.EnableGridRender();
                return;
            }

            _worldForm.DisableGridRender();
        }
    }
}
