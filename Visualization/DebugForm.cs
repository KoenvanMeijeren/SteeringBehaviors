using System;
using System.Linq;
using System.Windows.Forms;
using Src.entity;
using SteeringCS.events;
using SteeringCS.world;

namespace SteeringCS
{
    public partial class DebugForm : Form
    {
        private readonly WorldForm _worldForm;

        public DebugForm(WorldForm worldForm)
        {
            _worldForm = worldForm;
            InitializeComponent();
            Text = pauseButton.Text;

            worldForm.UpdateWorldEventHandler += WorldFormOnUpdateWorldEventHandler;
        }

        private void WorldFormOnUpdateWorldEventHandler(object sender, UpdateWorldEvent eventArgs)
        {
            if (!IsHandleCreated || IsDisposed || !IsAccessible)
            {
                return;
            }

            ProcessWorldFormOnUpdateWorldEventHandler(sender, eventArgs);
        }

        private void ProcessWorldFormOnUpdateWorldEventHandler(object sender, UpdateWorldEvent eventArgs)
        {
            WorldVisualization world = eventArgs.World;

            IPlayer player = world.Player;
            if (PlayerMassValue.Value == 0)
            {
                PlayerMassValue.Invoke((MethodInvoker)(() => PlayerMassValue.Value = (decimal)player.Mass));
            }

            if (PlayerMaxSpeedValue.Value == 0)
            {
                PlayerMaxSpeedValue.Invoke((MethodInvoker)(() => PlayerMaxSpeedValue.Value = (decimal)player.MaxSpeed));
            }

            if (player?.State != null && !PlayerStateValue.Text.Equals(player.State.ToString()))
            {
                PlayerStateValue.Invoke((MethodInvoker)(() => PlayerStateValue.Text = player.State.ToString()));
            }

            IRescuee rescuee = world.Rescuee;
            if (RescueeMassValue.Value == 0)
            {
                RescueeMassValue.Invoke((MethodInvoker)(() => RescueeMassValue.Value = (decimal)rescuee.Mass));
            }

            if (RescueeMaxSpeedValue.Value == 0)
            {
                RescueeMaxSpeedValue.Invoke((MethodInvoker)(() => RescueeMaxSpeedValue.Value = (decimal)rescuee.MaxSpeed));
            }

            if (rescuee?.State != null && !RescueeStateValue.Text.Equals(rescuee.State.ToString()))
            {
                RescueeStateValue.Invoke((MethodInvoker)(() => RescueeStateValue.Text = rescuee.State.ToString()));
            }

            IEnemy enemy1 = world.Enemies.First();
            if (enemy1 != null && Enemy1MassValue.Value == 0)
            {
                Enemy1MassValue.Invoke((MethodInvoker)(() => Enemy1MassValue.Value = (decimal)enemy1.Mass));
            }

            if (enemy1 != null && Enemy1MaxSpeedValue.Value == 0)
            {
                Enemy1MaxSpeedValue.Invoke((MethodInvoker)(() => Enemy1MaxSpeedValue.Value = (decimal)enemy1.MaxSpeed));
            }

            if (enemy1?.State != null && !Enemy1StateValue.Text.Equals(enemy1.State.ToString()))
            {
                Enemy1StateValue.Invoke((MethodInvoker)(() => Enemy1StateValue.Text = enemy1.State.ToString()));
            }

            IEnemy enemy2 = null;
            if (world.Enemies.Count > 1)
            {
                enemy2 = world.Enemies[1];
            }

            if (enemy2 != null && Enemy2MassValue.Value == 0)
            {
                Enemy2MassValue.Invoke((MethodInvoker)(() => Enemy2MassValue.Value = (decimal)enemy2.Mass));
            }

            if (enemy2 != null && Enemy2MaxSpeedValue.Value == 0)
            {
                Enemy2MaxSpeedValue.Invoke((MethodInvoker)(() => Enemy2MaxSpeedValue.Value = (decimal)enemy2.MaxSpeed));
            }

            if (enemy2?.State != null && !Enemy2StateValue.Text.Equals(enemy2.State.ToString()))
            {
                Enemy2StateValue.Invoke((MethodInvoker)(() => Enemy2StateValue.Text = enemy2.State.ToString()));
            }

            IEnemy enemy3 = null;
            if (world.Enemies.Count > 2)
            {
                enemy3 = world.Enemies[2];
            }

            if (enemy3 != null && Enemy3MassValue.Value == 0)
            {
                Enemy3MassValue.Invoke((MethodInvoker)(() => Enemy3MassValue.Value = (decimal)enemy3.Mass));
            }

            if (enemy3 != null && Enemy3MaxSpeedValue.Value == 0)
            {
                Enemy3MaxSpeedValue.Invoke((MethodInvoker)(() => Enemy3MaxSpeedValue.Value = (decimal)enemy3.MaxSpeed));
            }

            if (enemy3?.State != null && !Enemy3StateValue.Text.Equals(enemy3.State.ToString()))
            {
                Enemy3StateValue.Invoke((MethodInvoker)(() => Enemy3StateValue.Text = enemy3.State.ToString()));
            }
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

        private void PlayerMassValueChanged(object sender, EventArgs e)
        {
            int mass = (int)PlayerMassValue.Value;
            WorldVisualization world = _worldForm.World;
            IPlayer player = world.Player;
            if (player == null)
            {
                return;
            }

            player.Mass = mass;
        }

        private void PlayerMaxSpeedValueChanged(object sender, EventArgs e)
        {
            int maxSpeed = (int)PlayerMaxSpeedValue.Value;
            WorldVisualization world = _worldForm.World;
            IPlayer player = world.Player;
            if (player == null)
            {
                return;
            }

            player.MaxSpeed = maxSpeed;
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

        private void RescueeMassValue_ValueChanged(object sender, EventArgs e)
        {
            int mass = (int)RescueeMassValue.Value;
            WorldVisualization world = _worldForm.World;
            IRescuee rescuee = world.Rescuee;
            if (rescuee == null)
            {
                return;
            }

            rescuee.Mass = mass;
        }

        private void RescueeMaxSpeedValue_ValueChanged(object sender, EventArgs e)
        {
            int maxSpeed = (int)RescueeMaxSpeedValue.Value;
            WorldVisualization world = _worldForm.World;
            IRescuee rescuee = world.Rescuee;
            if (rescuee == null)
            {
                return;
            }

            rescuee.MaxSpeed = maxSpeed;
        }

        private void Enemy1MassValue_ValueChanged(object sender, EventArgs e)
        {
            int mass = (int)Enemy1MassValue.Value;
            WorldVisualization world = _worldForm.World;
            IEnemy enemy = world.Enemies.First();
            if (enemy == null)
            {
                return;
            }

            enemy.Mass = mass;
        }

        private void Enemy1MaxSpeedValue_ValueChanged(object sender, EventArgs e)
        {
            int maxSpeed = (int)Enemy1MaxSpeedValue.Value;
            WorldVisualization world = _worldForm.World;
            IEnemy enemy = world.Enemies.First();
            if (enemy == null)
            {
                return;
            }

            enemy.MaxSpeed = maxSpeed;
        }

        private void Enemy2MassValue_ValueChanged(object sender, EventArgs e)
        {
            int mass = (int)Enemy2MassValue.Value;
            WorldVisualization world = _worldForm.World;
            IEnemy enemy = null;
            if (world.Enemies.Count > 1)
            {
                enemy = world.Enemies[1];
            }

            if (enemy == null)
            {
                return;
            }

            enemy.Mass = mass;
        }

        private void Enemy2MaxSpeedValue_ValueChanged(object sender, EventArgs e)
        {
            int maxSpeed = (int)Enemy2MaxSpeedValue.Value;
            WorldVisualization world = _worldForm.World;
            IEnemy enemy = null;
            if (world.Enemies.Count > 1)
            {
                enemy = world.Enemies[1];
            }

            if (enemy == null)
            {
                return;
            }

            enemy.MaxSpeed = maxSpeed;
        }

        private void Enemy3MassValue_ValueChanged(object sender, EventArgs e)
        {
            int mass = (int)Enemy3MassValue.Value;
            WorldVisualization world = _worldForm.World;
            IEnemy enemy = null;
            if (world.Enemies.Count > 2)
            {
                enemy = world.Enemies[2];
            }

            if (enemy == null)
            {
                return;
            }

            enemy.Mass = mass;
        }

        private void Enemy3MaxSpeedValue_ValueChanged(object sender, EventArgs e)
        {
            int maxSpeed = (int)Enemy3MaxSpeedValue.Value;
            WorldVisualization world = _worldForm.World;
            IEnemy enemy = null;
            if (world.Enemies.Count > 2)
            {
                enemy = world.Enemies[2];
            }

            if (enemy == null)
            {
                return;
            }

            enemy.MaxSpeed = maxSpeed;
        }
    }
}
