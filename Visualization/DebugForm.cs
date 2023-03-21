﻿using System;
using System.Windows.Forms;
using Src.behavior;

namespace SteeringCS
{
    public partial class DebugForm : Form
    {
        private const SteeringBehaviorOptions SteeringBehaviorOptionDefault = SteeringBehaviorOptions.IdlingBehavior;
        private readonly WorldForm _worldForm;

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

        private void UpdateIntervalSelectorValueChangedChanged(object sender, EventArgs e)
        {
            _worldForm.UpdateTimerInterval((int)UpdateIntervalSelector.Value);
        }

        private void PauseButtonClick(object sender, EventArgs e)
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

        private void NextButton_Click(object sender, EventArgs e)
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

        private void ShowGraphCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowGraphCheckbox.Checked)
            {
                _worldForm.EnableGraphRender();
                return;
            }

            _worldForm.DisableGraphRender();
        }

        private void ShowHitBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowHitboxCheckbox.Checked)
            {
                _worldForm.EnableHitBoxRender();
                return;
            }

            _worldForm.DisableHitBoxRender();
        }


        private void ShowBehaviorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowBehaviorCheckbox.Checked)
            {
                _worldForm.EnableSteeringBehaviorRender();
                return;
            }

            _worldForm.DisableSteeringBehaviorRender();
        }

        private void ShowVelocityCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowVelocityCheckbox.Checked)
            {
                _worldForm.EnableVelocityRender();
                return;
            }

            _worldForm.DisableVelocityRender();
        }

        private void DebugForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
            {
                return;
            }

            Close();
            _worldForm.Close();
        }
    }
}
