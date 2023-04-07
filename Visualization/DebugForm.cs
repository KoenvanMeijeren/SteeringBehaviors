using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Src.entity;
using Src.world;
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
            if (!IsHandleCreated || IsDisposed)
            {
                return;
            }

            try
            {
                // Workaround for exceptions which occurs on closing the debug form.
                // @see: https://stackoverflow.com/questions/4460709/detect-if-control-was-disposed/4460737#4460737
                ProcessWorldFormOnUpdateWorldEventHandler(sender, eventArgs);
            }
            catch (InvalidOperationException) { }
            catch (Win32Exception) { }
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

            if (world.Enemies.Count != enemiesValue.Value)
            {
                enemiesValue.Invoke((MethodInvoker)(() => enemiesValue.Value = WorldBase.DefaultEnemiesCount));
            }

            if (distanceToNearestGoombaLeftShoulderMinValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMinValue)
            {
                distanceToNearestGoombaLeftShoulderMinValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaLeftShoulderMinValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMinValue.ToString("N2")));
            }

            if (distanceToNearestGoombaLeftShoulderPeakValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderPeakValue)
            {
                distanceToNearestGoombaLeftShoulderMinValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaLeftShoulderPeakValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderPeakValue.ToString("N2")));
            }

            if (distanceToNearestGoombaLeftShoulderMaxValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMaxValue)
            {
                distanceToNearestGoombaLeftShoulderMaxValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaLeftShoulderMaxValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMaxValue.ToString("N2")));
            }

            if (distanceToNearestGoombaTriangleMinValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaTriangleMinValue)
            {
                distanceToNearestGoombaTriangleMinValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaTriangleMinValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaTriangleMinValue.ToString("N2")));
            }

            if (distanceToNearestGoombaTrianglePeakValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaTrianglePeakValue)
            {
                distanceToNearestGoombaTriangleMinValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaTrianglePeakValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaTrianglePeakValue.ToString("N2")));
            }

            if (distanceToNearestGoombaTriangleMaxValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaTriangleMaxValue)
            {
                distanceToNearestGoombaTriangleMaxValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaTriangleMaxValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaTriangleMaxValue.ToString("N2")));
            }

            if (distanceToNearestGoombaRightShoulderMinValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaRightShoulderMinValue)
            {
                distanceToNearestGoombaRightShoulderMinValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaRightShoulderMinValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaRightShoulderMinValue.ToString("N2")));
            }

            if (distanceToNearestGoombaRightShoulderPeakValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaRightShoulderPeakValue)
            {
                distanceToNearestGoombaRightShoulderMinValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaRightShoulderPeakValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaRightShoulderPeakValue.ToString("N2")));
            }

            if (distanceToNearestGoombaRightShoulderMaxValue.Value !=
                (decimal)world.FuzzyLogicData.DistanceToNearestGoombaRightShoulderMaxValue)
            {
                distanceToNearestGoombaRightShoulderMaxValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaRightShoulderMaxValue.Text = world.FuzzyLogicData.DistanceToNearestGoombaRightShoulderMaxValue.ToString("N2")));
            }

            if (ConsequenceLeftShoulderMinValue.Value !=
                (decimal)world.FuzzyLogicData.UndesirableLeftShoulderMinValue)
            {
                ConsequenceLeftShoulderMinValue.Invoke((MethodInvoker)(() => ConsequenceLeftShoulderMinValue.Text = world.FuzzyLogicData.UndesirableLeftShoulderMinValue.ToString("N2")));
            }

            if (ConsequenceLeftShoulderPeakValue.Value !=
                (decimal)world.FuzzyLogicData.UndesirableLeftShoulderPeakValue)
            {
                ConsequenceLeftShoulderPeakValue.Invoke((MethodInvoker)(() => ConsequenceLeftShoulderPeakValue.Text = world.FuzzyLogicData.UndesirableLeftShoulderPeakValue.ToString("N2")));
            }

            if (ConsequenceLeftShoulderMaxValue.Value !=
                (decimal)world.FuzzyLogicData.UndesirableLeftShoulderMaxValue)
            {
                ConsequenceLeftShoulderMaxValue.Invoke((MethodInvoker)(() => ConsequenceLeftShoulderMaxValue.Text = world.FuzzyLogicData.UndesirableLeftShoulderMaxValue.ToString("N2")));
            }

            if (ConsequenceTriangleMinValue.Value !=
                (decimal)world.FuzzyLogicData.DesirableTriangleMinValue)
            {
                ConsequenceTriangleMinValue.Invoke((MethodInvoker)(() => ConsequenceTriangleMinValue.Text = world.FuzzyLogicData.DesirableTriangleMinValue.ToString("N2")));
            }

            if (ConsequenceTrianglePeakValue.Value !=
                (decimal)world.FuzzyLogicData.DesirableTrianglePeakValue)
            {
                ConsequenceTrianglePeakValue.Invoke((MethodInvoker)(() => ConsequenceTrianglePeakValue.Text = world.FuzzyLogicData.DesirableTrianglePeakValue.ToString("N2")));
            }

            if (ConsequenceTriangleMaxValue.Value !=
                (decimal)world.FuzzyLogicData.DesirableTriangleMaxValue)
            {
                ConsequenceTriangleMaxValue.Invoke((MethodInvoker)(() => ConsequenceTriangleMaxValue.Text = world.FuzzyLogicData.DesirableTriangleMaxValue.ToString("N2")));
            }

            if (ConsequenceRightShoulderMinValue.Value !=
                (decimal)world.FuzzyLogicData.VeryDesirableRightShoulderMinValue)
            {
                ConsequenceRightShoulderMinValue.Invoke((MethodInvoker)(() => ConsequenceRightShoulderMinValue.Text = world.FuzzyLogicData.VeryDesirableRightShoulderMinValue.ToString("N2")));
            }

            if (ConsequenceRightShoulderPeakValue.Value !=
                (decimal)world.FuzzyLogicData.VeryDesirableRightShoulderPeakValue)
            {
                ConsequenceRightShoulderPeakValue.Invoke((MethodInvoker)(() => ConsequenceRightShoulderPeakValue.Text = world.FuzzyLogicData.VeryDesirableRightShoulderPeakValue.ToString("N2")));
            }

            if (ConsequenceRightShoulderMaxValue.Value !=
                (decimal)world.FuzzyLogicData.VeryDesirableRightShoulderMaxValue)
            {
                ConsequenceRightShoulderMaxValue.Invoke((MethodInvoker)(() => ConsequenceRightShoulderMaxValue.Text = world.FuzzyLogicData.VeryDesirableRightShoulderMaxValue.ToString("N2")));
            }

            distanceToNearestGoombaValue.Invoke((MethodInvoker)(() => distanceToNearestGoombaValue.Text = world.FuzzyLogicData.DistanceToNearestGoomba.ToString("N2")));
            desirabilityToFollowMarioPercentageValue.Invoke((MethodInvoker)(() => desirabilityToFollowMarioPercentageValue.Text = world.FuzzyLogicData.DeFuzzifiedValue.ToString("N2")));
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

        private void enemiesValue_ValueChanged(object sender, EventArgs e)
        {
            int enemiesCount = (int)enemiesValue.Value;
            WorldVisualization world = _worldForm.World;
            world.UpdateEnemies(enemiesCount);
        }

        private void checkBoxShouldMovePlayerOnClick_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShouldMovePlayerOnClick.Checked)
            {
                _worldForm.EnablePlayerMoveOnMouseClick();
                return;
            }

            _worldForm.DisablePlayerMoveOnMouseClick();
        }

        private void distanceToNearestGoombaLeftShoulderMinValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaLeftShoulderMinValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaLeftShoulderMinValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMinValue = value;
            }));
        }

        private void distanceToNearestGoombaLeftShoulderPeakValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaLeftShoulderPeakValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaLeftShoulderPeakValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderPeakValue = value;
            }));
        }

        private void distanceToNearestGoombaLeftShoulderMaxValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaLeftShoulderMaxValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaLeftShoulderMaxValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaLeftShoulderMaxValue = value;
            }));
        }

        private void distanceToNearestGoombaTriangleMinValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaTriangleMinValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaTriangleMinValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaTriangleMinValue = value;
            }));
        }

        private void distanceToNearestGoombaTrianglePeakValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaTrianglePeakValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaTrianglePeakValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaTrianglePeakValue = value;
            }));
        }

        private void distanceToNearestGoombaTriangleMaxValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaTriangleMaxValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaTriangleMaxValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaTriangleMaxValue = value;
            }));
        }

        private void distanceToNearestGoombaRightShoulderMinValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaRightShoulderMinValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaRightShoulderMinValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaRightShoulderMinValue = value;
            }));
        }

        private void distanceToNearestGoombaRightShoulderPeakValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaRightShoulderPeakValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaRightShoulderPeakValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaRightShoulderPeakValue = value;
            }));
        }

        private void distanceToNearestGoombaRightShoulderMaxValue_ValueChanged(object sender, EventArgs e)
        {
            distanceToNearestGoombaRightShoulderMaxValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)distanceToNearestGoombaRightShoulderMaxValue.Value;
                _worldForm.World.FuzzyLogicData.DistanceToNearestGoombaRightShoulderMaxValue = value;
            }));
        }

        private void ConsequenceLeftShoulderMinValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceLeftShoulderMinValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceLeftShoulderMinValue.Value;
                _worldForm.World.FuzzyLogicData.UndesirableLeftShoulderMinValue = value;
            }));
        }

        private void ConsequenceLeftShoulderPeakValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceLeftShoulderPeakValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceLeftShoulderPeakValue.Value;
                _worldForm.World.FuzzyLogicData.UndesirableLeftShoulderPeakValue = value;
            }));
        }

        private void ConsequenceLeftShoulderMaxValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceLeftShoulderMaxValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceLeftShoulderMaxValue.Value;
                _worldForm.World.FuzzyLogicData.UndesirableLeftShoulderMaxValue = value;
            }));
        }

        private void ConsequenceTriangleMinValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceTriangleMinValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceTriangleMinValue.Value;
                _worldForm.World.FuzzyLogicData.DesirableTriangleMinValue = value;
            }));
        }

        private void ConsequenceTrianglePeakValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceTrianglePeakValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceTrianglePeakValue.Value;
                _worldForm.World.FuzzyLogicData.DesirableTrianglePeakValue = value;
            }));
        }

        private void ConsequenceTriangleMaxValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceTriangleMaxValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceTriangleMaxValue.Value;
                _worldForm.World.FuzzyLogicData.DesirableTriangleMaxValue = value;
            }));
        }

        private void ConsequenceRightShoulderMinValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceRightShoulderMinValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceRightShoulderMinValue.Value;
                _worldForm.World.FuzzyLogicData.VeryDesirableRightShoulderMinValue = value;
            }));
        }

        private void ConsequenceRightShoulderPeakValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceRightShoulderPeakValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceRightShoulderPeakValue.Value;
                _worldForm.World.FuzzyLogicData.VeryDesirableRightShoulderPeakValue = value;
            }));
        }

        private void ConsequenceRightShoulderMaxValue_ValueChanged(object sender, EventArgs e)
        {
            ConsequenceRightShoulderMaxValue.Invoke((MethodInvoker)(() =>
            {
                double value = (double)ConsequenceRightShoulderMaxValue.Value;
                _worldForm.World.FuzzyLogicData.VeryDesirableRightShoulderMaxValue = value;
            }));
        }
    }
}
